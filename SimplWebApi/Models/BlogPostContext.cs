using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebApi.Models
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPostItems { get; set; }
    }
}
