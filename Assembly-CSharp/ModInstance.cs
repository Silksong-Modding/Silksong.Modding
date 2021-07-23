using Modding.Enums;

namespace Modding
{
	public class ModInstance
	{
		public IMod Mod;

		public string Name;
		public ModErrorState? Error;
		public bool Enabled;
	}
}
