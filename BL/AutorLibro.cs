using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AutorLibro
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorLibroGetAll().ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AutorLibro autorLibro = new ML.AutorLibro();
                            autorLibro.IdAutorLibro = obj.IdAutorLibro;
                            autorLibro.Autor = new ML.Autor();
                            autorLibro.Autor.IdAutor = obj.IdAutor;
                            autorLibro.Autor.Nombre = obj.Autor;

                            autorLibro.Libro = new ML.Libro();
                            autorLibro.Libro.IdLibro = obj.IdLibro;
                            autorLibro.Libro.Titulo = obj.Titulo;
                            autorLibro.Libro.AñoPublicacion = obj.AñoPublicacion;

                            autorLibro.Libro.Editorial = new ML.Editorial();
                            autorLibro.Libro.Editorial.IdEditorial = obj.IdEditorial;
                            autorLibro.Libro.Editorial.Nombre = obj.Editorial;
                            list.Add(autorLibro);
                        }
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static object GetById(int IdAutorLibro)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorLibroGetById(IdAutorLibro).FirstOrDefault();
                    if (query != null)
                    {
                        var obj = query;

                        ML.AutorLibro autorLibro = new ML.AutorLibro();
                        autorLibro.IdAutorLibro = obj.IdAutorLibro;
                        autorLibro.Autor = new ML.Autor();
                        autorLibro.Autor.IdAutor = obj.IdAutor;
                        autorLibro.Autor.Nombre = obj.Autor;

                        autorLibro.Libro = new ML.Libro();
                        autorLibro.Libro.IdLibro = obj.IdLibro;
                        autorLibro.Libro.Titulo = obj.Titulo;
                        autorLibro.Libro.AñoPublicacion = obj.AñoPublicacion;

                        autorLibro.Libro.Editorial = new ML.Editorial();
                        autorLibro.Libro.Editorial.IdEditorial = obj.IdEditorial;
                        autorLibro.Libro.Editorial.Nombre = obj.Editorial;

                        list = autorLibro;

                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static bool Add(ML.AutorLibro autorLibro)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorLibroAdd(autorLibro.Autor.IdAutor, autorLibro.Libro.IdLibro);
                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
        public static bool Update(ML.AutorLibro autorLibro)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorLibroUpdate(autorLibro.IdAutorLibro, autorLibro.Autor.IdAutor, autorLibro.Libro.IdLibro);
                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
        public static bool Delete(int IdAutorLibro)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.LibroAutorDelete(IdAutorLibro);
                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
        public static List<object> GetByBusqueda(ML.AutorLibro autorLibro)
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.GetByBusqueda(autorLibro.Libro.Titulo,autorLibro.AñoInicio,autorLibro.AñoFin,autorLibro.Libro.Editorial.IdEditorial,autorLibro.Autor.IdAutor).ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            autorLibro = new ML.AutorLibro();
                            autorLibro.IdAutorLibro = obj.IdAutorLibro;
                            autorLibro.Autor = new ML.Autor();
                            autorLibro.Autor.IdAutor = obj.IdAutor;
                            autorLibro.Autor.Nombre = obj.Autor;

                            autorLibro.Libro = new ML.Libro();
                            autorLibro.Libro.IdLibro = obj.IdLibro;
                            autorLibro.Libro.Titulo = obj.Titulo;
                            autorLibro.Libro.AñoPublicacion = obj.AñoPublicacion;

                            autorLibro.Libro.Editorial = new ML.Editorial();
                            autorLibro.Libro.Editorial.IdEditorial = obj.IdEditorial;
                            autorLibro.Libro.Editorial.Nombre = obj.Editorial;
                            list.Add(autorLibro);
                        }
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
    }
}
