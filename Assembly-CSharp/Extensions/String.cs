namespace Modding.Extensions
{
	public static class String
	{
		public static bool IsNullOrEmptyOrWhitespace(this string str)
		{
			return (str.IsNullOrWhiteSpace() || str.IsNullOrEmpty());
		}

		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
		
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}
	}
}
