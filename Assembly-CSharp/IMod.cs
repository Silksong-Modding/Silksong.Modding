namespace Modding
{
	/// <summary>
	///		The interface inplemented by all mods
	/// </summary>
	public interface IMod
	{
		/// <summary>
		/// A funtion to get the name of a mod
		/// </summary>
		/// <returns>The name of a mod</returns>
		string GetName();

		/// <summary>
		/// A function to get the version of a mod
		/// </summary>
		/// <returns>The version of the mod in the form of a string</returns>
		string GetVersion();

		/// <summary>
		/// A function called on the initialization of the mod
		/// </summary>
		void Initialize();
	}
}
