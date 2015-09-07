using System;
namespace BIC.Biz
{
	public abstract class BaseTag : BizObject
	{
	
		/// <summary>
		/// Cache the input data, if caching is enabled
		/// </summary>
		protected static void CacheDataTag(string key, object data)
		{
			if (data != null)
			{
				Cache.Insert(key, data, null,
				DateTime.Now.AddSeconds(6000), TimeSpan.Zero);
			}
		}
	}
}

