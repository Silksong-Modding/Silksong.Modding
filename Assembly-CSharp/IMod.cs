using System.Collections.Generic;
using UnityEngine;

namespace Modding
{
	/// <summary>
	///		The interface inplemented by all mods
	/// </summary>
	public interface IMod : ILogger
	{

		/// <summary>
		///		Get the name of the mod implementing this instance of the interface
		/// </summary>
		/// <returns>The name of the mod. Defaults to the name of the class implementing this interface</returns>
		string GetName();

		/// <summary>
		///		Get all scenes and paths to objects to preload
		/// </summary>
		/// <returns>A list containing a list of scenes and paths to objects to preload</returns>
		List<(string, string)> GetPreloadNames();

		/// <summary>
		///		Called on initialisation of the mod
		/// </summary>
		void Initialize();

		/// <summary>
		///		Called on initialisation of the mod
		/// </summary>
		/// <param name="preloadedObjects">A dictionary containing a string with the scene and another dictionary containing the path to the preloaded object and the preloaded object itself</param>
		void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects);

		/// <summary>
		///		Get the current version of the mod. Defaults to "UNKNOWN"
		/// </summary>
		/// <returns></returns>
		string GetVersion();

		/// <summary>
		///		Priority to load the mod. Defaults to dependencies and then alphabetical
		/// </summary>
		/// <returns></returns>
		int LoadPriority();
	}
}
