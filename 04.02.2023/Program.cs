/*
 * класс, описывающий структуру записи студентов, состоящую из следующих полей:
 * 1) ФИО
 * 2.1) 2.2) 2.3) — дата рождения
 * 3) группа
 * 4.1) наименование предмета 4.2)оценка
 * выдать студентов, которые учатся в заданной группе; выдать студентов должников; выдать студентов отличников; выдать студентов моложе 20-ти лет 
 * должно быть меню с:
 * 1) заполнением
 * 2) выборка по
 */

using System.ComponentModel.Design;

namespace _04._02._2023
{
    class Student
    {
        public string FIO;
        public string GROUP;
        public string BDAY, BMONTH, BYEAR;
        public List<string> SUBJECT = new() { " " };
        public List<int> MARK = new() { 0 };


        public Student(string fio, string group, string day, string month, string year, string[] subj, int[] mark)
        {
            FIO = fio;
            GROUP = group;
            BDAY = day;
            BMONTH = month;
            BYEAR = year;
            SUBJECT.AddRange(subj);
            MARK.AddRange(mark);
            
        }
        public void ShowStudent()
        {
            Console.WriteLine($"ФИО: {FIO} \nГруппа: {GROUP} \nДата рождения: {BDAY}.{BMONTH}.{BYEAR} "); 
        }
    }
    class Program
    {
        static void Main()
        {
            Menu1();
        }
        static void Menu1()
        {
            Console.Clear();
            Console.WriteLine("Меню");
            Console.WriteLine();
            Console.WriteLine("Для выбора варианта введите:");
            Console.WriteLine("1)Заполнить");
            Console.WriteLine("0)Выход");
            int _case = Convert.ToInt32(Console.ReadLine());
            if (_case == 1) Fullify();
            if (_case == 0) { Console.Clear(); Environment.Exit(0); }
        }
        static void Menu(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("Меню");
            Console.WriteLine();
            Console.WriteLine("Для выбора варианта введите:");
            Console.WriteLine("1) Заполнить");
            Console.WriteLine("2) Выборка по ФИО");
            Console.WriteLine("3) Выборка по группе");
            Console.WriteLine("4) Выборка должников");
            Console.WriteLine("5) Выборка отличников");
            Console.WriteLine("6) Выборка студентов моложе 20 лет");
            Console.WriteLine("0) Выход");
            Console.WriteLine();
            int _case = Convert.ToInt32(Console.ReadLine());
            if (_case == 1) Fullify();
            if (_case == 2) Name(baza);
            if (_case == 3) Group(baza);
            if (_case == 4) Dvojka(baza);
            if (_case == 5) Pyat(baza);
            if (_case == 6) Young(baza);
            if (_case == 0) { Console.Clear(); Environment.Exit(0); }
        }
        static void Fullify()
        {
            Console.Clear();
            Console.Write("Введите количество студентов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Student[] baza = new Student[n];
            for (int i = 0; i < n; i++) 
            {
                Console.Write("Введите ФИО студента: ");
                string fio = Console.ReadLine();
                Console.Write("Введите группу студента: ");
                string group = Console.ReadLine();
                Console.Write("Введите дату рождения студента (дд.мм.гг): ");
                string[] date = Console.ReadLine().Split(".");
                string day = date[0];
                string month = date[1];
                string year = date[2];
                Console.Write("Введите количество дисциплин: ");
                int k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                string[] subj = new string[k];
                int[] mark = new int[k];
                for (int j = 0; j < k; j++)
                {
                    Console.Write("Введите дисциплину: ");
                    subj[j] = Console.ReadLine();
                    Console.Write("Введите оценку за дисциплину: ");
                    mark[i] = Convert.ToInt32(Console.ReadLine());
                }
                baza[i] = new Student(fio, group, day, month, year, subj, mark);
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("Запись окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
        static void Name(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("По какому ФИО выборка?");
            string viborka = Console.ReadLine();
            Console.WriteLine();
            int k = 1;
            for (int i = 0; i < baza.Length; i++)
            {
                if (baza[i].FIO == viborka)
                {
                    Console.WriteLine(k + ") " + baza[i].FIO + " — " + baza[i].GROUP);
                    k++;
                }
            }
            Console.WriteLine("Выборка окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
        static void Group(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("По какой группе выборка?");
            string viborka = Console.ReadLine();
            Console.WriteLine();
            int k = 1;
            for (int i = 0; i < baza.Length; i++)
            {
                if (baza[i].GROUP == viborka)
                {
                    Console.WriteLine(k + ") " + baza[i].FIO + " — " + baza[i].GROUP);
                }
            }
            Console.WriteLine("Выборка окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
        static void Dvojka(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("Выборка по оценкам: должники");
            Console.WriteLine();
            int pleb = 0;
            for (int i = 0; i < baza.Length; i++)
            {
                for (int j = 1; j < baza[i].SUBJECT.Count; j++)
                {
                    if (Convert.ToInt32(baza[i].MARK[j]) < 3) pleb = 1;
                }
                if (pleb == 1) Console.WriteLine(baza[i].FIO + " " + baza[i].GROUP);
                pleb = 0;
            }
            Console.WriteLine();
            Console.WriteLine("Выборка окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
        static void Pyat(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("Выборка по оценкам: отличники");
            Console.WriteLine();
            int pleb = 1;
            for (int i = 0; i < baza.Length; i++)
            {
                for (int j = 1; j < baza[i].SUBJECT.Count; j++)
                {
                    if (Convert.ToInt32(baza[i].MARK[j]) != 5) pleb = 0;
                }
                if (pleb == 1) Console.WriteLine(baza[i].FIO + " " + baza[i].GROUP);
                pleb = 1;
            }
            Console.WriteLine();
            Console.WriteLine("Выборка окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
        static void Young(Student[] baza)
        {
            Console.Clear();
            Console.WriteLine("Выборка по возрасту: моложе 20-ти лет");
            Console.WriteLine();
            for (int i = 0; i < baza.Length; i++)
            {
                if (Convert.ToInt32(baza[i].BYEAR) > 2002) Console.WriteLine(i + 1 + ") " + baza[i].FIO);
            }
            Console.WriteLine("Выборка окончена, нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Menu(baza);
        }
    }
}