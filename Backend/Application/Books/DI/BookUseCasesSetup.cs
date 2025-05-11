using Backend.Application.Books.UseCases.CreateBook;
using Backend.Application.Books.UseCases.DeleteBook;
using Backend.Application.Books.UseCases.GetBook;
using Backend.Application.Books.UseCases.UpdateBook;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application.Books.DI
{
    public static class BookUseCasesSetup
    {
        public static IServiceCollection AddBookUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateBookUseCase, CreateBookUseCase>();
            services.AddScoped<IUpdateBookUseCase, UpdateBookUseCase>();
            services.AddScoped<IGetBookUseCase, GetBookUseCase>();
            services.AddScoped<IDeleteBookUseCase, DeleteBookUseCase>();

            return services;
        }
    }
}
