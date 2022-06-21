using BlogProject.CORE.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MODEL.Maps
{
    public class PostMap:CoreMap<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.PostDetail).HasMaxLength(255).IsRequired(true);
            builder.Property(x => x.Tags).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.ImagePath).HasMaxLength(255).IsRequired(false);

            base.Configure(builder);    
        }
    }
}
