using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    struct Worker
    {
    public Worker(int ID, DateTime Createdate, string FIO, int Age, int Height, DateTime Dateofbirth, string Placeofbirth)
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
     public string Print ()
        {
            return $"{this.ID,15}{this.Createdate,15}{this.FIO,15}{this.Age,15}{this.Height,15}{this.Dateofbirth,15}{this.Placeofbirth}";
        }

     public int ID { get { return this.ID; } set { this.ID = value; } }  
     public DateTime Createdate { get { return this.Createdate; } set { this.Createdate = value; } }
     public string FIO { get { return this.FIO; } set { this.FIO = value; } }   
     public int Age { get { return this.Age; } set { this.Age = value; } }
     public int Height { get { return this.Height; } set { this.Height = value; } } 
     public DateTime Dateofbirth { get {  return this.Dateofbirth; } set { this.Dateofbirth = value; } }
     public string Placeofbirth { get { return this.Placeofbirth; } set { this.Placeofbirth = value; } }

       
    }
}
