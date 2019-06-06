using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebApi.Models
{
    public class BlogPost
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

     //   public virtual ICollection<Comment> Comments { get; set; }
    }
}
