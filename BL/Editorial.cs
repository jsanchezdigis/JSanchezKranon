using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezKranonEntities context = new DL.JSanchezKranonEntities())
                {
                    var query = context.EditorialGetAll().ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Editorial editorial = new ML.Editorial();
                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.Nombre = obj.Nombre;

                            list.Add(editorial);
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
