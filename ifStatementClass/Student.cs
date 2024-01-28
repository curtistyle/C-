using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifStatementClass
{
    class Student
    {
        public string Name {  get; set; } // propiedad
        private int average; // variable de instancia 
        
        // El constructor inicializa las propiedades 'name' y 'average'.
        public Student(string studentName, int studentAverage) 
        { 
            Name = studentName;
            Average = studentAverage;  // establece la variable de instancia de 'average' (promedio)
        }

       // propiedad para obtener o establecer el promedio de la variable de instancia
        public int Average
        {
            get // retorna el promedio del estudiante
            { return average; }
            set // establece el promedio del estudiante
            {   
                // valida si 'value' esta entre 0 .. 100, de lo contrario, mantiene el valor actual 'average'
                // de la variable de instancia
                if (value > 0)
                {
                    if (average <= 100)
                    {
                        average = value;
                    }
                }
            }
        }

        // retorna la calificacion del estudiante basada en el promedio
        public string LetterGrade
        {
            get
            {
                string letterGrade = string.Empty;

                if (average >= 90)
                {
                    letterGrade = "A";
                }
                else if (average >= 80)
                {
                    letterGrade = "B";
                }
                else if (average >= 70)
                {
                    letterGrade = "C";
                }
                else if(average >= 60)
                {
                    letterGrade = "D";
                }
                else
                {
                    letterGrade = "F";
                }

                return  letterGrade;
            }
        }
            

    }
}
