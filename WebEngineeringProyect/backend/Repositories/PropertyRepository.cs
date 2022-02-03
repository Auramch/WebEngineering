using Microsoft.EntityFrameworkCore;
using RUG.WebEng.Properties.Models;

namespace RUG.WebEng.Properties.Repositories;

public class PropertyRepository : IRepository<Property, int>
{
    // As everywhere, the actual database connection (DatabaseContext) is provided
    // through Dependency Injection in the constructor by the framework. Nowhere
    // in the app code do we make an explicit decision on how to obtain such an
    // instance, except for Program.cs.
    protected DatabaseContext _context;

    public PropertyRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Here is some C# magic: a Property is like a normal class field, but with
    // automatically-generated getters and setters (this { get; set; }-notation)
    // This specifically is a property with just a getter that is shortened to
    // this form like a mini-lambda function.
    public IQueryable<Property> FullCollection => _context.Properties;

    public async Task<bool> CreateAsync(Property property)
    {
        // Check whether IMDb URL or title already exist
        if (await _context.Properties.AnyAsync(p => p.Title == property.Title))
            return false;

        // Otherwise, create new entry
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Property property)
    {
        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Property property)
    {
        _context.Update(property);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Property?> FindAsync(int id) => await FullCollection.FirstOrDefaultAsync(p => p.Id == id);
}