// Fig. 21.5: LinkedListTest.cs
// Using LinkedLists.
using System;
using System.Collections.Generic;
using System.IO;

class LinkedListTest
{
   static void Main()
   {
        var list = LoadSortList();

        PrintList(list); // display list1 elements
        while (true)
        {
            Console.WriteLine("Press Enter the element to look for");
            int number;
            string read = Console.ReadLine();
            if (string.IsNullOrEmpty(read))//exit
            {
                break;
            }
            if (int.TryParse(read, out number))
            {
                LinkedListNode<int> node= list.Find(number);
                if (node != null)
                {
                    if (node.Previous == null)
                    {
                        Console.WriteLine("this node is first node");
                    }
                    else if (node.Next == null)
                    {
                        Console.WriteLine("this node is last node");
                    }
                    else
                    {
                        Console.WriteLine("previous node:" + node.Previous.Value + " and next node :" + node.Next.Value);
                    }
                }
                else
                {
                    Console.WriteLine("stating the value was not found.");
                }
                
            }
            else
            {
                Console.WriteLine("Please enter a significant number");
            }
        }
   }
    /// <summary>
    /// Load the data and sort it
    /// </summary>
    /// <returns></returns>
    private static LinkedList<int> LoadSortList()
    {
        //display member
        string path =AppDomain.CurrentDomain.BaseDirectory+ @"\number.txt";
        StreamReader sr = new StreamReader(path);
        string line;
        string[] numbers;
        int number;
        LinkedList<int> list = new LinkedList<int>();
        while ((line = sr.ReadLine()) != null)
        {
            numbers = line.Split(',');
            list.AddFirst(int.Parse(numbers[0]));
            for (int i = 1; i < numbers.Length; i++)
            {
                number = int.Parse(numbers[i]);
                foreach (var item in list)
                {
                    if (item > number)
                    {
                        LinkedListNode<int> currentnode = list.Find(item);  //Find the location of the item element
                        list.AddBefore(currentnode, number);
                        break;
                    }
                }
                if (i == list.Count)
                {
                    list.AddLast(number);
                }
            }
        }
        //close file
        sr.Close();
        return list;
    }
   // display list contents
   private static void PrintList<T>(LinkedList<T> list)
   {
      Console.WriteLine("Linked list: ");

      foreach (var item in list)
      {
         Console.Write($"{item} ");
      }

      Console.WriteLine();
   }
}

