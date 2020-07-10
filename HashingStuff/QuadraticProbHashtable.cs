using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HashingStuff
{
    public class QuadraticProbHashtable
    {
        private string[] hashtable;
        private int cellsUsedInHashTable;

        public QuadraticProbHashtable(int size)
        {
            this.hashtable = new string[size];
        }

        public int SimpleASCIIHashFunction(string str, int mod)
        {
            char[] ch = str.ToCharArray();
            int sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                sum += ch[i];
            }// end for loop
            Console.WriteLine("The index " + sum % mod);
            return sum % mod;
        }

        public double GetLoadFactor()
        {
            return cellsUsedInHashTable / hashtable.Length;
        }

        public void InsertKeyInHashTable(string value)
        {
            double loadFactor = GetLoadFactor();
            if(loadFactor >= 0.75)
            {
                RehashKeys(value);
            }// end if
            else
            {
                int index = SimpleASCIIHashFunction(value, hashtable.Length);
                int counter = 0;
                for(int i = 0; i < index + hashtable.Length; i++)
                {
                    int newIndex = (index + counter * counter) % hashtable.Length;
                    if(hashtable[newIndex] == null)
                    {
                        hashtable[newIndex] = value;
                        break;
                    }// end if
                    counter++;
                }// end for loop
            }// end else
            cellsUsedInHashTable++;
        }// end function

        public void RehashKeys(string newStringToBeInserted)
        {
            cellsUsedInHashTable = 0;
            List<string> data = new List<string>();
            foreach(string str in hashtable)
            {
                if(str != null)
                {
                    data.Add(str);
                }// end if
            }// end foreach loop
            data.Add(newStringToBeInserted);
            hashtable = new string[hashtable.Length * 2];
            foreach(string s in data)
            {
                InsertKeyInHashTable(s);
            }// end foreach loop
        }// end method 

        public bool SearchKeyInHashTable(string stringToBeSearched)
        {
            int index = SimpleASCIIHashFunction(stringToBeSearched, hashtable.Length);
            for(int i = index; i < index + hashtable.Length; i++)
            {
                int newIndex = i % hashtable.Length;
                if(hashtable[newIndex] != null && hashtable[newIndex].Equals(stringToBeSearched))
                {
                    return true;
                }// end if
            }// end for loop
            return false;
        }// end method

        public void DeleteKeyFromHashTable(string stringToBeDeleted)
        {
            int index = SimpleASCIIHashFunction(stringToBeDeleted, hashtable.Length);
            for(int i = index; i < index + hashtable.Length; i++)
            {
                int newIndex = i % hashtable.Length;
                if(hashtable[newIndex] != null && hashtable[newIndex].Equals(stringToBeDeleted))
                {
                    hashtable[index] = null;
                    Console.WriteLine("The key {0} in the hashtable has been deleted", stringToBeDeleted);
                    return;
                }// end if
            }// end for loop
            Console.WriteLine("Could not find the key {0} to delete in the hashtable", stringToBeDeleted);
        }// end method

        public void DisplayHastTable()
        {
            if(hashtable == null)
            {
                Console.WriteLine("Hashtable does not exist");
            }// end if
            else
            {
                Console.WriteLine("\n---------- HashTable ---------");
                for(int i = 0; i < hashtable.Length; i++)
                {
                    Console.WriteLine("Index: {0} . Key: {1}", i, hashtable[i]);
                }// end for loop
            }// end else
            Console.WriteLine("\n");
        }// end method

        public void DeleteHashTable()
        {
            hashtable = null;
            Console.WriteLine("Hashtable has been deleted");
        }
    }
}
