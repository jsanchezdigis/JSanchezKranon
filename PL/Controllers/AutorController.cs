using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult GetAll()
        {
            ML.Autor autor = new ML.Autor();
            List<object> list = BL.Autor.GetAll();

            if (list != null)
            {
                autor.Autores = list;
                return View(autor);
            }
            else
            {
                return View(autor);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdAutor)
        {
            ML.Autor autor = new ML.Autor();
            if (IdAutor == null)
            {
                return View();
            }
            else
            {
                //GetById
                object list = BL.Autor.GetById(IdAutor.Value);
                if (list != null)
                {
                    autor = (ML.Autor)list;

                    return View(autor);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Autor autor)
        {

            bool correct = false;

            if (autor.IdAutor == 0)
            {
                //Add
                correct = BL.Autor.Add(autor);

                if (correct == true)
                {
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                //return View("Modal");
                return RedirectToAction("GetAll");
            }
            else
            {
                //Update
                correct = BL.Autor.Update(autor);
                if (correct == true)
                {
                    ViewBag.Message = "Se actualizo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
                return View("Modal");
            }
        }
        public ActionResult Delete(int IdAutor)
        {
            bool correct = false;
            correct = BL.Autor.Delete(IdAutor);
            if (correct == true)
            {
                ViewBag.Message = "Se actualizo el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al actualizar el registro";
            }
            return View("Modal");
        }
    }
}