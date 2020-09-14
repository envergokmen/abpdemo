using AutoMapper;
using Env.Demo.Books;

namespace Env.Demo
{
    public class DemoApplicationAutoMapperProfile : Profile
    {
        public DemoApplicationAutoMapperProfile()
        {
               CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();


            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}
