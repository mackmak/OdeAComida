using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeAComida.Models
{
    public interface IOdeAComidaDb: IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }
    public class OdeAComidaDb:DbContext, IOdeAComidaDb
    {
        public OdeAComidaDb():base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OdeAComidaDb, OdeAComida.Migrations.Configuration>());
        }
        public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<AnaliseRestaurante> Analises { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        /*public IQueryable Find<T>(T entity) where T : class
        {

        }*/

        void IOdeAComidaDb.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}