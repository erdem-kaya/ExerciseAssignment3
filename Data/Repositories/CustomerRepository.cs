using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext _context = context;

    public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating user entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var entities = await _context.Customers.ToListAsync();
        return entities;
    }

    public async Task<CustomerEntity> GetByIdAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        var entity = await _context.Customers.FirstOrDefaultAsync(expression) ?? null!;
        return entity;
    }

    public async Task<CustomerEntity> UpdateAsync(Expression<Func<CustomerEntity, bool>> expression, CustomerEntity customerEntity)
    {
        if (customerEntity == null)
            return null!;
        try
        {
            var existingEntity = await _context.Customers.FirstOrDefaultAsync(expression);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(customerEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating user entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return false;
        try
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(expression);
            if (entity == null)
                return false;
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting user entity : {ex.Message}");
            return false;
        }
    }
}
