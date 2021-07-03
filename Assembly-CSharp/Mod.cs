using Modding.enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modding
{
	/// <summary>
	///		The default class that should be extended by all mods
	/// </summary>
	public class Mod : IMod
	{
		public string GetName()
		{
			throw new NotImplementedException();
		}

		public List<(string, string)> GetPreloadNames()
		{
			throw new NotImplementedException();
		}

		public string GetVersion()
		{
			throw new NotImplementedException();
		}

		public void Initialize()
		{
			throw new NotImplementedException();
		}

		public void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
		{
			throw new NotImplementedException();
		}

		public int LoadPriority()
		{
			throw new NotImplementedException();
		}

		public void Log(string message, LogLevel level)
		{
			throw new NotImplementedException();
		}

		public void Log(object message, LogLevel level)
		{
			throw new NotImplementedException();
		}

		public void LogDebug(string message)
		{
			throw new NotImplementedException();
		}

		public void LogDebug(object message)
		{
			throw new NotImplementedException();
		}

		public void LogError(string message)
		{
			throw new NotImplementedException();
		}

		public void LogError(object message)
		{
			throw new NotImplementedException();
		}

		public void LogFine(string message)
		{
			throw new NotImplementedException();
		}

		public void LogFine(object message)
		{
			throw new NotImplementedException();
		}

		public void LogInfo(string message)
		{
			throw new NotImplementedException();
		}

		public void LogInfo(object message)
		{
			throw new NotImplementedException();
		}

		public void LogWarning(string message)
		{
			throw new NotImplementedException();
		}

		public void LogWarning(object message)
		{
			throw new NotImplementedException();
		}
	}
}
