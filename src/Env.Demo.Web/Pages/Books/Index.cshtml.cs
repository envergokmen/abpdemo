using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Env.Demo.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Env.Demo.Web.Pages.Books
{
    public class IndexModel : PageModel
    {
        IBookAppService bookService;
        public IReadOnlyList<BookDto> books;

        public IndexModel(IBookAppService _bookService)
        {
            bookService = _bookService;
        }

        public async void OnGet()
        {
            books= (await bookService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto
            {
                MaxResultCount = 10,
                SkipCount = 0
            })).Items;
        }
    }
}
