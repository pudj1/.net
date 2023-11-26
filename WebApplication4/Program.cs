using System;
using System.Linq;
using WebApplication4.Data;
using WebApplication4.Models;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            // Створення таблиці
            context.Database.EnsureCreated();

            // Додавання користувачів
            context.Users.Add(new User { FirstName = "Ім'я1", LastName = "Прізвище1", Age = 25 });
            context.Users.Add(new User { FirstName = "Ім'я2", LastName = "Прізвище2", Age = 30 });
            context.Users.Add(new User { FirstName = "Ім'я3", LastName = "Прізвище3", Age = 35 });
            context.SaveChanges();
        }

        // Виведення користувачів з бази даних
        using (var context = new AppDbContext())
        {
            var users = context.Users.ToList();
            Console.WriteLine("Список користувачів з бази даних:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.UserId}, Ім'я: {user.FirstName}, Прізвище: {user.LastName}, Вік: {user.Age}");
            }
        }
    }
}