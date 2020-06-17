
using System;
using System.IO;

namespace Lab62
{
    interface ICourse
    {
        void Edit();
        void Delete();
    }

    public abstract class STOCK: ICourse
    {
        public string Company;
        public string Code;
        public string date;
        public string opencourse;
        public string closingrate;

        public string company
        {
            get { return Company; }
            set { Company = value; }
        }

        public string code
        {
            get { return Code; }
            set { Code = value; }
        }

        public static string Checkdate(string date)
        {
            DateTime dateTime;
            while (!DateTime.TryParse(date, out dateTime))
            {
                Console.Write("Дата(дд.мм.рр):");
                date = Console.ReadLine();
            }

            dateTime = Convert.ToDateTime(date);
            date = dateTime.ToShortDateString();
            return date;
        }



        public void Add(string company, string code, string date, string opencourse, string closingrate)
        {

            Console.WriteLine(
                "\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt",
                    true))
                    f.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", company, code, date, opencourse,
                        closingrate);
                Console.WriteLine("Змiни збережено\n");
            }
            else
            {
                Console.WriteLine("\nЗмiни не збережено\n");
            }


        }

        public static int Checknum(string number1)
        {
            int result = 0;
            while (!int.TryParse(number1, out result))
            {
                Console.Write("Введіть номер ще раз:");
                number1 = Console.ReadLine();
            }

            result = Convert.ToInt32(number1);
            return result;
        }


        public abstract void Edit();


        public abstract void Delete();

        public void Output()
        {
            int length = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt").Length;
            string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", "Назва компанії", "Код", "Дата", "курс відкриття",
                "курс закриття");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(str[i]);
            }
        }
    }

    public class Rate : STOCK
    {
        private string Date;
        private string Opencourse;
        private string Closingrate;

        public string date
        {
            get { return Date; }
            set { Date = value; }
        }

        public string opencourse
        {
            get { return Opencourse; }
            set { Opencourse = value; }
        }

        public string closingrate
        {
            get { return Closingrate; }
            set { Closingrate = value; }
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Rate cw = new Rate();
            while (true)
            {
                Console.WriteLine("\nВибір режиму роботи: ");
                Console.WriteLine("Додавання записiв - Q");
                Console.WriteLine("Редагування записiв - W");
                Console.WriteLine("Знищення записiв - E");
                Console.WriteLine("Виведення iнформацiї з файла на екран - R");
                ConsoleKeyInfo c;
                c = Console.ReadKey(true);
                if (c.Key == ConsoleKey.Q)
                {
                    Rate add = new Rate();
                    Console.WriteLine("Назву компанiї :");
                    string company = Console.ReadLine();
                    while (string.IsNullOrEmpty(company))
                    {
                        Console.WriteLine("Введіть назву компанiї ще раз:");
                        company = Console.ReadLine();
                    }
                    add.Company = company;
                    Console.WriteLine("Введіть код на бiржi:");
                    string code = Console.ReadLine();
                    while (string.IsNullOrEmpty(code))
                    {
                        Console.WriteLine("Введіть код на бiржi ще раз:");
                        code = Console.ReadLine();
                    }

                    add.code = code;
                    Console.WriteLine("Введіть дату:");
                    string date = Console.ReadLine();
                    add.date = STOCK.Checkdate(date);
                    Console.WriteLine("Введіть курс відкриття:");
                    string openate = Console.ReadLine();
                    while (string.IsNullOrEmpty(openate))
                    {
                        Console.WriteLine("Введіть курс закриття ще раз:");
                        openate = Console.ReadLine();
                    }
                    add.opencourse = openate;
                    Console.WriteLine("Введіть курс закриття:");
                    string closingrate = Console.ReadLine();
                    while (string.IsNullOrEmpty(closingrate))
                    {
                        Console.WriteLine("Введіть курс закриття ще раз:");
                        closingrate = Console.ReadLine();
                    }

                    add.closingrate = closingrate;
                    cw.Add(company,code,date, openate,closingrate);
                }

                if (c.Key == ConsoleKey.W)
                {
                    Rate edit = new Rate();
                    int length = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt").Length;
                    Console.WriteLine("Номер рядку:");
                    int number = STOCK.Checknum(Console.ReadLine());
                    while (number > length || number <= 0)
                    {
                        Console.WriteLine("Номер рядку не може бути менше нуля або більше " + length);
                        number = STOCK.Checknum(Console.ReadLine());
                    }

                    string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt");
                    string line = str[number - 1];
                    edit.Company = line.Substring(0, 19);
                    edit.code = line.Substring(20, 19);
                    edit.date = line.Substring(40, 19);
                    edit.opencourse = line.Substring(60, 19);
                    edit.closingrate = line.Substring(80, 19);
                    Console.WriteLine("Введiть номер елементу стовпчика, який потрібно змінити: ");
                    int number1 = STOCK.Checknum(Console.ReadLine());
                    while (number1 > 5 || number1 <= 0)
                    {
                        Console.WriteLine("Номер стовпчика не може бути менше нуля або більше п'яти");
                        number1 = STOCK.Checknum(Console.ReadLine());
                    }

                    if (number1 == 1)
                    {
                        Console.WriteLine("Введіть назву компанії:");
                        string company = Console.ReadLine();
                        while (string.IsNullOrEmpty(company))
                        {
                            Console.WriteLine("Введіть назву компанії ще раз:");
                            company = Console.ReadLine();
                        }

                        edit.Company = company;
                    }

                    if (number1 == 2)
                    {
                        Console.WriteLine("Введіть код:");
                        string code = Console.ReadLine();
                        while (string.IsNullOrEmpty(code))
                        {
                            Console.WriteLine("Введіть код ще раз:");
                            code = Console.ReadLine();
                        }

                        edit.code = code;
                    }

                    if (number1 == 3)
                    {
                        Console.WriteLine("Введіть дату:");
                        string date = Console.ReadLine();
                        edit.date = STOCK.Checkdate(date);
                    }

                    if (number1 == 4)
                    {
                        Console.WriteLine("Введіть курс відкриття:");
                        string opencourse = Console.ReadLine();
                        while (string.IsNullOrEmpty(opencourse))
                        {
                            Console.WriteLine("Введіть курс закриття:");
                            opencourse = Console.ReadLine();
                        }

                        edit.opencourse = opencourse;
                    }

                    if (number1 == 5)
                    {
                        Console.WriteLine("Введіть курс закриття:");
                        string closingrate = Console.ReadLine();
                        while (string.IsNullOrEmpty(closingrate))
                        {
                            Console.WriteLine("Введіть курс закриття:");
                            closingrate = Console.ReadLine();
                        }

                        edit.closingrate = closingrate;
                    }

                    Console.WriteLine("\nЗбереження змін - Enter, відміна - будь-яка інша клавіша.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt"))
                            for (int i = 0; i < length; i++)
                            {
                                if (i != number - 1) f.WriteLine(str[i]);
                                else
                                    f.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", edit.Company, edit.code,
                                        edit.date,
                                        edit.opencourse, edit.closingrate);
                            }

                        Console.WriteLine("Змiни збережено\n");
                    }
                    else
                    {
                        Console.WriteLine("\nЗмiни не збережено\n");
                    }

                    cw.Edit();
                }

                if (c.Key == ConsoleKey.E)
                {
                    int length = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt").Length;
                    Console.WriteLine("Номер рядку:");
                    int number = STOCK.Checknum(Console.ReadLine());
                    while (number > length || number <= 0)
                    {
                        Console.WriteLine("Номер рядку не може бути менше нуля або більше " + (length));
                        number = STOCK.Checknum(Console.ReadLine());
                    }

                    string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt");
                    Console.WriteLine("\nЗбереження змін - Enter, відміна - будь-яка інша клавіша.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab62\\STOCK.txt"))
                            for (int i = 0; i < length; i++)
                            {
                                if (i != number - 1) f.WriteLine(str[i]);
                            }

                        Console.WriteLine("Змiни збережено\n");
                    }
                    else
                    {
                        Console.WriteLine("\nЗмiни не збережено\n");
                    }
                    cw.Delete();
                }

                if (c.Key == ConsoleKey.R)
                {
                    cw.Output();
                }

            }
        }

    }
}