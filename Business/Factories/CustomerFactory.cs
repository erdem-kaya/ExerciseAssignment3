using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Net.NetworkInformation;

namespace Business.Factories;

public class CustomerFactory
{
    public static UserRegistrationForm Create() => new();

    public static CustomerEntity Create(UserRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber
    };

    public static CustomersModel Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        PhoneNumber = entity.PhoneNumber
    };

    public static CustomerUpdateForm Create(CustomersModel customersModel) => new()
    {
        Id = customersModel.Id,
        FirstName = customersModel.FirstName,
        LastName = customersModel.LastName,
        Email = customersModel.Email,
        PhoneNumber = customersModel.PhoneNumber
    };

    public static CustomerEntity Create(CustomerUpdateForm form) => new()
    {
        Id = form.Id,
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber
    };
}
