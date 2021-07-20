using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Comment>().ToTable("Comment");

           modelBuilder.Entity<Category>().HasData(
         new Category { CategoryId = 1, NameCategory = "Dogs" },
              new Category { CategoryId = 2, NameCategory = "Cats" },
              new Category { CategoryId = 3, NameCategory = "Birds" }
           );

            modelBuilder.Entity<Animal>().HasData(
               new Animal { AnimalId = 1, Name = "English Bulldog", Age = 4, Description = "His name is Hugo and he is chubby and cute", PictureName = "Bulldog.jpeg", CategoryId = 1 },
               new Animal { AnimalId = 2, Name = "Husky", Age = 6, Description = "likes to play in the snow", PictureName = "husky3.jpg", CategoryId = 1 },
               new Animal { AnimalId = 3, Name = "Pug", Age = 10, Description = "He is friendly and always gets stuck in glass doors", PictureName = "pug3.jpg", CategoryId = 1 },
               new Animal { AnimalId = 4, Name = "Shih Tzu", Age = 7, Description = "likes to be taken to the barbershop", PictureName = "ShihTzu.jpeg", CategoryId = 1 },
               new Animal { AnimalId = 5, Name = "Teddy Bear", Age = 5, Description = "Her name is Violet and she barks loudly", PictureName = "teddyBar.jpg", CategoryId = 1 },
               new Animal { AnimalId = 6, Name = "Ragdoll", Age = 10, Description = "likes to sleep a lot", PictureName = "ragdoll.jpg", CategoryId = 2 },
               new Animal { AnimalId = 7, Name = "Savannah", Age = 18, Description = "A very special and wild cat", PictureName = "savannah.jpg", CategoryId = 2 },
               new Animal { AnimalId = 8, Name = "Shorthair", Age = 20, Description = "Garfield likes to play with wool balls", PictureName = "shorthair.png", CategoryId = 2 },
               new Animal { AnimalId = 9, Name = "Siberian Forest", Age = 13, Description = "Likes cold weather and playing outside", PictureName = "siberianForest.jpg", CategoryId = 2 },
                new Animal { AnimalId = 10, Name = "Ara Macaw", Age = 11, Description = "Likes to crack kernels", PictureName = "Ara-macao.jpg", CategoryId = 3 },
               new Animal { AnimalId = 11, Name = "Jako", Age = 12, Description = "His name is jako and he is very good at imitating people", PictureName = "jako.jpg", CategoryId = 3 }
            );

            modelBuilder.Entity<Comment>().HasData(
           new Comment {CommentId=1, CommentString="Born in Africa", AnimalId= 10},
                new Comment { CommentId = 2, CommentString = "very friendly", AnimalId = 10 },
                new Comment { CommentId = 3, CommentString = "Its feathers are colorful", AnimalId = 10 },
                new Comment { CommentId = 4, CommentString = "naughty", AnimalId = 3 },
                new Comment { CommentId = 5, CommentString = "good with children", AnimalId = 3}
                );
        }
    } 
}
