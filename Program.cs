
using System;
using System.Collections.Generic;

namespace Medvedev
{
    enum Department
    {
        Systems,
        Development,
        Management,
        Accounting,
        TopManagement
    }

    class Task
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public Department Target { get; set; }
        public string RequiredActions { get; set; }

        public Task(int number, string description, Department target, string actions)
        {
            Number = number;
            Description = description;
            Target = target;
            RequiredActions = actions;
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public Department Department { get; set; }
        public List<Employee> DirectSupervisors { get; set; } = new List<Employee>();
        public List<Employee> Subordinates { get; set; } = new List<Employee>();

        public Employee(string name, string position, Department dept)
        {
            Name = name;
            Position = position;
            Department = dept;
        }

        public void AddSubordinate(Employee e)
        {
            Subordinates.Add(e);
            e.DirectSupervisors.Add(this);
        }

        public bool CanReceiveTaskFrom(Employee from)
        {
            return DirectSupervisors.Contains(from);
        }
    }

    class Program
    {
        static void AssignTask(Employee from, Employee to, Task task)
        {
            Console.WriteLine($"\n>> Задача №{task.Number}: \"{task.Description}\"");
            Console.WriteLine($"   Категория: {TargetToRussian(task.Target)}");
            Console.WriteLine($"   Требуемые действия: {task.RequiredActions}");
            Console.WriteLine($"   От {from.Name} ({from.Position}) даётся задача \"{task.Description}\" — {to.Name} ({to.Position}).");

            if (to.CanReceiveTaskFrom(from))
                Console.WriteLine($"   {to.Name} БЕРЁТ задачу.");
            else
                Console.WriteLine($"   {to.Name} НЕ БЕРЁТ задачу (не прямое руководство).");
        }

        static string TargetToRussian(Department d)
        {
            switch (d)
            {
                case Department.Systems: return "системщикам";
                case Department.Development: return "разработчикам";
                case Department.Management: return "начальству ИТ-отдела";
                case Department.Accounting: return "бухгалтерии";
                default: return "руководству";
            }
        }

        static void PrintHierarchy(Employee e, int level = 0)
        {
            Console.WriteLine(new string(' ', level * 3) + $"{e.Position}: {e.Name}");
            foreach (var sub in e.Subordinates)
                PrintHierarchy(sub, level + 1);
        }

        public static void Main()
        {
            Employee timur = new Employee("Тимур", "Генеральный директор", Department.TopManagement);

            Employee rashid = new Employee("Рашид", "Финансовый директор", Department.TopManagement);
            timur.AddSubordinate(rashid);
            Employee lucas = new Employee("Лукас", "Главный бухгалтер", Department.Accounting);
            rashid.AddSubordinate(lucas);

            Employee ilham = new Employee("О Ильхам", "Директор по автоматизации", Department.TopManagement);
            timur.AddSubordinate(ilham);

            Employee orkady = new Employee("Оркадий", "Начальник ИТ-отдела", Department.Management);
            ilham.AddSubordinate(orkady);

            Employee volodya = new Employee("Володя", "Зам. начальника ИТ-отдела", Department.Management);
            orkady.AddSubordinate(volodya);

            Employee ilshat = new Employee("Ильшат", "Главный системщиков", Department.Systems);
            orkady.AddSubordinate(ilshat);
            ilshat.DirectSupervisors.Add(volodya);

            Employee ivanych = new Employee("Иваныч", "Зам. главного системщиков", Department.Systems);
            ilshat.AddSubordinate(ivanych);

            Employee ilya = new Employee("Илья", "Системщик", Department.Systems);
            Employee vitya = new Employee("Витя", "Системщик", Department.Systems);
            Employee zhenya = new Employee("Женя", "Системщик", Department.Systems);
            ivanych.AddSubordinate(ilya);
            ivanych.AddSubordinate(vitya);
            ivanych.AddSubordinate(zhenya);

            Employee sergey = new Employee("Сергей", "Главный разработчиков", Department.Development);
            orkady.AddSubordinate(sergey);
            sergey.DirectSupervisors.Add(volodya);

            Employee lyaysan = new Employee("Ляйсан", "Зам. главного разработчиков", Department.Development);
            sergey.AddSubordinate(lyaysan);

            Employee marat = new Employee("Марат", "Разработчик", Department.Development);
            Employee dina = new Employee("Дина", "Разработчик", Department.Development);
            Employee ildar = new Employee("Ильдар", "Разработчик", Department.Development);
            Employee anton = new Employee("Антон", "Разработчик", Department.Development);
            lyaysan.AddSubordinate(marat);
            lyaysan.AddSubordinate(dina);
            lyaysan.AddSubordinate(ildar);
            lyaysan.AddSubordinate(anton);

            Console.WriteLine("===== ИЕРАРХИЯ КОНТОРЫ =====");
            PrintHierarchy(timur);

            Task[] tasks = new Task[]
            {
                new Task(1, "Настройка сетевого оборудования", Department.Systems,
                         "Проверить маршрутизаторы, настроить VLAN, протестировать соединение"),
                new Task(2, "Разработка модуля отчётности", Department.Development,
                         "Спроектировать БД, реализовать API, написать тесты"),
                new Task(3, "Сведение квартального баланса", Department.Accounting,
                         "Подготовить формы, сверить данные, отправить в налоговую"),
                new Task(4, "План автоматизации на квартал", Department.Management,
                         "Составить план, согласовать с директором по автоматизации"),
                new Task(5, "Обновление ИТ-документации", Department.Development,
                         "Актуализировать схемы, регламенты, инструкции")
            };

            Console.WriteLine("\n===== РАСПРЕДЕЛЕНИЕ ЗАДАЧ =====");

            AssignTask(ivanych, ilya, tasks[0]);
            AssignTask(timur, ilya, tasks[0]);
            AssignTask(lyaysan, marat, tasks[1]);
            AssignTask(sergey, dina, tasks[1]);
            AssignTask(rashid, lucas, tasks[2]);
            AssignTask(ilham, orkady, tasks[3]);
            AssignTask(orkady, sergey, tasks[4]);
            AssignTask(volodya, ilshat, tasks[4]);
            AssignTask(timur, marat, tasks[1]);
        }
    }
}