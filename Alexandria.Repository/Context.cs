﻿using Alexandria.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


// Contexto de Conexão
namespace Alexandria.Repository
{
    public class Context : DbContext
    {
        //Criando tabela User no DB 
        public DbSet<User> User { get; set; }

        //Criando tabela Avatar no DB 
        public DbSet<Avatar> Avatar { get; set; }

        //Criando tabela Book no DB 
        public DbSet<Book> Book { get; set; }

        //Criando tabela Bookcase no DB 
        public DbSet<Bookcase> Bookcase { get; set; }

        //Criando tabela Authors no DB 
        public DbSet<Authors> Authors { get; set; }

        //Criando tabela Subjects no DB 
        public DbSet<Subjects> Subjects { get; set; }

        //Construtores
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public Context() : base()
        {
        }

        //Configuração da conexão com o Database SQLServer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String de Conexão do DB
            optionsBuilder.UseSqlServer(@"Server=SPON3656;Database=db_alexandria;User Id=sa; Password = Wagner231214!;");
        }



    }
}
