using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                new node(r.Next(0,100), r.Next(0, 3));
            }
            foreach (node n in node.allNodes)
            {
                Console.WriteLine("{0},{1}",n.value,n.priority);
            }
            node.heapSort();
            Console.WriteLine("....");
            foreach (node n in node.listed)
            {
                Console.WriteLine("{0},{1}",n.value,n.priority);
            };
            Console.ReadLine();
        }
        static void maxHeapify(ref int[] arr, int i)
        {
            {
                int largest=0;
                int left= (i+1)*2 -1 ;
                int right=(i+1)*2;
                if (left < arr.Length )
                {
                    if (arr[left] > arr[i])
                        largest = left;
                    else
                        largest = i;
                }
                else
                    largest = i;
                if (right < arr.Length)
                {
                    if (arr[right] > arr[largest])
                        largest = right;
                }
                if (largest != i)
                {
                    int temp = arr[largest];
                    arr[largest] = arr[i];
                    arr[i] = temp;
                    maxHeapify(ref arr, largest);
                }
            }
        }
    }
    
}
