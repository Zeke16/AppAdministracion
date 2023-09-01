using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdministracion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAdministracion.Data
{
    public class AppAdministracionContext : IdentityDbContext
    {
        public AppAdministracionContext(DbContextOptions<AppAdministracionContext> options)
            : base(options)
        {
        }


        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Solicitudes> Solicitudes { get; set; }

    }
}
