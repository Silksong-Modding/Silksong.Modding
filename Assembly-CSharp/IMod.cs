using System.Collections.Generic;
using UnityEngine;

namespace Modding
{
	/// <summary>
	///		The interface inplemented by all mods
	/// </summary>
	public interface IMod : ILogger
	{
		string GetName();

		List<(string, string)> GetPreloadNames();

		void Initialize();

		void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects);

		string GetVersion();
	}
}
