using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<CustomersModel> CreateCustomerAsync(UserRegistrationForm form)
        {
            var entity = await _customerRepository.GetByIdAsync(x => x.Email == form.Email);
            entity ??= await _customerRepository.CreateAsync(CustomerFactory.Create(form));

            return CustomerFactory.Create(entity);
        }

        public async Task<IEnumerable<CustomersModel>> GetAllCustomersAsync()
        {
            var entities = await _customerRepository.GetAllAsync();
            var customers = entities.Select(CustomerFactory.Create);

            return customers ?? [];
        }

        public async Task<CustomersModel> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression)
        {
            var entity = await _customerRepository.GetByIdAsync(expression);
            var customer = CustomerFactory.Create(entity);
            return customer ?? null!;
        }

        public async Task<CustomersModel> UpdateCustomerAsync(CustomerUpdateForm updateForm)
        {
            var entity = await _customerRepository.UpdateAsync(x => x.Id == updateForm.Id, CustomerFactory.Create(updateForm));
            var customer = CustomerFactory.Create(entity);
            return customer ?? null!;
        }

        public async Task<bool> DeleteProductAsync(Expression<Func<CustomerEntity, bool>> expression)
        {
            var result = await _customerRepository.DeleteAsync(expression);
            return result;
        }
    }
}
