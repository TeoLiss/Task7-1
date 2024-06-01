using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Task7_1
{
    internal class Repository
    {
        static string Filename = "Справочник сотрудников.txt";

        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
            if (File.Exists(Filename))
            {
                // открыли поток на чтение
                using (StreamReader reader = new StreamReader(Filename, Encoding.UTF8))
                {
                    // весь текст из файла
                    string text;
                    // если в файле есть что-либо
                    if ((text = reader.ReadToEnd()) != null)
                    {
                        // массив строк прочитанного текста
                        string[] lines;
                        // переменная-счетчик
                        int numline = 0;
                        // разбиваем текст на строки
                        lines = text.Split('\r', '\n');
                        // проверяем, что все строки массива представляют из себя записи
                        // Потому что случилась новая дичь: при чтении из файла с помощью метода ReadToEnd
                        // (который используется, потому что нельзя понять, какого размера массив создать,
                        // сначала нужно определить его размер исходя из содержимого файла)
                        // или не из-за этого метода.. В любом случае, считывается якобы пустая строка.
                        // Чтобы из-за нее прога не ломалась, нужна проверка.
                        // Например, что в строке есть #. Если в строке вообще нет такого символа - явно, что такая строка нам нужна.
                        // Значит, считываем все адекватные строки до пустой (кривой, косой, не того формата, в общем).
                        // Вернее, определяем, сколько строк нам нужно занести в массив.
                        foreach (string line in lines)
                        {
                            // Если искомый символ # найден
                            if (line.Contains('#'))
                                numline++;
                        }
                        Worker[] workers = new Worker[numline];

                        // обнуляем счетчик
                        numline = 0;
                        // для каждой строки в массиве строк
                        foreach (string line in lines)
                        {
                            // еще одна проверка
                            if (line.Length > 0)
                            {
                                // парсим строку на части
                                string[] part = line.Split('#');
                                // создаем Worker и заносим туда распарсенные части
                                Worker wr = new Worker(Convert.ToUInt32(part[0]), Convert.ToDateTime(part[1]),
                                    part[2], Convert.ToByte(part[3]),
                                    Convert.ToInt32(part[4]), Convert.ToDateTime(part[5]), part[6]);
                                // добавляем в массив Worker по индексу-счетчику нового работника

                                workers[numline] = wr;
                                numline++;
                            }
                        }
                        // все строки перебраны, все работники созданы, возвращаем их обратно
                        return workers;
                    }

                }
            }
            else File.Create(Filename);
            // в данной ветке файла нет, поэтому и работников тоже, поэтому возвращаем пустоту
            return null;
        }

        private void Writefile(Worker[] wrt)
        {
            using (StreamWriter writer = new StreamWriter(Filename))
            {
                foreach (Worker w in wrt)
                {
                    writer.WriteLine(w.Printtofile());
                }

            }
        }

        public Worker? GetWorkerById(uint id)
        //знак вопроса в объявлении типа объекта нужен для возможности сравнения с null с версией 8.0
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker[] workers = GetAllWorkers();
            //Worker vasya1 = new Worker();
            foreach (Worker w in workers)
            {
                if (w.ID == id)
                {
                    return w;
                }
            }
            return null;
        }

        public void DeleteWorker(uint id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
            Worker[] Wrtodelete = GetAllWorkers();
            bool wrdelFlag = false;
            foreach (Worker wdel in Wrtodelete)
            {
                if (wdel.ID == id)
                {
                    wrdelFlag = true;
                }
            }
            if (wrdelFlag)
            {
                Worker[] WorkerNew = new Worker[Wrtodelete.Length - 1];
                int wdelCounter = 0;
                foreach (Worker wdel in Wrtodelete)
                {
                    if (wdel.ID != id)
                    {
                        WorkerNew[wdelCounter] = wdel;
                        wdelCounter++;
                    }
                }
                Writefile(WorkerNew);
                Console.WriteLine($"Сотрудник с ID={id} удален! Гори в аду Вася №{id}");
            }
            else Console.WriteLine($"Сотрудника с ID={id} неть. Удалить не получилось :(");


        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            Worker[] wadd = GetAllWorkers();
            uint newid = 0;
            if (wadd.Length != 0)
                newid = wadd[wadd.Length - 1].ID + 1;
            worker.ID = newid;
            worker.Createdate = DateTime.Now;
            Worker[] wadd2 = new Worker[wadd.Length + 1];
            for (int i = 0; i < wadd.Length; i++)
                wadd2[i] = wadd[i];
            wadd2[wadd2.Length - 1] = worker;
            Writefile(wadd2);
        }
        public void Printconsole(Worker[] workers)
        {
            if (workers != null)
            {
                foreach (Worker w in workers)
                {
                    //w.Printconsole(); этот метод возвращает строковое значение, а дальше тут мы его используем
                    Console.WriteLine(w.Printconsole());
                }
            }
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
            Worker[] gw = GetAllWorkers();
            Worker[] tempgw = new Worker[gw.Length];
            int countergw = 0;
            foreach (Worker wgw in gw)
            {
                if (wgw.Createdate >= dateFrom && wgw.Createdate < dateTo.AddDays(1))
                {
                    tempgw[countergw] = wgw;
                    countergw++;
                }
            }
            if (countergw > 0)
            {
                Console.WriteLine("Фильтрация по датам прошла успешно:");
                Worker[] gwNew = new Worker[countergw];
                for (int i = 0; i < (countergw); i++)
                {
                    gwNew[i] = tempgw[i];
                }
                return gwNew;
            }
            else
            {
                Console.WriteLine("Записей за выбранный период нет!");
                return null;
            }

        }


    }
}
