using PubComp.Caching.AopCaching;

namespace ClassLibrary
{
    public class HashCodeCalulator
    {
        [Cache("MyCacheName")]
        public int GetHashCode(string key)
        {
            return Get(key);
        }

        private int Get(string key)
        {
            return key.GetHashCode();
        }
    }
}