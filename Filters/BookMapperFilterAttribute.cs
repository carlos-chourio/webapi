using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.DTOs;
using WebApi.Entities;

namespace WebApi.Filters {
    public class BookMapperFilterAttribute : ResultFilterAttribute {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
            var result = context.Result as ObjectResult;
            if (result?.Value!=null && result?.StatusCode>=200 &&
                result?.StatusCode < 300) {
                var bookEntity = result.Value as Book;
                if (bookEntity!=null) { 
                    result.Value = Mapper.Map<BookForGetDto>(bookEntity);
                    await next();
                    return;
                }
            }
            await next();
            return;
        }
    }
}