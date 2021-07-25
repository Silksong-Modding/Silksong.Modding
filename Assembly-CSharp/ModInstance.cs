using Modding.Enums;

namespace Modding
{
	public struct ModInstance
	{
		public IMod Mod;

		public string Name;
		public ModErrorState? Error;
	}
}
