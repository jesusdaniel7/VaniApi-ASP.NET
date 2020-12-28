using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParameters<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int RecordsPerPage)
        {
            double quantity = await queryable.CountAsync();
            double quantityPage = Math.Ceiling(quantity / RecordsPerPage);
            httpContext.Response.Headers.Add("quantity", quantity.ToString());
            httpContext.Response.Headers.Add("quantityPage", quantityPage.ToString());
        }
    }
}
