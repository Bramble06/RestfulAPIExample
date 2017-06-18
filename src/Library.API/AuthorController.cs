using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {

        private ILibraryRepository _ILibraryRepository;

        public AuthorController(ILibraryRepository libraryRepo)
        {
            _ILibraryRepository = libraryRepo;
        }

        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _ILibraryRepository.GetAuthors();

            return new JsonResult(authorsFromRepo);
        }

    }
}
