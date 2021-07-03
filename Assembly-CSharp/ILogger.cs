using Modding.enums;

namespace Modding
{
	/// <summary>
	///		The inteface implemented by all logging classes
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		///		Log a message to the console
		/// </summary>
		/// <param name="message">The message to log</param>
		/// <param name="level">The level at which the message has to be logged to the console</param>
		public void Log(string message, LogLevel level);

		/// <summary>
		///		Log a message to the console
		/// </summary>
		/// <param name="message">The message to log</param>
		/// <param name="level">The level at which the message has to be logged to the console</param>
		public void Log(object message, LogLevel level);

		/// <summary>
		///		Log a message to the console at info level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogInfo(string message);

		/// <summary>
		///		Log a message to the console at info level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogInfo(object message);

		/// <summary>
		///		Log a message to the console at debug level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogDebug(string message);

		/// <summary>
		///		Log a message to the console at debug level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogDebug(object message);

		/// <summary>
		///		Log a message to the console at fine level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogFine(string message);

		/// <summary>
		///		Log a message to the console at fine level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogFine(object message);

		/// <summary>
		///		Log a message to the console at warning level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogWarning(string message);

		/// <summary>
		///		Log a message to the console at warning level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogWarning(object message);

		/// <summary>
		///		Log a message to the console at error level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogError(string message);

		/// <summary>
		///		Log a message to the console at error level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogError(object message);
	}
}
