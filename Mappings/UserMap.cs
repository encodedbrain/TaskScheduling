using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskScheduling.Models;

namespace TaskScheduling.Mappings;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Email).HasColumnName("email").HasColumnType("varchar(154)").IsRequired();
        builder.Property(prop => prop.Nickname).HasColumnName("nickname").HasColumnType("varchar(100)").IsRequired();
        builder.Property(prop => prop.Password).HasColumnName("password").HasColumnType("varchar(250)").IsRequired();

        builder.HasMany(prop => prop.Tasks).WithOne(prop => prop.User).HasForeignKey(prop => prop.UserId);
        
        
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
    }
}