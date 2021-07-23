using Modding.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Modding
{
	internal class ModLoader
	{
		/// <summary>
		/// Wheter mods have finished loading
		/// </summary>
		public static bool loaded;

		public static Dictionary<Type, ModInstance> ModInstanceTypeMap { get; private set; } = new();
		public static Dictionary<string, ModInstance> ModInstanceNameMap { get; private set; } = new();
		public static HashSet<ModInstance> ModInstances { get; private set; } = new();

		private static void AddModInstance(Type type, ModInstance mod)
		{
			Debug.Log(mod.Name);
			ModInstanceTypeMap[type] = mod;
			ModInstanceNameMap[mod.Name] = mod;
			ModInstances.Add(mod);
		}

		internal static IEnumerator LoadMods(GameObject coroutineHolder)
		{
			if(loaded)
			{
				Debug.Log("Mods have already been loaded. Something went wrong.");
				UnityEngine.Object.Destroy(coroutineHolder);
				yield break;
			}

			string modPath = SystemInfo.operatingSystemFamily switch
			{
				OperatingSystemFamily.Windows => Path.Combine(Application.dataPath, "Managed", "Mods"),
				OperatingSystemFamily.MacOSX => Path.Combine(Application.dataPath, "Resources", "Data", "Managed", "Mods"),
				OperatingSystemFamily.Linux => Path.Combine(Application.dataPath, "Managed", "Mods"),

				OperatingSystemFamily.Other => null,

				_ => throw new ArgumentOutOfRangeException()
			};

			if(modPath == null)
			{
				loaded = true;
				UnityEngine.Object.Destroy(coroutineHolder);
				yield break;
			}

			string[] files = Directory.GetFiles(modPath, "*.dll", SearchOption.AllDirectories).Where(directory => !directory.ToUpper().Contains("DISABLED")).ToArray();

			Assembly Resolve(object sender, ResolveEventArgs args)
			{
				AssemblyName assemblyName = new AssemblyName(args.Name);

				if (files.FirstOrDefault(x => x.EndsWith($"{assemblyName.Name}.dll")) is string path)
				{
					return Assembly.LoadFrom(path);
				}

				return null;
			}

			AppDomain.CurrentDomain.AssemblyResolve += Resolve;

			foreach (string path in files)
			{
				LoadMod(path);
			}

			loaded = true;
		}

		internal static IEnumerator LoadMod(string path)
		{
			try
			{
				foreach (Type type in Assembly.LoadFrom(path).GetTypes())
				{
					if (!(type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(Mod))))
					{
						continue;
					}

					try
					{
						if (type.GetConstructor(new Type[0])?.Invoke(new object[0]) is Mod mod)
						{
							AddModInstance(
								type,
								new ModInstance
								{
									Mod = mod,
									Enabled = false,
									Error = null,
									Name = mod.GetName()
								}
							);
						}
					}
					catch (Exception e)
					{
						AddModInstance(
							type,
							new ModInstance
							{
								Mod = null,
								Enabled = false,
								Error = ModErrorState.Construct,
								Name = type.Name
							}
						);
						Debug.Log(e);
					}
				}

				foreach(ModInstance modInstance in ModInstances)
				{
					modInstance.Mod.Initialize();
				}
			}
			catch (Exception e)
			{
				Debug.Log(e);
			}
			yield break;
		}
	}
}
