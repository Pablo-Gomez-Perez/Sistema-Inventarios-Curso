using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarios.DataAccess.Configuration
{
    internal class BodegaConfiguration : IEntityTypeConfiguration<Bodega>
    {
        public void Configure(EntityTypeBuilder<Bodega> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x =>x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x =>x.Description).IsRequired().HasMaxLength(400);
            builder.Property(x =>x.State).IsRequired();            
        }
    }
}
