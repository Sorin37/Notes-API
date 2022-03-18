using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private List<Category> categories = new List<Category> { 
            new Category { Name = "To Do", Id = "1"},
            new Category { Name = "Done", Id = "2"},
            new Category { Name = "Doing", Id = "3"},
        };
        //categories.Add(new Category() { Name = "lmao", Id = '1'});
        public CategoriesController() { }
        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);
        }
    }
}
