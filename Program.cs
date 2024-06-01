using System;


namespace Task7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Введите 1 - чтобы показать список рабочих");
                Console.WriteLine("Введите 2 - чтобы найти рабочего по ID");
                Console.WriteLine("Введите 3 - чтобы создать запись");
                Console.WriteLine("Введите 4 - чтобы удалить запись");
                Console.WriteLine("Введите 5 - чтобы открыть записи за выбранный период времени");
                Console.WriteLine("Введите 0 - чтобы завершить программу");
                consoleKeyInfo = Console.ReadKey();
                Repository rep = new Repository();
                Console.WriteLine();
                switch (consoleKeyInfo.KeyChar)
                {
                    case '0':
                        break;
                    case '1':
                        Worker[] worwor = rep.GetAllWorkers();
                        rep.Printconsole(worwor);
                        break;
                    case '2':
                        Console.WriteLine("Введите ID для поиска:");
                        uint wrid = Convert.ToUInt32(Console.ReadLine());
                        Worker? findwrid = rep.GetWorkerById(wrid);
                        if (object.ReferenceEquals(findwrid, null))
                        {
                            Console.WriteLine($"Сотрудника с ID= {wrid} не существует");
                        }
                        else
                            Console.WriteLine(findwrid?.Printconsole());

                        break;
                    case '3':
                        Worker newW = new Worker();
                        Console.WriteLine("Введите ФИО нового сотрудника:");
                        newW.FIO = Console.ReadLine();
                        Console.WriteLine("Введите возраст нового сотрудника:");
                        newW.Age = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("Введите рост нового сотрудника:");
                        newW.Height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите дату рождения нового сотрудника:");
                        newW.Dateofbirth = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Введите место рождения нового сотрудника:");
                        newW.Placeofbirth = Console.ReadLine();
                        rep.AddWorker(newW);
                        break;
                    case '4':
                        Console.WriteLine("Введите ID удаляемого сотрудника:");
                        uint wriddel = Convert.ToUInt32(Console.ReadLine());
                        rep.DeleteWorker(wriddel);
                        break;
                    case '5':
                        Console.WriteLine("Введите диапазон дат создания записей для поиска сотрудников. \nПервая дата:");
                        DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Вторая дата:");
                        DateTime dateTo = Convert.ToDateTime(Console.ReadLine());
                        rep.Printconsole(rep.GetWorkersBetweenTwoDates(dateFrom, dateTo));
                        break;
                    default:
                        Console.WriteLine("Неизвестный пункт меню");
                        break;
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.D0);



        }
    }
}
