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
            // ��������� �������
            context.Database.EnsureCreated();

            // ��������� ������������
            context.Users.Add(new User { FirstName = "��'�1", LastName = "�������1", Age = 25 });
            context.Users.Add(new User { FirstName = "��'�2", LastName = "�������2", Age = 30 });
            context.Users.Add(new User { FirstName = "��'�3", LastName = "�������3", Age = 35 });
            context.SaveChanges();
        }

        // ��������� ������������ � ���� �����
        using (var context = new AppDbContext())
        {
            var users = context.Users.ToList();
            Console.WriteLine("������ ������������ � ���� �����:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.UserId}, ��'�: {user.FirstName}, �������: {user.LastName}, ³�: {user.Age}");
            }
        }
    }
}