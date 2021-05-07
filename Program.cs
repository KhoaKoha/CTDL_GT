using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20880037

{
    class Program
    {
        static void Main(string[] args)
        {

           

            ReadWriteHandle ReadWrite = new ReadWriteHandle();
            Console.WriteLine("Beging to read original file");
            ReadWrite.ReadOriginalFile();
            Console.WriteLine("Begin to convert original file to decimal");
            int[] readResult = ReadWrite.ReadHexNumbers();
            Console.WriteLine("Result Hex array after conveted to Decimal is " + "[" + ReadWrite.PrintArray(readResult) + "]");
            Console.WriteLine("Begin to sort converted decimal array");
            int[] sortedResult = ReadWrite.SelectionSort(ref readResult);
            Console.WriteLine("Sorted Decimal array is " + "[" + ReadWrite.PrintArray(sortedResult) + "]");
            Console.WriteLine("Begin to write sorted Array into a file");
            string[] hexArr = ReadWrite.WriteHexNumbers(sortedResult);
            Console.WriteLine("Converted Hex array is " + "[" + (String.Join(",", hexArr)) + "]");
            Console.WriteLine("Begin to write converted Hex array into a file ");
            ReadWrite.WriteConvertedToFile(hexArr);
            Console.WriteLine("Successfully write converted Hex array into sorted_numbers.txt");
            int x = int.Parse(args[0]);
            Console.WriteLine("The number to search for in the sorted Array is " + x);
            string numberPosition = ReadWrite.NumberToFindPosition(sortedResult, x);
            Console.WriteLine(numberPosition);
            Queue OddNumberList = ReadWrite.GetOddNumber(sortedResult);
            Console.WriteLine("Begin to write odd number into a file ");
            ReadWrite.WriteToFile(OddNumberList);
            Console.WriteLine("Successfully write odd number Hex into sorted_numbers.txt");
            ReadWrite.ReadOddNumberFile();
            Queue EvenNumberList = ReadWrite.GetEvenNumber(sortedResult);
            Console.WriteLine("Begin to write even number into a file ");
            ReadWrite.WriteToFile(EvenNumberList);
            Console.WriteLine("Successfully write even number Hex into sorted_numbers.txt");
            ReadWrite.ReadEvenNumberFile();
            Console.ReadKey();
        }
    }
}
