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

		public static bool loaded;

		public static Dictionary<Type, ModInstance> ModInstanceTypeMap { get; private set; } = new();
		public static Dictionary<string, ModInstance> ModInstanceNameMap { get; private set; } = new();
		public static HashSet<ModInstance> ModInstances { get; private set; } = new();

		private static void AddModInstance(Type ty, ModInstance mod)
		{
			ModInstanceTypeMap[ty] = mod;
			ModInstanceNameMap[mod.Name] = mod;
			ModInstances.Add(mod);
		}

		internal static IEnumerator LoadMods(GameObject coroutineHolder)
		{
			if(loaded)
			{
				//log that mods already have been loaded and that the method was called twice
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

			string[] files = Directory.GetDirectories(modPath).SelectMany(dir => Directory.GetFiles(dir, "*.dll")).ToArray();

			Assembly Resolve(object sender, ResolveEventArgs args)
			{
				var asm_name = new AssemblyName(args.Name);

				if (files.FirstOrDefault(x => x.EndsWith($"{asm_name.Name}.dll")) is string path)
					return Assembly.LoadFrom(path);

				return null;
			}

			AppDomain.CurrentDomain.AssemblyResolve += Resolve;

			foreach (string assemblyPath in files)
			{
				try
				{
					foreach (Type type in Assembly.LoadFrom(assemblyPath).GetTypes())
					{
						if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(Mod)))
							continue;


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
						}
					}
				}
				catch (Exception e)
				{
					
				}
			}

			loaded = true;
		}
	}
}
