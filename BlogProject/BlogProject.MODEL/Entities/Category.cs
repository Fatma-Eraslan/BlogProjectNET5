using BlogProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MODEL.Entities
{
    public class Category:CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Navigation Property
        //Bir kategorinin birden fazla postu olabilir
        public virtual List<Post> Posts { get; set; }
    }
}
