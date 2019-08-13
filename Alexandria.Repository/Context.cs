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

        //Criando tabela Avatar no DB 
        public DbSet<Avatar> Avatar { get; set; }

        //Criando tabela Book no DB 
        public DbSet<Book> Book { get; set; }

        //Criando tabela Bookcase no DB 
        public DbSet<Bookcase> Bookcase { get; set; }

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
            optionsBuilder.UseMySql(@"Server=localhost;port=3306;Database=alexandria;Uid=root;Pwd=Spectro@123;");
        }



    }
}
