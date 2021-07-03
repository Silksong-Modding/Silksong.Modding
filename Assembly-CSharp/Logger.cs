using Modding.enums;
using System.Text;

namespace Modding
{
	/// <summary>
	///		The class handling everything logging related
	/// </summary>
	public class Logger : ILogger
	{
		private readonly string loggerName = "";

		/// <summary>
		///		Constructor for the Logger class
		/// </summary>
		/// <param name="name">The name used for this logger</param>
		public Logger(string name)
		{
			loggerName = name;
		}

		/// <summary>
		///		Log a message to the console
		/// </summary>
		/// <param name="message">The message to log</param>
		/// <param name="level">The level at which the message has to be logged to the console</param>
		public void Log(string message, LogLevel level)
		{
			switch(level)
			{
				case LogLevel.INFO:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logInfo) return;
					break;
				case LogLevel.WARNING:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logWarning) return;
					break;
				case LogLevel.ERROR:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logError) return;
					break;
				case LogLevel.FINE:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logFine) return;
					break;
				case LogLevel.DEBUG:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logDebug) return;
					break;
			}

			StringBuilder logText = new();
			StringBuilder fileText = new();

			fileText.Append("[");
			fileText.Append(level.ToString());
			fileText.Append("]");

			logText.Append(":");

			logText.Append("[");
			logText.Append(loggerName);
			logText.Append("]");

			logText.Append(" - ");
			logText.Append(message);

			fileText.Append(logText.ToString());
		}

		/// <summary>
		///		Log a message to the console
		/// </summary>
		/// <param name="message">The message to log</param>
		/// <param name="level">The level at which the message has to be logged to the console</param>
		public void Log(object message, LogLevel level)
		{
			Log(message.ToString(), level);
		}

		/// <summary>
		///		Log a message to the console at debug level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogDebug(string message)
		{
			Log(message, LogLevel.DEBUG);
		}

		/// <summary>
		///		Log a message to the console at debug level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogDebug(object message)
		{
			Log(message.ToString(), LogLevel.DEBUG);
		}

		/// <summary>
		///		Log a message to the console at error level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogError(string message)
		{
			Log(message, LogLevel.ERROR);
		}

		/// <summary>
		///		Log a message to the console at error level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogError(object message)
		{
			Log(message.ToString(), LogLevel.ERROR);
		}

		/// <summary>
		///		Log a message to the console at fine level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogFine(string message)
		{
			Log(message, LogLevel.FINE);
		}

		/// <summary>
		///		Log a message to the console at fine level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogFine(object message)
		{
			Log(message.ToString(), LogLevel.FINE);
		}

		/// <summary>
		///		Log a message to the console at info level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogInfo(string message)
		{
			Log(message, LogLevel.INFO);
		}

		/// <summary>
		///		Log a message to the console at info level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogInfo(object message)
		{
			Log(message.ToString(), LogLevel.INFO);
		}

		/// <summary>
		///		Log a message to the console at warning level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogWarning(string message)
		{
			Log(message, LogLevel.WARNING);
		}

		/// <summary>
		///		Log a message to the console at warning level
		/// </summary>
		/// <param name="message">The message to log</param>
		public void LogWarning(object message)
		{
			Log(message.ToString(), LogLevel.WARNING);
		}
	}
}
