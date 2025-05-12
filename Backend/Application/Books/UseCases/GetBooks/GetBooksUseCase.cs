using AutoMapper;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Interfaces.Repositories;
using WebAPI.DTOModels.Incoming.Book;

namespace Backend.Application.Books.UseCases.GetBooks
{
    public class GetBooksUseCase(
        IBookRepository _bookRepository,
        IMapper _mapper
    ) : IGetBooksUseCase
    {
        public async Task<IEnumerable<GetBookDTO>> ExecuteAsync(BookFilterDTO filters)
        {
            var books = await _bookRepository.GetBooksAsync();

            var query = books.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Title))
                query = query.Where(b => b.Title.Contains(filters.Title));

            if (!string.IsNullOrEmpty(filters.Author))
                query = query.Where(b => b.Author.Contains(filters.Author));

            if (!string.IsNullOrEmpty(filters.Genre))
                query = query.Where(b => b.Genre.Contains(filters.Genre));

            if (!string.IsNullOrEmpty(filters.ISBN))
                query = query.Where(b => b.ISBN.Contains(filters.ISBN));

            if (filters.PublishedYear.HasValue)
                query = query.Where(b => b.PublishedYear == filters.PublishedYear);

            if (filters.Quantity.HasValue)
                query = query.Where(b => b.Quantity == filters.Quantity);

            return _mapper.ProjectTo<GetBookDTO>(query).ToList();
        }
    }
}
