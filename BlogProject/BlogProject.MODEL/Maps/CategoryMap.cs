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
    public class CategoryMap:CoreMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired(true);


            base.Configure(builder);    
        }
    }
}
