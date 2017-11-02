namespace TestingProject
{
    using System;
    using System.Linq;
    using DataLayer;

    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = ApplicationDbContext.Create();

            var categoryNames = context.Categories.AsQueryable().Select(c => c.CategoryName).ToList();

            categoryNames.ForEach(c => Console.WriteLine(c));
        }
    }
}