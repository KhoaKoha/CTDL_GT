using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _20880037
{
     class ReadWriteHandle
    {
        public const string HexFilePath = "..//..//..//dataFolder//hex_numbers.txt";
        public const string SortedFilePath = "..//..//..//dataFolder//sorted_numbers.txt";
        public const string OddNumberFilePath = "..//..//..//dataFolder//odd_queue.txt";
        public const string EvenNumberFilePath = "..//..//..//dataFolder//even_queue.txt";

        public int[] ReadHexNumbers()
        {

            StreamReader Reader = new StreamReader(HexFilePath);
            string readAll = Reader.ReadToEnd();
            string[] splitedStr = readAll.Split(new char[] { ' ', '\t', '\n' });
            int[] result = new int[splitedStr.Length];
            for (int i = 0; i < splitedStr.Length; i++)
            {
                result[i] = int.Parse(splitedStr[i], System.Globalization.NumberStyles.HexNumber);
            }
            Reader.Close();
            return result;

        }

        public void ReadOriginalFile() {
            string[] lines = System.IO.File.ReadAllLines(HexFilePath);
            
           Console.WriteLine("Original file before converted is " + "["+ string.Join(",", lines) +"]");
            

        }
        public void ReadOddNumberFile()
        {
            string[] lines = System.IO.File.ReadAllLines(OddNumberFilePath);

            Console.WriteLine("All odd numbers " + "[" + string.Join(",", lines) + "]");


        }
        public void ReadEvenNumberFile()
        {
            string[] lines = System.IO.File.ReadAllLines(EvenNumberFilePath);

            Console.WriteLine("All even number " + "[" + string.Join(",", lines) + "]");


        }
        public void Swap(ref int firstNumber, ref int secondNumber)
        {
            int tmp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tmp;
        }
        public int[] SelectionSort(ref int[] Arr)
        {
            int minValueIndex = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                minValueIndex = i;

                for (int j = i + 1; j < Arr.Length; j++)
                {
                    if (Arr[j] < Arr[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }

                if (minValueIndex != i)
                    Swap(ref Arr[i], ref Arr[minValueIndex]);

            }
            return Arr;
        }

        public string[] WriteHexNumbers(int[] Arr)
        {

            string[] result = new string[Arr.Length];
            for (int i = 0; i < Arr.Length; i++)
            {
                result[i] = Arr[i].ToString("X2");
            }

            return result;

        }
        public void WriteConvertedToFile(string[] Arr)
        {
            StreamWriter writer = new StreamWriter(SortedFilePath);

            foreach (var num in Arr)
            {
                writer.Write(num + " ");
            }
            writer.Close();
        }
        public int RecursiveBinarySearch (int[] arr, int left, int right, int numberToFind)
        {
            if (left > right)
                return -1;
            int mid = (left + right) / 2;
            if (numberToFind == arr[mid])
                return mid;
            if (numberToFind < arr[mid])
                return RecursiveBinarySearch(arr, left, mid - 1, numberToFind);
            else
                return RecursiveBinarySearch(arr, mid + 1, right, numberToFind);
        }
        public string NumberToFindPosition(int[] arr, int numberToFind)
        {
            int index = this.RecursiveBinarySearch(arr, 0, arr.Length - 1, numberToFind);
            if (index == -1)
            {
                return " The program couldn't find the number " + numberToFind + "in the Array" ;
            }
            else
            {
                return $"The position of number to find {numberToFind} is [{index}]" + " of the Array index";
            }
        }
        public Queue GetOddNumber(int[] sorted)
        {
            Queue OddQueue = new Queue();
            foreach (var number in sorted)
            {
                if (number % 2 != 0)
                {
                    OddQueue.enqueue(number);
                }
            }
            return OddQueue;
        }

        public Queue GetEvenNumber(int[] sorted)
        {
            Queue EvenQueue = new Queue();
            foreach (var number in sorted)
            {
                if (number % 2 == 0)
                {
                    EvenQueue.enqueue(number);
                }
            }
            return EvenQueue;
        }
        public void WriteToFile(Queue queue)
        {
            QNode tmd = queue.head;
            if (queue.head.data % 2 != 0)
            {
                StreamWriter writer = new StreamWriter(OddNumberFilePath);
                while (tmd != queue.tail)
                {
                    writer.Write(queue.dequeue().data.ToString("X2") + " ");
                    tmd = tmd.next;
                }
                writer.Write(queue.dequeue().data.ToString("X2") + " ");
                writer.Close();
            }

            else
            {
                StreamWriter writer = new StreamWriter(EvenNumberFilePath);
                while (tmd != queue.tail)
                {
                    writer.Write(queue.dequeue().data.ToString("X2") + " ");
                    tmd = tmd.next;
                }
                writer.Write(queue.dequeue().data.ToString("X2") + " ");
                writer.Close();
            }

        }

        public String PrintArray(int[] Arr) {
          return (string.Join(",", Arr));
        }
    }
}

