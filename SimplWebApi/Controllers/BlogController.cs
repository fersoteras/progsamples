using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplWebApi.Models;

namespace SimplWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogPostContext _context;

        public BlogController(BlogPostContext context)
        {
            _context = context;

            if (_context.BlogPostItems.Count() == 0)
            {
                // Create a new BlogPost if collection is empty,
                _context.BlogPostItems.Add(new BlogPost { Title = "Wellcome to SimpleBlog Engine", Content = " This is a very basic blog engine with  x feature and y feature <br />  It has a simple web editor to edit multi-line blog entries.If you  have bug reports and suggestion pleas email to  nonmaintained@dontbother.com " });
                _context.SaveChanges();
            }
        }

        #region snippet_GetAll_GetBlogById
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> Get()
        {
            return await _context.BlogPostItems.ToListAsync();
        }

        // GET: api/blog/5
        [HttpGet("{id}", Name = "GetBlogId")]
        public async Task<ActionResult<BlogPost>> Get(long id)
        {
            var blogItem = await _context.BlogPostItems.FindAsync(id);

            if (blogItem == null)
            {
                return NotFound();
            }

            return blogItem;
        }
        #endregion

        #region snippet_blog_creation
        // POST: api/Blog
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogItem(BlogPost item)
        {
            _context.BlogPostItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        #endregion

        #region snippet_Update

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogItem(long id, BlogPost item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region delete
        // DELETE: api/blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var blogItem = await _context.BlogPostItems.FindAsync(id);

            if (blogItem == null)
            {
                return NotFound();
            }

            // remove in EF orm.
            _context.BlogPostItems.Remove(blogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
           
  
        #endregion
    }
}
