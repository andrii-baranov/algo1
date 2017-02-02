using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class OpenAddressHashTable : IHashTable
    {
        private Tuple<string, string>[] _buckets;

        private int _denominator;

        public OpenAddressHashTable(int size = 2048)
        {
            _buckets = new Tuple<string, string>[size];

            _denominator = size;
        }

        public void Add(string key, string value)
        {
            var hash = GetHashCode(key) % (_denominator - 1);

            var mappedItem = _buckets[hash];

            if (mappedItem == null)
            {
                _buckets[hash] = new Tuple<string, string>(key, value);
            }
            else { }

            throw new NotImplementedException();
        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        private int GetHashCode(string key)
        {
            int length = key.Length;
            int code = length;

            for (int i = 0; i < length; i++)
            {
                char c = key[i];

                code ^= c;
            }

            return code;
        }
    }
}
