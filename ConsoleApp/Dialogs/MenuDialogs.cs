using Azure.Core;
using Business.Dtos;
using Business.Interfaces;
using Business.Models;

namespace ConsoleApp.Dialogs;

public class MenuDialogs(ICustomerService customerService) : IMenuDialogs
{
    private readonly ICustomerService _customerService = customerService;

    public void MenuOptions()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1. Create new User");
            Console.WriteLine("2. View all Users");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    NewUser();
                    break;
                case "2":
                    ViewAllUsers().Wait();
                    break;
                case "3":
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public async void NewUser()
    {
        var userRegistrationForm = new UserRegistrationForm();

        Console.Clear();
        Console.WriteLine("--- Creating new User ---");
        Console.WriteLine("First Name: ");
        userRegistrationForm.FirstName = Console.ReadLine();

        Console.WriteLine("Last Name: ");
        userRegistrationForm.LastName = Console.ReadLine();

        Console.WriteLine("Email: ");
        userRegistrationForm.Email = Console.ReadLine();

        Console.WriteLine("Phone Number: ");
        userRegistrationForm.PhoneNumber = Console.ReadLine();
        Console.WriteLine();

        var customer = await _customerService.CreateCustomerAsync(userRegistrationForm);
        if (customer != null)
        {
            Console.Clear();
            Console.WriteLine("User created successfully!");
            Console.WriteLine($"User: {customer.Id} {customer.FirstName} {customer.LastName} {customer.Email} {customer.PhoneNumber}" );
        }
        else
        {
            Console.WriteLine("User creation failed!");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }

    public async Task ViewAllUsers()
    {
        Console.Clear();
        Console.WriteLine("--- All Users ---");

        var result = await _customerService.GetAllCustomersAsync();
        if (result != null)
        {
            foreach (var customer in result)
            {
                Console.WriteLine($"Id: {customer.Id}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No users found!");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

