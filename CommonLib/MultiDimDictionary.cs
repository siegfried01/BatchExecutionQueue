using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class Dictionary<K, V> : System.Collections.Generic.Dictionary<K, V> where V : new()
    {
        public V this[K k]
        {
            get
            {
                if (base.Keys.Contains(k))
                {
                    return base[k];
                }
                else
                {
                    var v = new V();
                    base.Add(k, v);
                    return v;
                }
            }
            set
            {
                base[k] = value;
            }
        }
    }
}
