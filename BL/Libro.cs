using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.LibroGetAll().ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = obj.IdLibro;
                            libro.Titulo = obj.Titulo;
                            libro.AñoPublicacion = obj.AñoPublicacion;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Nombre;

                            
                            list.Add(libro);
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

        public static bool Add(ML.AutorLibro autorLibro)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.LibroAdd(autorLibro.Libro.Titulo, autorLibro.Libro.AñoPublicacion, autorLibro.Libro.Editorial.IdEditorial, autorLibro.Autor.IdAutor);
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
                    var query = context.LibroUpdate(autorLibro.IdAutorLibro,autorLibro.Libro.IdLibro, autorLibro.Libro.Titulo, autorLibro.Libro.AñoPublicacion, autorLibro.Libro.Editorial.IdEditorial, autorLibro.Autor.IdAutor);
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
                    var query = context.LibroDelete(IdAutorLibro);
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
    }
}
