namespace Modding
{
	/// <summary>
	///		All settings related to the in game console
	/// </summary>
	public class InGameConsoleSettings
	{
		/// <summary>
		///		Wheter to show the in game console in game
		/// </summary>
		public bool showConsoleInGame = false;

		/// <summary>
		///		Wheter or not to log to the console in color
		/// </summary>
		public bool useColouredConsole = false;

		/// <summary>
		///		Wheter to log messages logged at the level fine
		/// </summary>
		public bool logFine = true;

		/// <summary>
		///		Wheter to log messages logged at the level info
		/// </summary>
		public bool logInfo = true;

		/// <summary>
		///		Wheter to log messages logged at the level debug
		/// </summary>
		public bool logDebug = true;

		/// <summary>
		///		Wheter to log messages logged at the level warning
		/// </summary>
		public bool logWarning = true;

		/// <summary>
		///		Wheter to log messages logged at the level error
		/// </summary>
		public bool logError = true;
	}
}
