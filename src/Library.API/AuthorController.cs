using Library.API.Helpers;
using Library.API.Models;
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

            var authors = new List<AuthorDto>();

            foreach(var a in authorsFromRepo)
            {
                authors.Add(new AuthorDto()
                {
                    id = a.Id,
                    Name = $"{a.FirstName} {a.LastName}",
                    Age = a.DateOfBirth.GetCurrentAge(),
                    Genre = a.Genre                
                });
            }

            return new JsonResult(authors);
        }

    }
}
