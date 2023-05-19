﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JSanchezKranonEntities : DbContext
    {
        public JSanchezKranonEntities()
            : base("name=JSanchezKranonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorLibro> AutorLibroes { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Libro> Libroes { get; set; }
    
        public virtual int AutorAdd(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorAdd", nombreParameter);
        }
    
        public virtual int AutorDelete(Nullable<int> idAutor)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorDelete", idAutorParameter);
        }
    
        public virtual ObjectResult<AutorGetAll_Result> AutorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorGetAll_Result>("AutorGetAll");
        }
    
        public virtual ObjectResult<AutorGetById_Result> AutorGetById(Nullable<int> idAutor)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorGetById_Result>("AutorGetById", idAutorParameter);
        }
    
        public virtual int AutorLibroAdd(Nullable<int> idAutor, Nullable<int> idLibro)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorLibroAdd", idAutorParameter, idLibroParameter);
        }
    
        public virtual int AutorLibroDelete(Nullable<int> idAutorLibro)
        {
            var idAutorLibroParameter = idAutorLibro.HasValue ?
                new ObjectParameter("IdAutorLibro", idAutorLibro) :
                new ObjectParameter("IdAutorLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorLibroDelete", idAutorLibroParameter);
        }
    
        public virtual ObjectResult<AutorLibroGetAll_Result> AutorLibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorLibroGetAll_Result>("AutorLibroGetAll");
        }
    
        public virtual ObjectResult<AutorLibroGetById_Result> AutorLibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorLibroGetById_Result>("AutorLibroGetById", idLibroParameter);
        }
    
        public virtual int AutorLibroUpdate(Nullable<int> idAutorLibro, Nullable<int> idAutor, Nullable<int> idLibro)
        {
            var idAutorLibroParameter = idAutorLibro.HasValue ?
                new ObjectParameter("IdAutorLibro", idAutorLibro) :
                new ObjectParameter("IdAutorLibro", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorLibroUpdate", idAutorLibroParameter, idAutorParameter, idLibroParameter);
        }
    
        public virtual int AutorUpdate(Nullable<int> idAutor, string nombre)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorUpdate", idAutorParameter, nombreParameter);
        }
    
        public virtual int EditorialAdd(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditorialAdd", nombreParameter);
        }
    
        public virtual int EditorialDelete(Nullable<int> idEditorial)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditorialDelete", idEditorialParameter);
        }
    
        public virtual ObjectResult<string> EditorialGetById(Nullable<int> idEditorial)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EditorialGetById", idEditorialParameter);
        }
    
        public virtual int EditorialUpdate(Nullable<int> idEditorial, string nombre)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditorialUpdate", idEditorialParameter, nombreParameter);
        }
    
        public virtual ObjectResult<GetByAutor_Result> GetByAutor(Nullable<int> idAutor)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByAutor_Result>("GetByAutor", idAutorParameter);
        }
    
        public virtual ObjectResult<GetByAutorPublicacion_Result> GetByAutorPublicacion(Nullable<int> idAutor, string añoPublicacion)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var añoPublicacionParameter = añoPublicacion != null ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByAutorPublicacion_Result>("GetByAutorPublicacion", idAutorParameter, añoPublicacionParameter);
        }
    
        public virtual ObjectResult<GetByEditorial_Result> GetByEditorial(Nullable<int> idEditorial)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByEditorial_Result>("GetByEditorial", idEditorialParameter);
        }
    
        public virtual ObjectResult<GetByPublicacion_Result> GetByPublicacion(string añoPublicacionInicio, string añoPublicacionFin)
        {
            var añoPublicacionInicioParameter = añoPublicacionInicio != null ?
                new ObjectParameter("AñoPublicacionInicio", añoPublicacionInicio) :
                new ObjectParameter("AñoPublicacionInicio", typeof(string));
    
            var añoPublicacionFinParameter = añoPublicacionFin != null ?
                new ObjectParameter("AñoPublicacionFin", añoPublicacionFin) :
                new ObjectParameter("AñoPublicacionFin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByPublicacion_Result>("GetByPublicacion", añoPublicacionInicioParameter, añoPublicacionFinParameter);
        }
    
        public virtual ObjectResult<GetByTitulo_Result> GetByTitulo(string titulo)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByTitulo_Result>("GetByTitulo", tituloParameter);
        }
    
        public virtual int LibroAutorDelete(Nullable<int> idAutor)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAutorDelete", idAutorParameter);
        }
    
        public virtual int LibroDelete(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDelete", idLibroParameter);
        }
    
        public virtual int LibroEditorialDelete(Nullable<int> idEditorial)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroEditorialDelete", idEditorialParameter);
        }
    
        public virtual ObjectResult<LibroGetAll_Result> LibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAll_Result>("LibroGetAll");
        }
    
        public virtual ObjectResult<LibroGetById_Result> LibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetById_Result>("LibroGetById", idLibroParameter);
        }
    
        public virtual ObjectResult<EditorialGetAll_Result> EditorialGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EditorialGetAll_Result>("EditorialGetAll");
        }
    
        public virtual int LibroAdd(string titulo, string añoPublicacion, Nullable<int> idEditorial, Nullable<int> idAutor)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var añoPublicacionParameter = añoPublicacion != null ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(string));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", tituloParameter, añoPublicacionParameter, idEditorialParameter, idAutorParameter);
        }
    
        public virtual int LibroUpdate(Nullable<int> idAutorLibro, Nullable<int> idLibro, string titulo, string añoPublicacion, Nullable<int> idEditorial, Nullable<int> idAutor)
        {
            var idAutorLibroParameter = idAutorLibro.HasValue ?
                new ObjectParameter("IdAutorLibro", idAutorLibro) :
                new ObjectParameter("IdAutorLibro", typeof(int));
    
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var añoPublicacionParameter = añoPublicacion != null ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(string));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroUpdate", idAutorLibroParameter, idLibroParameter, tituloParameter, añoPublicacionParameter, idEditorialParameter, idAutorParameter);
        }
    
        public virtual ObjectResult<GetByBusqueda_Result> GetByBusqueda(string titulo, string añoInicio, string añoFin, Nullable<int> idEditorial, Nullable<int> idAutor)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var añoInicioParameter = añoInicio != null ?
                new ObjectParameter("AñoInicio", añoInicio) :
                new ObjectParameter("AñoInicio", typeof(string));
    
            var añoFinParameter = añoFin != null ?
                new ObjectParameter("AñoFin", añoFin) :
                new ObjectParameter("AñoFin", typeof(string));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByBusqueda_Result>("GetByBusqueda", tituloParameter, añoInicioParameter, añoFinParameter, idEditorialParameter, idAutorParameter);
        }
    }
}