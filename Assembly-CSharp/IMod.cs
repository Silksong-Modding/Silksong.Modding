using System.Collections.Generic;
using UnityEngine;

namespace Modding
{
	/// <summary>
	///		The interface inplemented by all mods
	/// </summary>
	public interface IMod : ILogger
	{
		string GetName();

		string GetVersion();

		void Initialize();
	}
}
