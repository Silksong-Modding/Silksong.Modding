using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Modding
{
	public abstract class Mod : Logging, IMod
	{
		private readonly string name;

		protected Mod(string name = null)
		{
			if(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
			{
				name = GetType().Name;
			}

			this.name = name;
		}

		public virtual string GetName()
		{
			return name;
		}

		public virtual List<(string, string)> GetPreloadNames()
		{
			return new List<(string, string)>();
		}

		// instead of something like UNKNOWN I think it's best to return the hash of the assembly 
		public virtual string GetVersion()
		{
			Assembly asm = Assembly.GetCallingAssembly();

			string ver = asm.GetName().Version.ToString();

			SHA1 sha1 = SHA1.Create();
			FileStream stream = File.OpenRead(asm.Location);

			byte[] hashBytes = sha1.ComputeHash(stream);

			string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

			stream.Close();
			sha1.Clear();

			string ret = new StringBuilder(ver).Append("-").Append(hash.Substring(0, 6)).ToString();

			return ret;
		}

		public virtual void Initialize()
		{
			throw new NotImplementedException();
		}

		public virtual void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
		{
			throw new NotImplementedException();
		}
	}
}
