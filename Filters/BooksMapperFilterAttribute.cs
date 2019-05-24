using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.DTOs;
using WebApi.Entities;

namespace WebApi.Filters {
    public class BooksMapperFilterAttribute : ResultFilterAttribute {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
            var result = context.Result as ObjectResult;
            if (result?.Value!=null && result?.StatusCode>=200 &&
                result?.StatusCode < 300) {
                var bookEntities = result.Value as IEnumerable<Book>;
                if (bookEntities!=null) { 
                    result.Value = Mapper.Map<IEnumerable<BookDtoBase>>(bookEntities);
                    await next();
                    return;
                }
            }
            await next();
            return;
        }
    }
}