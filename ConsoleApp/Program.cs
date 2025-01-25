using Business.Interfaces;
using Business.Services;
using ConsoleApp.Dialogs;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ExerciseAssignment3\Data\Databases\ExerciseAssignment_database.mdf;Integrated Security=True;Connect Timeout=30"), ServiceLifetime.Scoped);
serviceCollection.AddScoped<ICustomerService, CustomerService>();
serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
serviceCollection.AddScoped<IMenuDialogs, MenuDialogs>();


var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<IMenuDialogs>();

while (true)
{
    menuDialogs.MenuOptions();
}
