﻿using Modding.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modding
{
	internal class ModLoader
	{

		public static bool loaded;

		internal static IEnumerator LoadMods()
		{
			if(loaded)
			{
				//log that mods already have been loaded and that the method was called twice
				yield break;
			}

			GameObject coroutineHolder = new GameObject();
			UnityEngine.Object.DontDestroyOnLoad(coroutineHolder);

			string path = string.Empty;

			if (SystemInfo.operatingSystem.Contains("Windows"))
			{
				
			}
			else if (SystemInfo.operatingSystem.Contains("Mac"))
			{
				
			}
			else if (SystemInfo.operatingSystem.Contains("Linux"))
			{
				
			}

			if(path.IsNullOrEmptyOrWhitespace())
			{
				loaded = true;
				yield break;
			}

			switch(SystemInfo.operatingSystem)
			{
				case string a when a.Contains("Windows"):
					path = Application.dataPath + "\\Managed\\Mods";
					break;
				case string b when b.Contains("Mac"):
					path = Application.dataPath + "/Resources/Data/Managed/Mods/";
					break;
				case string c when c.Contains("Linux"):
					path = Application.dataPath + "/Managed/Mods";
					break;
				default:
					loaded = true;
					yield break;
			}
		}
	}
}