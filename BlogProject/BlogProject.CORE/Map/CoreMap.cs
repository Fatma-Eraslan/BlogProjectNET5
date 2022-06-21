using Microsoft.EntityFrameworkCore;
using BlogProject.CORE.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.CORE.Map
{
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)//ovveride edebilmek için virtual yaz
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(false);
            builder.Property(x => x.CreatedComputerName).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.CreatedIP).HasMaxLength(15).IsRequired(false);

            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.UpdatedComputerName).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.UpdatedIP).HasMaxLength(15).IsRequired(false);
        }
    }
}
