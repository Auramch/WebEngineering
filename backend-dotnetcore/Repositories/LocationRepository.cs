using Microsoft.EntityFrameworkCore;
using RUG.WebEng.Properties.Models;

namespace RUG.WebEng.Properties.Repositories;

public class LocationRepository : IRepository<Location, int>
{
    // As everywhere, the actual database connection (DatabaseContext) is provided
    // through Dependency Injection in the constructor by the framework. Nowhere
    // in the app code do we make an explicit decision on how to obtain such an
    // instance, except for Program.cs.
    protected DatabaseContext _context;

    public LocationRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Here is some C# magic: a Property is like a normal class field, but with
    // automatically-generated getters and setters (this { get; set; }-notation)
    // This specifically is a property with just a getter that is shortened to
    // this form like a mini-lambda function.
    public IQueryable<Location> SimpleCollection => _context.Locations;
    public IQueryable<Location> FullCollection => _context.Locations.Include(a => a.Properties);

    public async Task<bool> CreateAsync(Location location)
    {
        // Check whether name already exists
        if(await _context.Locations.AnyAsync(a => a.City == location.City))
            return false;

        // Otherwise, create new entry
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Location location)
    {
        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Location location)
    {
        _context.Update(location); // This call will make sure the provided actor
                                // is "known" by EF
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Location?> FindAsync(int id) => await FullCollection.FirstOrDefaultAsync(a => a.Id == id);
}