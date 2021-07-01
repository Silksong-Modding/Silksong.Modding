using Modding.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modding
{
	public class Logger : ILogger
	{
		private readonly string loggerName = "";

		public Logger(string name)
		{
			loggerName = name;
		}

		public void Log(string message, LogType type)
		{
			switch(type)
			{
				case LogType.INFO:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logInfo) return;
					break;
				case LogType.WARNING:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logWarning) return;
					break;
				case LogType.ERROR:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logError) return;
					break;
				case LogType.FINE:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logFine) return;
					break;
				case LogType.DEBUG:
					if (!ModHooks.GlobalAPISettings.consoleSettings.logDebug) return;
					break;
			}

			StringBuilder logText = new();
			StringBuilder fileText = new();

			fileText.Append("[");
			fileText.Append(type.ToString());
			fileText.Append("]");

			logText.Append(":");

			logText.Append("[");
			logText.Append(loggerName);
			logText.Append("]");

			logText.Append(" - ");
			logText.Append(message);

			fileText.Append(logText.ToString());
		}

		public void Log(object message, LogType type)
		{
			Log(message.ToString(), type);
		}

		public void LogDebug(string message)
		{
			Log(message, LogType.DEBUG);
		}

		public void LogDebug(object message)
		{
			Log(message.ToString(), LogType.DEBUG);
		}

		public void LogError(string message)
		{
			Log(message, LogType.ERROR);
		}

		public void LogError(object message)
		{
			Log(message.ToString(), LogType.ERROR);
		}

		public void LogFine(string message)
		{
			Log(message, LogType.FINE);
		}

		public void LogFine(object message)
		{
			Log(message.ToString(), LogType.FINE);
		}

		public void LogInfo(string message)
		{
			Log(message, LogType.INFO);
		}

		public void LogInfo(object message)
		{
			Log(message.ToString(), LogType.INFO);
		}

		public void LogWarning(string message)
		{
			Log(message, LogType.WARNING);
		}

		public void LogWarning(object message)
		{
			Log(message.ToString(), LogType.WARNING);
		}
	}
}
