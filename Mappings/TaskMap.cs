using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskScheduling.Models;

namespace TaskScheduling.Mappings;

public class TaskMap : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
        builder.Property(prop => prop.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired();
        builder.Property(prop => prop.Status).HasColumnName("status").HasColumnType("int").IsRequired();
        builder.Property(prop => prop.Title).HasColumnName("title").HasColumnType("varchar(100)").IsRequired();
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
    }
}   