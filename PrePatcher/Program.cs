using Mono.Cecil.Cil;
using Mono.Cecil;
using System;
using Mono.Cecil.Rocks;
using System.Linq;

namespace PrePatcher
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Usage: PrePatcher.exe <Original> <Patched>");
				return;
			}

			using ModuleDefinition module = ModuleDefinition.ReadModule(args[0]);

			foreach (TypeDefinition type in module.Types.Where(type => type.HasMethods))
			{
				foreach (MethodDefinition method in type.Methods)
				{
					if(!method.HasBody)continue;

					method.Body.Optimize();
					method.Body.OptimizeMacros();
				}
			}

			module.Write(args[1]);
		}
	}
}
