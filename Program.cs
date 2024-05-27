using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Menu()
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
                    Console.WriteLine();

                    switch (consoleKeyInfo.KeyChar)
                    {
                        case '0':
                            break;
                        case '1':
                            Worker[] GetAllWorkers(); //как тут этот метод-то вызвать?
                            break;
                        case '2':
                            Worker GetWorkerById(); //аналогично
                        case '3':
                            Worker AddWorker(); //и тут
                            break;
                        case '4':
                            Worker DeleteWorker(); //тут тоже
                        case '5':
                            Worker[] GetWorkersBetweenTwoDates(); // аналогично
                        default:
                            Console.WriteLine("Неизвестный пункт меню");
                            break;
                    }
                }
                while (consoleKeyInfo.Key != ConsoleKey.D0);
            }
            
            }
    }
}
