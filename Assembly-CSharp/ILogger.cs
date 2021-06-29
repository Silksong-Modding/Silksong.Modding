﻿using Modding.enums;

namespace Modding
{
	public interface ILogger
	{
		public void Log(string message, LogType type);
		public void Log(object message, LogType type);
		public void LogInfo(string message);
		public void LogInfo(object message);
		public void LogDebug(string message);
		public void LogDebug(object message);
		public void LogFine(string message);
		public void LogFine(object message);
		public void LogWarning(string message);
		public void LogWarning(object message);
		public void LogError(string message);
		public void LogError(object message);
	}
}
