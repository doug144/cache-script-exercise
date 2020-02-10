using PubComp.Caching.AopCaching;

namespace ClassLibrary2
{
    public class HashCodeCalulator2
    {
        [Cache("MyOtherCacheName")]
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