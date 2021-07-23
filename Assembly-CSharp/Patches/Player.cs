using MonoMod;
using UnityEngine;

namespace Modding.Patches
{
	[MonoModPatch("global::Player")]
	class Player : global::Player
	{
		private void Start()
		{
			GameObject coroutineHolder = new GameObject();
			DontDestroyOnLoad(coroutineHolder);
			Debug.Log("LLL");
			coroutineHolder.AddComponent<Empty>().StartCoroutine(ModLoader.LoadMods(coroutineHolder));
		}
	}
}
