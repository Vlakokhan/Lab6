using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

using System.Text;

namespace Lab61
{
    interface ILibrary
    {
        
    }

    public class Book : ILibrary
    {
        private string[] author = new string[100];
        private string[] title = new string[100];
        private string[] publication = new string[100];
        private int[] year = new int[100];
        public int length;

        public void Input()
        {
            
            Console.WriteLine("Кiлькiсть записів:"); 
            length = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
               
                Console.WriteLine("Author "+i);
                author[i] = Console.ReadLine();
                Console.WriteLine("Title "+i);
                title[i] = Console.ReadLine();
                Console.WriteLine("Publication "+i);
                publication[i] = Console.ReadLine();
                Console.WriteLine("Year "+i);
                year[i] = Int32.Parse(Console.ReadLine());
              
            }
        }

        public void Output()
        {
            Console.WriteLine($"{"Автор",-15}{"Назва книги",-15} {"Виробництво",-15} {"Рiк видання",-15}");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(author[i] +"\t"+ title[i]+"\t\t"+publication[i]+"\t\t"+year[i]);
            }

            int k = 0;
            Console.WriteLine($"{"Видавництво",-15} {"Кiлькiсть книг",-15}");
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (publication[i] == publication[j])
                    {
                        k++;
                    }
                }
            
                Console.WriteLine(publication[i]+"\t\t"+k);
                k = 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.Input();
            book.Output();
        }
    }
}
