﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiIdentity.Entities;

namespace WebApiIdentity.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Aluno>().HasData(
            new Aluno
            {
                AlunoId = 1,
                Nome = "Conrado",
                Email = "conrado@example.com",
                Idade = 32,
                Curso = "Math"
            });
        }
    }
}
