using Modding.Enums;

namespace Modding.Structs
{
	/// <summary>
	/// A struct containing references to data related to mods
	/// </summary>
	public struct ModInstance
	{
		/// <summary>
		/// A reference to the interface for every mod
		/// </summary>
		public IMod Mod;

		/// <summary>
		/// The name of the mod
		/// </summary>
		public string Name;

		/// <summary>
		/// The point at which the mod crashed or null
		/// </summary>
		public ModErrorState? Error;
	}
}
