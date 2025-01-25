using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<CustomersModel> CreateCustomerAsync(UserRegistrationForm form);
    Task<bool> DeleteProductAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task<IEnumerable<CustomersModel>> GetAllCustomersAsync();
    Task<CustomersModel> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression);

    Task<CustomersModel> UpdateCustomerAsync(CustomerUpdateForm updateForm);
}
