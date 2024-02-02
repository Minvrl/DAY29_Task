using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY29.Task
{
    internal class Exam
    {
        public Exam(string subject, DateTime date)
        {
            Subject = subject;
            Date = date;    
        }
        public string Subject;
        public DateTime Date;

        public override string ToString()
        {
            return Subject + " - " + Date.ToString("dd.MM.yyyy // HH:mm" ); 
        }
    }
}
