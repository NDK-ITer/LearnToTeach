using Authentication_Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.id);
            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.Birthday).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.FirstEmail).IsRequired(true);
            builder.Property(x => x.PresentEmail).IsRequired(true);
            builder.Property(x => x.PasswordHash).IsRequired(true);

        }
    }
}
