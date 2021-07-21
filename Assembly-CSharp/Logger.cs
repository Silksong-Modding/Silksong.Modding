using Modding.Enums;
using System.Text;

namespace Modding
{
	public class Logger : ILogger
	{
		private readonly string loggerName = "";

		public Logger(string name)
		{
			loggerName = name;
		}

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

		public void Log(object message, LogLevel level)
		{
			Log(message.ToString(), level);
		}

		public void LogDebug(string message)
		{
			Log(message, LogLevel.DEBUG);
		}

		public void LogDebug(object message)
		{
			Log(message.ToString(), LogLevel.DEBUG);
		}

		public void LogError(string message)
		{
			Log(message, LogLevel.ERROR);
		}

		public void LogError(object message)
		{
			Log(message.ToString(), LogLevel.ERROR);
		}

		public void LogFine(string message)
		{
			Log(message, LogLevel.FINE);
		}

		public void LogFine(object message)
		{
			Log(message.ToString(), LogLevel.FINE);
		}

		public void LogInfo(string message)
		{
			Log(message, LogLevel.INFO);
		}

		public void LogInfo(object message)
		{
			Log(message.ToString(), LogLevel.INFO);
		}

		public void LogWarning(string message)
		{
			Log(message, LogLevel.WARNING);
		}

		public void LogWarning(object message)
		{
			Log(message.ToString(), LogLevel.WARNING);
		}
	}
}
