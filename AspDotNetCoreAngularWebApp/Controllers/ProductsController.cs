using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspDotNetCoreAngularWebApp.Models;

namespace AspDotNetCoreAngularWebApp.Controllers
{
    [Route("api/articles")]
    public class ProductController : Controller
    {
        ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
            if (!db.Articles.Any())
            {
                db.Articles.Add(new Article { Headline = "First Arcticle", Articletext = "text one", Author = "Sparrow" });
                db.Articles.Add(new Article { Headline = "Second Arcticle", Articletext = "text two", Author = "Queen" });
                db.Articles.Add(new Article { Headline = "Third Arcticle", Articletext = "3 text", Author = "Jack Daniels" });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return db.Articles.ToList();
        }

        [HttpGet("{id}")]
        public Article Get(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.Id == id);
            return article;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return Ok(article);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Article article)
        {
            if (ModelState.IsValid)
            {
                db.Update(article);
                db.SaveChanges();
                return Ok(article);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.Id == id);
            if (article != null)
            {
                db.Articles.Remove(article);
                db.SaveChanges();
            }
            return Ok(article);
        }
    }
}
