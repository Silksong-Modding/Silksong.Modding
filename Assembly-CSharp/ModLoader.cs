using Modding.Enums;
using Modding.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Modding
{
	/// <summary>
	/// The class responsible for loading all mods
	/// </summary>
	internal class ModLoader
	{
		/// <summary>
		/// Wheter mods have finished loading
		/// </summary>
		public static bool loaded;

		/// <summary>
		/// A dictionary containing references to all mod types and their related ModInstance
		/// </summary>
		public static Dictionary<Type, ModInstance> ModInstanceTypeMap { get; private set; } = new Dictionary<Type, ModInstance>();
		/// <summary>
		/// A dictionary containing references to all mod names and their related ModInstance
		/// </summary>
		public static Dictionary<string, ModInstance> ModInstanceNameMap { get; private set; } = new Dictionary<string, ModInstance>();
		/// <summary>
		/// A list containing references to all ModInstances
		/// </summary>
		public static List<ModInstance> ModInstances { get; private set; } = new List<ModInstance>();

		/// <summary>
		/// A function to add the modinstance to all dictionaries and lists
		/// </summary>
		/// <param name="type">The type of the mod</param>
		/// <param name="mod"></param>
		internal static void AddModInstance(Type type, ModInstance mod)
		{
			Debug.Log(mod.Name);
			ModInstanceTypeMap[type] = mod;
			ModInstanceNameMap[mod.Name] = mod;
			ModInstances.Add(mod);
		}

		/// <summary>
		/// A function that loads all mods
		/// </summary>
		/// <param name="coroutineHolder">The GameObject containing all coroutines</param>
		/// <returns></returns>
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

			Debug.Log("Loading mods");

			foreach (string path in files)
			{
				TryConstructMod(path);
			}

			Debug.Log("Finished loading mods");

			Debug.Log("Initializing mods");

			TryInitializeMod();

			Debug.Log("Finished initializing mods");

			loaded = true;
		}

		/// <summary>
		/// A function that tries to call the constructor of a mod
		/// </summary>
		/// <param name="path">The path to the mod</param>
		/// <returns></returns>
		internal static IEnumerator TryConstructMod(string path)
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
							AddModInstance(type,
								new ModInstance
								{
									Mod = mod,
									Error = null,
									Name = mod.GetName()
								});
						}
					}
					catch (Exception e)
					{
						AddModInstance(type,
							new ModInstance
							{
								Mod = null,
								Error = ModErrorState.Construct,
								Name = type.Name
							});
						Debug.Log(e);
					}
				}
			}
			catch (Exception e)
			{
				Debug.Log(e);
			}
			yield break;
		}

		/// <summary>
		/// Attempt to call the initialize function of a mod
		/// </summary>
		internal static IEnumerator TryInitializeMod()
		{
			for (int i = 0; i < ModInstances.Count; i++)
			{
				ModInstance instance = ModInstances[i];
				if (instance.Error == ModErrorState.Construct) yield break;

				try
				{
					instance.Mod.Initialize();
				}
				catch (Exception e)
				{
					instance.Error = ModErrorState.Initialize;
					Debug.Log(e.StackTrace);
				}
			}
		}
	}
}
