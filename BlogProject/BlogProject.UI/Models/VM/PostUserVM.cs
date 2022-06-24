using BlogProject.MODEL.Entities;
using System.Collections.Generic;

namespace BlogProject.UI.Models.VM
{
    public class PostUserVM
    {
        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
    }
}
