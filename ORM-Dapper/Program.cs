﻿using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
    
            var repo = new DapperDepartmentRepository(conn);

            var productrepo = new DapperProductsRepository(conn);

            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();

            foreach (var dep in departments)
            {
                Console.WriteLine(dep.Name);
            }

            var products = productrepo.GetAllProducts();

            foreach (var product in products)
            { 
                Console.WriteLine(product.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
