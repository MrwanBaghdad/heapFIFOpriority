using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapAssignment
{
    class node
    {
        public int priority;
        public int value;
        private static int counter=0;
        public int index;
        public static List<node> allNodes= new List<node>();
        public static List<node> listed = new List<node>();
        public node(int value, int p)
        {
            this.index = counter;
            counter++;
            this.value = value;
            this.priority = p;
            allNodes.Add(this);
        }
        static void maxHeapify(ref List<node> l, int i)
        {
            {
                int largest = 0;
                int left = (i + 1) * 2 - 1;
                int right = (i + 1) * 2;
                if (left < l.Count())
                {
                    if (l[left].priority > l[i].priority)
                        largest = left;
                    else if (l[left].priority == l[i].priority)
                    {
                        if (l[left].index < l[i].index)
                            largest = left;
                    }
                    else
                        largest = i;
                }
                else
                    largest = i;
                if (right < l.Count())
                {
                    if (l[right].priority > l[largest].priority)
                    {
                        largest = right;
                    }
                    else if (l[right].priority == l[largest].priority)
                    {
                        if (l[right].index < l[largest].index)
                            largest = right;
                    }
                }
                if (largest != i)
                {
                    node temp = l[largest];
                    l[largest] = l[i];
                    l[i] = temp;
                    maxHeapify(ref l, largest);
                }
            }
        }
        public static void BuildHeap()
        {
            for (int i = (allNodes.Count - 1) / 2; i >= 0; i--)
            {
                maxHeapify(ref allNodes, i);
            }
        }

        public static void heapSort()
        {
            BuildHeap();
            listed.Add(allNodes[0]);
            allNodes[0] = allNodes.Last();
            allNodes.Remove(allNodes.Last());
            if(allNodes.Count()>0)
                heapSort();
        }

    }
}
