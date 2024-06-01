using System;
using System.Xml.Linq;


namespace Task7_1
{
    struct Worker
    {
        public Worker(uint ID, DateTime Createdate, string FIO, byte Age, int Height, DateTime Dateofbirth, string Placeofbirth)
        {
            ///summary> Пояснения переменных
            /// <param name = "ID">  Уникальный номер сотрудника</param>
            /// <param name = "Createdate"> Дата и время создания записи</param> 
            /// <parame name = "FIO"> ФИО сотрудника </param> 
            /// <param name = "Age"> возраст <param>
            /// <param name = "Height"> рост(очень дотошный работодатель...) </param>
            ///<param name = "Dateofbirth"> Дата рождения </param> 
            ///<param name = "Placeofbirth"> Место рождения </param> 
            this.ID = ID;
            this.Createdate = Createdate;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.Dateofbirth = Dateofbirth;
            this.Placeofbirth = Placeofbirth;
        }
        public string Printconsole()
        {
            return $"{this.ID}\t{this.Createdate}\t{this.FIO}\t{this.Age}\t{this.Height}" +
                $"\t{this.Dateofbirth:dd.MM.yyyy}\t{this.Placeofbirth}";
        }
        public string Printtofile()
        {
            return $"{this.ID}#{this.Createdate}#{this.FIO}#{this.Age}#{this.Height}" +
                $"#{this.Dateofbirth:dd.MM.yyyy}#{this.Placeofbirth}";
        }
        public uint ID { get; set; }
        public DateTime Createdate { get; set; }
        public string FIO { get; set; }
        public byte Age { get; set; }
        public int Height { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Placeofbirth { get; set; }

    }

}
