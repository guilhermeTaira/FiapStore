﻿using FiapStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.Name)
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.UserName)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Permission)
                .HasConversion<int>()
                .IsRequired();

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
