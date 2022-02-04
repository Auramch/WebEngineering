using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RUG.WebEng.Properties.Models;
using RUG.WebEng.Properties.Repositories;


namespace RUG.WebEng.Properties.Controllers;

//Call to DB funcions. TODO: check the implementation of this functions

[ApiController]
[Route("properties")]
public class PropertiesController : AbstractController
{
    private readonly PropertyRepository _prop;

    public PropertiesController(PropertyRepository prop)
    {
        _prop= prop;
    }

    [HttpGet]
    public ActionResult<IAsyncEnumerable<ApiModels.PropertySummary>> GetListAsync(
        [FromQuery] RequestModels.Order order_by,
        [FromQuery] RequestModels.Filter filter
    )
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var prop = Models.IApiQuery<Property>.ApplyAll(_prop.SimpleCollection, filter, order_by);
        return Ok(prop.AsAsyncEnumerable().Select(ApiModels.PropertySummary.FromDatabase));
    }

    /*.................................................................................................................*/

    [HttpGet("{location}")]
        public async Task<ActionResult<ApiModels.Property>> GetPropAsync(int location) =>
            await _prop.FindAsync(location) switch
            {
                null => NotFound(),
                var prop => Ok(ApiModels.Property.FromDatabase(prop))
            };

  [HttpPut("{location}")]
    public async Task<ActionResult<ApiModels.Property>> UpdatePropertyAsync(int location, [FromBody] ApiModels.Property propertyAPI)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var prop= await _prop.FindAsync(location);
        if (location == null)
            return NotFound();

        
        prop.PostedAgo = propertyAPI.PostedAgo;
        prop.Roommates = propertyAPI.Roommates;
        prop.IsRoomActive= propertyAPI.IsRoomActive;
        prop.Gender= propertyAPI.Gender;
        prop.Availabilty= propertyAPI.Availabilty;
        prop.Url= propertyAPI.Url;
        prop.budget= propertyAPI.budget;
        prop.square= propertyAPI.square;
        prop.Title= propertyAPI.Title;
        prop.Location= propertyAPI.Location;
        prop.RoomInfo= propertyAPI.RoomInfo;
        prop.Costs= propertyAPI.Costs;
        prop.Description= propertyAPI.Description;
        prop.Allowances= propertyAPI.Allowances;
        prop.Commodities=propertyAPI.Commodities;

        await _prop.UpdateAsync(prop);
        return ApiModels.Property.FromDatabase(prop);
    }

   [HttpDelete("{location}")]
       public async Task<ActionResult> DeletePropertyAsync(int location) =>

           await _prop.FindAsync(location) switch
           {
               null => NotFound(),
               var prop => await _prop.DeleteAsync(prop).ContinueWith(_ => Ok())
           };

  /*.................................................................................................................*/

     [HttpGet("/properties/{id}")]
            public async Task<ActionResult<ApiModels.Property>> GetPropertyAsync(int id) =>
                await _prop.FindAsync(id) switch
                {
                    null => NotFound(),
                    var prop => Ok(ApiModels.Property.FromDatabase(prop))
                };


    [HttpPut("/properties/{id}")]
        public async Task<ActionResult<ApiModels.Property>> UpdatePropertiesAsync(int id, [FromBody] ApiModels.Property propertyAPI)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var prop= await _prop.FindAsync(id);
            if (id == null)
                return NotFound();

            
            prop.PostedAgo = propertyAPI.PostedAgo;
            prop.Roommates = propertyAPI.Roommates;
            prop.IsRoomActive= propertyAPI.IsRoomActive;
            prop.Gender= propertyAPI.Gender;
            prop.Availabilty= propertyAPI.Availabilty;
            prop.Url= propertyAPI.Url;
            prop.budget= propertyAPI.budget;
            prop.square= propertyAPI.square;
            prop.Title= propertyAPI.Title;
            prop.Location= propertyAPI.Location;
            prop.RoomInfo= propertyAPI.RoomInfo;
            prop.Costs= propertyAPI.Costs;
            prop.Description= propertyAPI.Description;
            prop.Allowances= propertyAPI.Allowances;
            prop.Commodities=propertyAPI.Commodities;

            await _prop.UpdateAsync(prop);
            return ApiModels.Property.FromDatabase(prop);
        }

    [HttpPost("/properties/{id}")]
    public async Task<ActionResult<int>> CreateAsync(int id,[FromBody] ApiModels.Property propertyAPI)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var prop = new Property
        {

            PostedAgo = propertyAPI.PostedAgo,
            Roommates = propertyAPI.Roommates,
            IsRoomActive= propertyAPI.IsRoomActive,
            Gender= propertyAPI.Gender,
            Availabilty= propertyAPI.Availabilty,
            Url= propertyAPI.Url,
            budget= propertyAPI.budget,
            square= propertyAPI.square,
            Title= propertyAPI.Title,
            Location= propertyAPI.Location,
            RoomInfo= propertyAPI.RoomInfo,
            Costs= propertyAPI.Costs,
            Description= propertyAPI.Description,
            Allowances= propertyAPI.Allowances,
            Commodities=propertyAPI.Commodities
        };

        

        var result = await _prop.CreateAsync(prop);
        if (!result)
            return Conflict();

        return Ok(prop.Id);
    }

    [HttpDelete("/properties/{id}")]
        public async Task<ActionResult> DeletePropertiesAsync(int id) =>
            await _prop.FindAsync(id) switch
            {
                null => NotFound(),

                var prop => await _prop.DeleteAsync(prop).ContinueWith(_ => Ok())

            };

  /*.................................................................................................................*/

    [HttpGet("/statistics/{location}")]
    public async Task<ActionResult<ApiModels.Statistics>> GetPropertiesAsync(int location)=>
        await _prop.FindAsync(location) switch
        {
            null => NotFound(),
            var prop => Ok(ApiModels.Property.FromDatabase(prop))
                    
        };

    /*.................................................................................................................*/

    [HttpGet("/properties/active/{location}")]
    public ActionResult<IAsyncEnumerable<ApiModels.Property>> GetListAsync(
        [FromQuery] RequestModels.Filter filter, int location)
        {
            if (!ModelState.IsValid)
            return BadRequest();
            var prop = Models.IApiQuery<Property>.ApplyAll(_prop.SimpleCollection, filter);
            return Ok(prop.AsAsyncEnumerable().Select(ApiModels.PropertySummary.FromDatabase));
        }
 /*.................................................................................................................*/

    public class RequestModels
    {
        public class Order : Models.IApiQuery<Property>
        {
            [BindProperty(Name = "order-by")]
            public Column? By { get; set; }
            [BindProperty(Name = "order-dir")]
            public Dir? Direction { get; set; }

            public enum Dir { Asc, Desc }
            public enum Column { RentalCost, SquareMeter }

            public IQueryable<Property> Apply(IQueryable<Property> prop) =>
                (By, Direction) switch
                {
                    //TODO: check budget,square variable in Property class
                    (Column.RentalCost, Dir.Asc) => prop.OrderBy(m => m.budget),
                    (Column.RentalCost, Dir.Desc) => prop.OrderByDescending(m => m.budget),
                    (Column.SquareMeter, Dir.Asc) => prop.OrderBy(m => m.square),
                    (Column.SquareMeter, Dir.Desc) => prop.OrderByDescending(m => m.square),
                    _ => prop,
                };
        }

        public class Filter : Models.IApiQuery<Property>
        {
            public int? Budgetmin { get; set; }
            public int? Budgetmax { get; set; }

            public IQueryable<Property> Apply(IQueryable<Property> prop)
            {
                if (Budgetmin != null && Budgetmax != null) prop = prop.Where(m => m.Costs.Rent < Budgetmax && m.Costs.Rent > Budgetmin);
                return prop;
            }
        }
    }
}

