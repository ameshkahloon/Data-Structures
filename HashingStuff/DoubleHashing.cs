using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HashingStuff
{
    public class DoubleHashing
    {
        private string[] hashtable;
        private int cellsUsedInHashTable;

        public DoubleHashing(int size)
        {
            this.hashtable = new string[size];
            this.cellsUsedInHashTable = 0;
        }

        public int SimpleASCIIHashFunction(string str, int mod)
        {
            char[] ch = str.ToCharArray();
            int sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                sum += ch[i];
            }// end for loop
            return sum % mod;
        }

        int SecondHashFunction(string str, int mod)
        {
            char[] ch = str.ToCharArray();
            int length = str.Length;
            int sum = 0;
            for(int i = 0; i < length; i++)
            {
                sum += ch[i];
            }// end for loop
            while(sum > hashtable.Length)
            {
                sum = AddAllDigitsTogether(sum);
            }// end while loop
            return sum % mod;
        }

        int AddAllDigitsTogether(int sum)
        {
            int value = 0;
            while(sum > 0)
            {
                value = sum % 10;
                sum = sum / 10;
            }// end while loop
            return value;
        }

        public double GetLoadFactor()
        {
            return cellsUsedInHashTable / hashtable.Length;
        }

        public void InsertKeyInHashTable(string str)
        {
            double loadFactor = GetLoadFactor();
            if(loadFactor >= 0.75)
            {
                ReHashKeys(str);
            }// end if
            else
            {
                int x = SimpleASCIIHashFunction(str, hashtable.Length);
                int y = SecondHashFunction(str, hashtable.Length);
                for(int i = 0; i < hashtable.Length; i++)
                {
                    int newIndex = (x + i * y) % hashtable.Length;
                    if(hashtable[newIndex] == null)
                    {
                        hashtable[newIndex] = str;
                        break;
                    }// end if
                }// end for loop
            }// end else
            cellsUsedInHashTable++;
        }

        public void ReHashKeys(string newStringToBeInserted)
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
            foreach(string str in data)
            {
                InsertKeyInHashTable(str);
            }// end foreach loop
        }

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
        }

        public void DeleteKeyFromHashTable(string stringToBeDeleted)
        {
            int index = SimpleASCIIHashFunction(stringToBeDeleted, hashtable.Length);
            for(int i = index; i < index+hashtable.Length; i++)
            {
                int newIndex = i % hashtable.Length;
                if(hashtable[newIndex] != null && hashtable[newIndex].Equals(stringToBeDeleted))
                {
                    hashtable[newIndex] = null;
                    Console.WriteLine("The key {0} in the hashtable has been deleted", stringToBeDeleted);
                    return;
                }// end if
            }// end for loop
            Console.WriteLine("Could not find the key {0} to delete in the hashtable", stringToBeDeleted);
        }

        public void DisplayHashTable()
        {
            if (hashtable == null)
            {
                Console.WriteLine("Hashtable does not exist");
                return;
            }//end if
            else
            {
                Console.WriteLine("\n---------- HashTable ---------");
                for (int i = 0; i < hashtable.Length; i++)
                {
                    Console.WriteLine("Index: {0} . Key: {1}", i, hashtable[i]);
                }// end for loop
            }// end else
            Console.WriteLine("\n");
        }// end of method

        public void DeleteHashTable()
        {
            hashtable = null;
            Console.WriteLine("Hashtable has been deleted");
        }
    }
}
