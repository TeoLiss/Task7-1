using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    internal class Repository
    {
        

        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
            using (StreamReader sr = new.StreamReader(@"Работники.csv, Encoding.Unicode"))
            {
                string[] lines = sr.ReadLine().Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker();
                Console.WriteLine($"{worker,50}");
            }
            }
           
                    

            
        }

        public Worker GetWorkerById(int ID)
        {
        // происходит чтение из файла, возвращается Worker
        // с запрашиваемым ID
        using (StreamReader sr = new.StreamReader(@"Работники.csv", Encoding.Unicode))
        {
            string workers = new.Worker(); //КАКОЙ СПИСОК АРГУМЕНТОВ? ЧЕ ОН ХОЧЕТ?
            workers.OrderBy(w => w.ID); //Какой char??? Какой метод расширения... че
            Console.WriteLine(workers.ToString());
        }
    }

        public void DeleteWorker(int ID)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
        }

        public void AddWorker(Worker worker)
        {
        // присваиваем worker уникальный ID,
        // дописываем нового worker в файл
        using (StreamWriter sw = new.StreamWriter(@"Работники.csv", Encoding.Unicode))
        {
            string[] worker = worker.ToString().Split(new char[] { '#' });
        }
        
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
        // здесь происходит чтение из файла
        // фильтрация нужных записей
        // и возврат массива считанных экземпляров
        using (StreamReader sr = new.StreamReader(@"Работники.csv", Encoding.Unicode))
        {
            DateTime.dateFrom = dateFrom;
            DataTime.dateTo = dateTo;
            IComparable[] dates = sr.ReadLine().Split('#');
            Console.WriteLine(//ЧТО-нибудь выведи мне плиз);

        }
    }
    }
}
