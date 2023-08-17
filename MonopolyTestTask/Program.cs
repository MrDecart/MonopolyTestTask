using Microsoft.EntityFrameworkCore;

using MonopolyTestTask.Database;

var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(@"Data Source=.\TestTaskSqlite.db;").Options;
var database = new DatabaseContext(options);
var repository = new PalletRepository(database);

Console.WriteLine("Task #1");
var count = 1;
foreach (var item in repository.GetAllByFilter())
{
    Console.WriteLine($"Group {count++}");
    foreach (var item2 in item)
    {
        Console.WriteLine(item2);
    }
}
Console.WriteLine("------------------------");
Console.WriteLine("Task #2");
foreach (var item in repository.TopPalets())
{
    Console.WriteLine(item);
}

