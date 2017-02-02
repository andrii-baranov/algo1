
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core
{
    public class SimpleHashTable : IHashTable
    {
        private const int _hashDenominator = 256;
        private List<Tuple<string, string>>[] _tables;

        public SimpleHashTable()
        {
            _tables = new List<Tuple<string, string>>[_hashDenominator];
        }

        private int GetHashCode(string valueToHash)
        {
            int length = valueToHash.Length;
            int code = length;

            for (int i = 0; i <length; i++)
            {
                char c = valueToHash[i];

                code ^= c;
            }

            return code;
        }

        public bool HasKey(string key)
        {
            int hashCode = GetHashCode(key);

            var hashRow = _tables[hashCode];

            if (hashRow == null || hashRow.Count == 0)
            {
                return false;
            }

            var list = hashRow;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 == key)
                {
                    return true;
                }
            }

            return false;

        }

        public string Get(string key)
        {
            int hashCode = GetHashCode(key);

            var hashRow = _tables[hashCode];

            if (hashRow == null || hashRow.Count == 0)
            {
                return null;
            }

            var list = hashRow;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 == key)
                {
                    return list[i].Item2;
                }
            }

            return null;
        }

        public void Add(string keyValue, string value)
        {
            int hashCode = GetHashCode(keyValue);

            var hashRow = _tables[hashCode];

            if (hashRow == null)
            {
                hashRow = new List<Tuple<string, string>>();
                _tables[hashCode] = hashRow;
            }

            var index = hashRow.FindIndex(item => item.Item1 == keyValue);

            if (index == -1)
            {
                hashRow.Add(new Tuple<string, string>(keyValue, value));
            }
            else
            {
                hashRow[index] = new Tuple<string, string>(keyValue, value);
            }
        }

        public void Remove(string key)
        {
            int hashCode = GetHashCode(key);

            var hashRow = _tables[hashCode];

            if (hashRow != null)
            {
                var index = hashRow.FindIndex(i => i.Item1 == key);

                if (index != -1)
                {
                    hashRow.RemoveAt(index);
                }
            }
        }
    }


    public interface IHashTable
    {
        bool HasKey(string key);

        string Get(string key);

        void Add(string key, string value);

        void Remove(string key);
    }
}
