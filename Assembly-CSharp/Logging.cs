using Modding.Enums;
using System;

namespace Modding
{
	public abstract class Logging : ILogger
	{
		private string name;

		protected Logging()
		{
			name = GetType().Name;
		}

		public virtual void Log(string message, LogLevel level)
		{
			throw new NotImplementedException();
		}

		public virtual void Log(object message, LogLevel level)
		{
			throw new NotImplementedException();
		}

		public virtual void LogDebug(string message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogDebug(object message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogError(string message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogError(object message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogFine(string message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogFine(object message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogInfo(string message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogInfo(object message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogWarning(string message)
		{
			throw new NotImplementedException();
		}

		public virtual void LogWarning(object message)
		{
			throw new NotImplementedException();
		}
	}
}
