﻿using DotProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

        }
    }
}
