using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20880037
{
    class Queue
    {
        public Node head;
        public Node tail;
        public Queue()
        {
            head = null;
            tail = null;
        }
        public void Push(int value)
        {
            Node tmp = new Node(value);
            if (head == null)
            {
                head = tail = tmp;
            }
            tail.next = tmp;
            tail = tmp;
        }
        public Node Pop()
        {
            if (head == null)
                return null;
            var tmp = head;
            head = head.next;
            if (head == null)
                tail = null;
            return tmp;
        }
        public bool IsEmty()
        {
            if (head == null)
                return true;
            else return false;

        }
    }
}



