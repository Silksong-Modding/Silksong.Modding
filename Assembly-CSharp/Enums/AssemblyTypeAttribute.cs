using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This isn't an enum, but can be treated as one in my opinion

namespace Modding.Enums
{
	class AssemblyTypeAttribute : Attribute
	{
		public const int LIBRARY = 0;
		public const int MOD = 1;
		public const int ADDON = 2;
	}
}
