using MonoMod;
using UnityEngine;

namespace Modding.Patches
{
	/// <summary>
	/// The class that patches the Player class in the base game. This class is temporary until silksong releases
	/// </summary>
	[MonoModPatch("global::Player")]
	class Player : global::Player
	{
		/// <summary>
		/// Called on the start of this game object. Starts the process of loading mods
		/// </summary>
		private void Start()
		{
			GameObject coroutineHolder = new GameObject();
			DontDestroyOnLoad(coroutineHolder);
			Debug.Log("LLL");
			coroutineHolder.AddComponent<Empty>().StartCoroutine(ModLoader.LoadMods(coroutineHolder));
		}
	}
}
