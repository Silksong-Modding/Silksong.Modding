using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modding
{
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
