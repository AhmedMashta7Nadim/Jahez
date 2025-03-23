using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InfraStractur.Seeding
{
    internal static class UserRoleSeed
    {

        public static void AddIdentityRole (ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(

                new IdentityRole()
                {
                    Id = "768b0484-ca23-43d5-beab-da6d942a7a1b",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "ffc1115b-edbe-43c7-b557-67cebb2a4511"
                },
                new IdentityRole()
                {
                    Id = "0f7139bf-3640-42e4-90e8-53a501b120f1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "94a62d6f-b09c-4382-bfab-d4c3eef4777c"
                }

                );
        }
    }
}
