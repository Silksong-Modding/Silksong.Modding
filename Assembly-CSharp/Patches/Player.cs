using UnityEngine;

namespace Modding.Patches
{
	class Player : global::Player
	{
		[MonoMod.MonoModPatch("global::Player")]
		private void Start()
		{
			GameObject coroutineHolder = new GameObject();
			DontDestroyOnLoad(coroutineHolder);

			coroutineHolder.AddComponent<Empty>().StartCoroutine(ModLoader.LoadMods(coroutineHolder));
		}
	}
}
