using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Infrastructure
{
    public static class SeedExtensions
    {
        public static readonly User[] UsersSeed = new User[] {
            new User
            {
                Username = "Mr. Sample",
                Name="Mr.",
                Photo="photo.png",
            }
        };

        public static readonly Stream[] streamsSeed = new Stream[]
        {
            new Stream
            {
                Id = 1,
                Url = ""
            }
        };
       
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
            modelBuilder.Entity<Stream>().HasData(
              streamsSeed
           );
        }
    }
}
