using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorGetAll().ToList();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Autor autor = new ML.Autor();
                            autor.IdAutor = obj.IdAutor;
                            autor.Nombre = obj.Nombre;
                            list.Add(autor);
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
        public static object GetById(int IdAutor)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorGetById(IdAutor).FirstOrDefault();
                    if (query != null)
                    {
                        var obj = query;
                        ML.Autor autor = new ML.Autor();
                        autor.IdAutor = obj.IdAutor;
                        autor.Nombre = obj.Nombre;
                        list = autor;
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static bool Add(ML.Autor autor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorAdd(autor.Nombre);
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
        public static bool Update(ML.Autor autor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorUpdate(autor.IdAutor,autor.Nombre);
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
        public static bool Delete(int IdAutor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.AutorDelete(IdAutor);
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
