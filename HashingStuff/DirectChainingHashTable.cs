using System;
using System.Collections.Generic;

namespace HashingStuff
{
    public class DirectChainingHashTable
    {
        LinkedList<string>[] hashTable;

        public DirectChainingHashTable(int size)
        {
            hashTable = new LinkedList<string>[size];
        }

        public int SimpleASCIIHashFunction(string str, int mod)
        {
            char[] ch = str.ToCharArray();
            int i, sum;
            for (sum = 0, i = 0; i < str.Length; i++)
            {
                sum = sum + ch[i];
            }// end for loop
            return sum % mod;
        }

        public void InsertKeyInHashTable(string value)
        {
            int newIndex = SimpleASCIIHashFunction(value, hashTable.Length);
            if (hashTable[newIndex] == null)
            {
                hashTable[newIndex] = new LinkedList<string>();
                hashTable[newIndex].AddFirst(value);
            }// end if
            else
            {
                hashTable[newIndex].AddLast(value);
            }// end else
        }

        public bool SearchKeyInHashTable(string stringToBeSearched)
        {
            int newIndex = SimpleASCIIHashFunction(stringToBeSearched, hashTable.Length);
            if (hashTable[newIndex] != null && hashTable[newIndex].Contains(stringToBeSearched))
            {
                return true;
            }// end if
            else
            { 
                return false;
            }// end else
        }

        public void DeleteKeyFromHashTable(string stringToBeDeleted)
        {
            int newIndex = SimpleASCIIHashFunction(stringToBeDeleted, hashTable.Length);
            if (hashTable[newIndex] != null && hashTable[newIndex].Contains(stringToBeDeleted))
            {
                hashTable[newIndex].Remove(stringToBeDeleted);
            }// end if
            else
            {
                Console.WriteLine("Could not find the key {0} to delete in the hashtable", stringToBeDeleted);
            }// end else
        }

        public void DisplayHashTable()
        {
            if (hashTable == null)
            {
                Console.WriteLine("Hashtable does not exist");
                return;
            }// end if
            else
            {
                Console.WriteLine("\n---------- HashTable ---------");
                string summer = null;
                for (int i = 0; i < hashTable.Length; i++)
                {
                    if(hashTable[i] == null)
                    {
                        Console.WriteLine("Index: {0} . Key: {1}", i, null);
                    }// end if
                    else
                    {
                        var e = hashTable[i].GetEnumerator();
                        while (e.MoveNext())
                        {
                            summer += e.Current + ", ";
                        }// end while loop
                        Console.WriteLine("Index: {0} . Key: {1}", i, summer);
                        summer = null;
                        e.Dispose();
                    }// end else
                }// end for loop
            }// end else
        }

        public void DeleteHashTable()
        {
            hashTable = null;
            Console.WriteLine("Hashtable has been deleted");
        }
    }
}
