namespace Modding
{
	/// <summary>
	///		All hooks exposed by the modding API
	/// </summary>
	public class ModHooks
	{
		private static GlobalAPISettings _globalSettings;

		internal static GlobalAPISettings GlobalAPISettings
		{
			get
			{
				if (_globalSettings != null) return _globalSettings;

				_globalSettings = new GlobalAPISettings();
				return _globalSettings;
			}
		}
	}
}
