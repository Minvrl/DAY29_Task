using DAY29.Task;
using System.Net;

List<Exam> exams = new List<Exam>();

Exam exam1 = new Exam("Riyaziyyat",new DateTime( 2024,02,09,14,30,00));
Exam exam2 = new Exam("Biology", new DateTime( 2024,02, 07,08,00,00));
Exam exam3 = new Exam("English", new DateTime(2024, 07, 19,08,00,00));
Exam exam4 = new Exam("Programming", new DateTime(2024, 02, 27,10,45,00));
Exam exam5 = new Exam("History", new DateTime(2024, 02, 01, 09, 00, 00));
Exam exam6 = new Exam("Algebra", new DateTime(2024, 02, 13, 09, 00, 00));
Exam exam7 = new Exam("Riyaziyyat", new DateTime(2024, 03, 09, 14, 30, 00));



exams.Add(exam1);   
exams.Add(exam2);
exams.Add(exam3);
exams.Add(exam4);
exams.Add(exam5);
exams.Add(exam6);
exams.Add(exam7);   

string opt,subject,dateStr;
DateTime date;
do
{
    Console.WriteLine("\n === MENU === ");
    Console.WriteLine("1. Show all exams");
    Console.WriteLine("2. Add new exam");
    Console.WriteLine("3. Show exams that start with 'A' ");
    Console.WriteLine("4. Show passed exams");
    Console.WriteLine("5. Show exams that are in less than a month");
    Console.WriteLine("6. Show exams at 08:00");
    Console.WriteLine("7. Remove passed exams");
    Console.WriteLine("8. Check if there is a 'Riyaziyyat' exam ");
    Console.WriteLine("9. Show 'Riyaziyyat' exam");
    opt = Console.ReadLine();


    switch (opt)
    {
        case "1":
            if (exams.Count == 0) Console.WriteLine("No exams !");
            Console.WriteLine("\n === EXAMS === ");
            foreach (var exam in exams)
            {
                Console.WriteLine(exam);
            }
            break;
        case "2":
            do
            {
                Console.Write("Enter exam subject - ");
                subject = Console.ReadLine();
            } while (string.IsNullOrEmpty(subject));
            do
            {
                Console.Write("Enter exam date - ");
                dateStr = Console.ReadLine();
            } while (!DateTime.TryParse(dateStr,out date));
            Exam addingExam = new Exam(subject, date);

            exams.Add(addingExam);
            Console.WriteLine("Exam added !");
            break;
        case "3":
            var examsWithA = (exams.FindAll(exam => exam.Subject.StartsWith("A")));
            foreach (var examsA in examsWithA)
            {
                Console.WriteLine(examsA);
            }
            break;
        case "4":
            var passedExams = (exams.FindAll(exam => exam.Date < DateTime.Now));
            Console.WriteLine("\n === PASSED EXAMS ===");
            if (passedExams.Count == 0) Console.WriteLine("No passed exams.");
            foreach (var passedExam in passedExams)
            {
                Console.WriteLine(passedExam);
            }
            break;
        case "5":
            var currentDate = DateTime.Now;
            var oneMonthAhead = currentDate.AddMonths(1);

            var lessThanAMonth = exams.FindAll(exam => exam.Date > currentDate && exam.Date <= oneMonthAhead);

            foreach (var examAMonth in lessThanAMonth)
            {
                Console.WriteLine(examAMonth);
            }
            break;
        case "6":
            var examsAtEight = exams.FindAll(exam => exam.Date.Hour == 08 && exam.Date.Minute == 00);
            foreach (var atEight in examsAtEight)
            {
                Console.WriteLine(atEight);
            }
            break;
        case "7":
            var removePassedExams = exams.RemoveAll(exam => exam.Date < DateTime.Now);
            Console.WriteLine("Passed exams removed !");
            break;
        case "8":
            var riyaziyyatExamsVarmi = exams.Exists(exam => exam.Subject.Contains("Riyaziyyat"));
            if(riyaziyyatExamsVarmi) Console.WriteLine("There is riyaziyyat exams !");
            else Console.WriteLine("No exams found !");
            break;
        case "9":
            var riyaziyyatExams = exams.FindAll(exam => exam.Subject.Contains("Riyaziyyat"));
            if (riyaziyyatExams.Count == 0) Console.WriteLine("No exams found !");
            foreach (var riyexam in riyaziyyatExams)
            {
                Console.WriteLine(riyexam);
            }
            break;
        case "0":
            Console.WriteLine("Finished,goodbye !");
            break;
        default:
            Console.WriteLine("Enter correct operator !");
            break;
    }
} while (opt != "0");
