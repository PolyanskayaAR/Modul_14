using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Анастасия", "Николаева", 79990000001, "anastasia@gmail.com"));
            phoneBook.Add(new Contact("Сергей", "Григорьев", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Барышкин", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Кондратьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Ферин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иван", "Бордодымов", 799900000013, "ivan@example.com"));

            
            // Сортировка по имени, потом по фамилии
            var phoneBookSorted = phoneBook
                                  .OrderBy(s => s.Name)
                                  .ThenBy(s => s.LastName);



            while (true)
            {
                // Читаем введенный с консоли символ
                var input = Console.ReadKey().KeyChar;

                // проверяем, число ли это
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phoneBookSorted.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // выводим результат
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }


        }



        public class Contact // модель класса
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }

    }
}
