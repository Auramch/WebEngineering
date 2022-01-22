using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace backend.Controllers;

public abstract class AbstractController : ControllerBase
{
    public class Models
    {
        public interface IApiQuery<T>
        {
            public IQueryable<T> Apply(IQueryable<T> items);

            public static IQueryable<T> ApplyAll(IQueryable<T> items, params IApiQuery<T>[] queries) =>
                queries.Aggregate(items, (items, query) => query.Apply(items));
        }

        public class Paging<T> : IApiQuery<T>
        {
            [BindRequired]
            [Range(1, 100)]
            public int Limit { get; set; }
            public int Offset { get; set; } = 0;

            public IQueryable<T> Apply(IQueryable<T> items) => items.Skip(Offset).Take(Limit);
        }
    }
}