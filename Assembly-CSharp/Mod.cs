using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Modding
{
	/// <summary>
	/// The default class to be inherited by all mods
	/// </summary>
	public abstract class Mod : IMod
	{
		/// <summary>
		/// The name of the mod inheriting this class
		/// </summary>
		private readonly string name;

		/// <summary>
		/// The constructor for every mod
		/// </summary>
		/// <param name="name">The name of the mod. Defaults to the name of the class</param>
		protected Mod(string name = null)
		{
			if(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
			{
				name = GetType().Name;
			}

			this.name = name;
		}

		/// <summary>
		/// A funtion to get the name of a mod
		/// </summary>
		/// <returns>The name of a mod</returns>
		public virtual string GetName() => name;

		// instead of something like UNKNOWN I think it's best to return the hash of the assembly to be able to distinguish between versions
		/// <summary>
		/// A function to get the version of a mod
		/// </summary>
		/// <returns>The version of the mod in the form of a string</returns>
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

		/// <summary>
		/// A function called on the initialization of the mod
		/// </summary>
		public abstract void Initialize();
	}
}
