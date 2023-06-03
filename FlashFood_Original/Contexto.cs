using FlashFood_Original.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FlashFood_Original
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Gerentes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }




    }
}
