//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсовая
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Оргкомитет_конференцииEntities : DbContext
    {
        public Оргкомитет_конференцииEntities()
            : base("name=Оргкомитет_конференцииEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Докладчики> Докладчики { get; set; }
        public virtual DbSet<Доклады> Доклады { get; set; }
        public virtual DbSet<Зона> Зона { get; set; }
        public virtual DbSet<Конференция> Конференция { get; set; }
        public virtual DbSet<Место_проведения> Место_проведения { get; set; }
        public virtual DbSet<Обслуживающий_персонал> Обслуживающий_персонал { get; set; }
        public virtual DbSet<Организаторы> Организаторы { get; set; }
        public virtual DbSet<Сборник> Сборник { get; set; }
        public virtual DbSet<Спонсоры> Спонсоры { get; set; }
        public virtual DbSet<Участники> Участники { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }
    
        [DbFunction("Оргкомитет_конференцииEntities", "Winner")]
        public virtual IQueryable<Winner_Result> Winner(Nullable<int> idKonf, string napravl)
        {
            var idKonfParameter = idKonf.HasValue ?
                new ObjectParameter("idKonf", idKonf) :
                new ObjectParameter("idKonf", typeof(int));
    
            var napravlParameter = napravl != null ?
                new ObjectParameter("napravl", napravl) :
                new ObjectParameter("napravl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Winner_Result>("[Оргкомитет_конференцииEntities].[Winner](@idKonf, @napravl)", idKonfParameter, napravlParameter);
        }
    
        public virtual int SELL(Nullable<decimal> maxsum, Nullable<double> sell, Nullable<int> id)
        {
            var maxsumParameter = maxsum.HasValue ?
                new ObjectParameter("maxsum", maxsum) :
                new ObjectParameter("maxsum", typeof(decimal));
    
            var sellParameter = sell.HasValue ?
                new ObjectParameter("sell", sell) :
                new ObjectParameter("sell", typeof(double));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SELL", maxsumParameter, sellParameter, idParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        [DbFunction("Оргкомитет_конференцииEntities", "Winner1")]
        public virtual IQueryable<Winner1_Result> Winner1(Nullable<int> idKonf, string napravl)
        {
            var idKonfParameter = idKonf.HasValue ?
                new ObjectParameter("idKonf", idKonf) :
                new ObjectParameter("idKonf", typeof(int));
    
            var napravlParameter = napravl != null ?
                new ObjectParameter("napravl", napravl) :
                new ObjectParameter("napravl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Winner1_Result>("[Оргкомитет_конференцииEntities].[Winner1](@idKonf, @napravl)", idKonfParameter, napravlParameter);
        }
    
        [DbFunction("Оргкомитет_конференцииEntities", "budget")]
        public virtual IQueryable<budget_Result> budget(Nullable<int> idKonf, Nullable<int> countSbornik, Nullable<double> hour, Nullable<double> countStaff)
        {
            var idKonfParameter = idKonf.HasValue ?
                new ObjectParameter("idKonf", idKonf) :
                new ObjectParameter("idKonf", typeof(int));
    
            var countSbornikParameter = countSbornik.HasValue ?
                new ObjectParameter("countSbornik", countSbornik) :
                new ObjectParameter("countSbornik", typeof(int));
    
            var hourParameter = hour.HasValue ?
                new ObjectParameter("hour", hour) :
                new ObjectParameter("hour", typeof(double));
    
            var countStaffParameter = countStaff.HasValue ?
                new ObjectParameter("countStaff", countStaff) :
                new ObjectParameter("countStaff", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<budget_Result>("[Оргкомитет_конференцииEntities].[budget](@idKonf, @countSbornik, @hour, @countStaff)", idKonfParameter, countSbornikParameter, hourParameter, countStaffParameter);
        }
    }
}
