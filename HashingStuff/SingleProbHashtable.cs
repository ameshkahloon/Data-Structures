using System;
using System.Collections.Generic;

namespace HashingStuff
{
    public class LinearProbHashtable
    {
        private string[] hashtable;
        private int cellsUsedInHashTable;
        public LinearProbHashtable(int size)
        {
            this.hashtable = new string[size];
        }

        public int SimpleASCIIHashFunction(string str, int mod)
        {
            char[] ch;
            ch = str.ToCharArray();
            int sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                sum += ch[i];
            }// end for loop
            return sum % mod;
        }

        public double LoadFactor()
        {
            return cellsUsedInHashTable / hashtable.Length;
        }

        public void InsertKeyInHashTable(string value)
        {
            double loadFactor = LoadFactor();
            if(loadFactor >= 0.75)
            {
                ReHashKeys(value);
            }// end if
            else
            {
                int index = SimpleASCIIHashFunction(value, hashtable.Length);
                for(int i = index; i < index + hashtable.Length; i++)
                {
                    int newIndex = i % hashtable.Length;
                    if(hashtable[newIndex] == null)
                    {
                        hashtable[newIndex] = value;
                        break;
                    }// end if
                }// end for loop
            }// end else
            cellsUsedInHashTable++;
        }

        public void ReHashKeys(string str)
        {
            cellsUsedInHashTable = 0;
            List<string> data = new List<string>();
            foreach(string s in hashtable)
            {
                if(s != null)
                {
                    data.Add(s);
                }// end if
            }// end foreach loop
            data.Add(str);
            hashtable = new string[hashtable.Length * 2];
            foreach(string s in data)
            {
                InsertKeyInHashTable(s);
            }// end foreach loop
        }// end method

        public bool SearchKeyInHashTable(string strSearched)
        {
            int index = SimpleASCIIHashFunction(strSearched, hashtable.Length);
            for(int i = index; i < index + hashtable.Length; i++)
            {
                int newIndex = i % hashtable.Length;
                if (hashtable[newIndex] != null && hashtable[newIndex].Equals(strSearched))
                {
                    return true;
                }// end if
            }// end for loop
            return false;
        }

        public void DeleteKeyFromHashTable(string stringToBeDeleted)
        {
            int index = SimpleASCIIHashFunction(stringToBeDeleted, hashtable.Length);
            for (int i = index; i < index + hashtable.Length; i++)
            {
                int newIndex = i % hashtable.Length;
                if (hashtable[newIndex] != null && hashtable[newIndex].Equals(stringToBeDeleted))
                {
                    hashtable[newIndex] = null;
                    return;
                }// end if
            }// end for loop
        }

        public void DisplayHashTable()
        {
            if (hashtable == null)
            {
                Console.WriteLine("\nHashTable does not exits !");
                return;
            }// end if
            else
            {
                Console.WriteLine("\n---------- HashTable ---------");
                for (int i = 0; i < hashtable.Length; i++)
                {
                    Console.WriteLine("Index:" + i + ".   Key:" + hashtable[i]);
                }// end for loop
            }// end else
        }

        public void DeleteHastTable()
        {
            hashtable = null;
            Console.WriteLine("Hashtable has been deleted");
        }
    }
}
