namespace Modding.Enums
{
	/// <summary>
	/// The point at which a mod failed and threw an error
	/// </summary>
	public enum ModErrorState
	{
		/// <summary>
		/// When the mod fails on calling the constructor
		/// </summary>
		Construct,

		/// <summary>
		/// When the mod fails on initialization
		/// </summary>
		Initialize
	}
}
