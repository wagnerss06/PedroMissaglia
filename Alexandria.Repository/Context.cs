using Alexandria.Model;
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
            //string Connection = @"Server=PEDRO\SQLEXPRESS;Database=db_alexandria;User Id=sa; Password = Spectro@123;";

            //String de Conexão do DB
            optionsBuilder.UseSqlServer(@"Server=PEDRO\SQLEXPRESS;Database=db_alexandria;User Id=sa; Password = Spectro@123;");
        }



    }
}
