using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20880037
{
    class Queue
    {
        public QNode head;
        public QNode tail;
        public Queue()
        {
            this.head = this.tail = null;
        }
        public void enqueue(int value)
        {
            QNode tmp = new QNode(value);
            if (this.tail == null)
            {
                this.head = this.tail = tmp;
                return;
            }
            this.tail.next = tmp;
            this.tail = tmp;
        }
        public QNode dequeue()
        {
            if (this.head == null)
                return null;
            var tmp = this.head;
            this.head = this.head.next;
            if (this.head == null)
                this.tail = null;
            return tmp;
        }
        public bool IsEmty()
        {
            if (this.head == null)
                return true;
            else return false;

        }
    }
}



