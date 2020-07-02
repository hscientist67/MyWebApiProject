using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiProject.Filters;
using MyWebApiProject.Models;

namespace MyWebApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext db_context;

        public CategoryController(AppDbContext db_context)
        {
            this.db_context = db_context;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();

            response.Entities = db_context.Categories.ToList();
            response.IsSuccess = true;
            return Ok(response);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();

            response.Entity = db_context.Categories.Find(id);
            response.IsSuccess = true;
            if (response.Entity == null)
            {
                response.Errors.Add(id + " nolu kayıt bulunamadı.");
                response.IsSuccess = false;
                response.HasError = true;
                return NotFound(response);
            }

            return Ok(response);

        }

        // POST: api/Category
        [HttpPost]
        [ValidateModel]
        [MyException]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();

            Category category = new Category()
            {
                Title = model.Title,
                Description = model.Description

            };
            db_context.Categories.Add(category);
            db_context.SaveChanges();

            response.Entity = category;
            response.IsSuccess = true;


            return Ok(response);

        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [ValidateModel]
        [MyException]
        public IActionResult Put(int id, [FromBody] CategoryModel model)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();

            
            response.Entity = db_context.Categories.Find(id);

            if (response.Entity == null)
            {
                response.HasError = true;
                response.Errors.Add("Veri bulunamadı");
                return NotFound(response);
            }

            response.Entity.Title = model.Title;
            response.Entity.Description = model.Description;
            response.Entity.ModifiedOn = DateTime.Now;

            db_context.Categories.Update(response.Entity);
            db_context.SaveChanges();

            response.IsSuccess = true;

            return Ok(response);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();

            response.Entity = db_context.Categories.Find(id);

            if (response.Entity == null)
            {
                response.Errors.Add(id + " nolu kayıt bulunamadı.");
                response.IsSuccess = false;
                response.HasError = true;
                return NotFound(response);
            }


            db_context.Categories.Remove(response.Entity);
            db_context.SaveChanges();
            response.IsSuccess = true;

            return Ok(response);
        }
    }
}
