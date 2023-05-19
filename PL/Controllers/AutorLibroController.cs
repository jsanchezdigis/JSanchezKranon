using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PL.Controllers
{
    public class AutorLibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.AutorLibro autorLibro = new ML.AutorLibro();
            autorLibro.Autor = new ML.Autor();
            autorLibro.Libro = new ML.Libro();
            autorLibro.Libro.Editorial = new ML.Editorial();
            List<object> list = BL.AutorLibro.GetAll();
            List<object> listAutor = BL.Autor.GetAll();
            List<object> listEditorial = BL.Editorial.GetAll();

            if (list != null)
            {
                autorLibro.AutoresLibros = list;
                autorLibro.Autor.Autores = listAutor;
                autorLibro.Libro.Editorial.Editoriales = listEditorial;
                return View(autorLibro);
            }
            else
            {
                return View(autorLibro);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdAutorLibro)
        {

            List<object> listAutor = BL.Autor.GetAll();
            List<object> listLibro = BL.Libro.GetAll();
            List<object> listEditorial = BL.Editorial.GetAll();

            ML.AutorLibro autorLibro = new ML.AutorLibro();
            autorLibro.Autor = new ML.Autor();
            autorLibro.Libro = new ML.Libro();
            autorLibro.Libro.Editorial = new ML.Editorial();

            if (listAutor != null && listLibro != null)
            {
                autorLibro.Autor.Autores = listAutor;
                autorLibro.Libro.Libros = listLibro;
                autorLibro.Libro.Editorial.Editoriales = listEditorial;
            }
            if (IdAutorLibro == null)
            {
                return View(autorLibro);
            }
            else
            {
                //GetById
                object list = BL.AutorLibro.GetById(IdAutorLibro.Value);
                if (list != null)
                {
                    //autorLibro.AutoresLibros = list;
                    autorLibro = (ML.AutorLibro)list;
                    autorLibro.Autor.Autores = listAutor;
                    autorLibro.Libro.Libros = listLibro;
                    autorLibro.Libro.Editorial.Editoriales = listEditorial;

                    return View(autorLibro);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.AutorLibro autorLibro)
        {

            bool correct = false;

            if (autorLibro.Libro.IdLibro == 0)
            {
                //Add
                correct = BL.Libro.Add(autorLibro);

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
                correct = BL.Libro.Update(autorLibro);
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
        public ActionResult Delete(int IdAutorLibro)
        {
            bool correct = false;
            correct = BL.Libro.Delete(IdAutorLibro);
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
        [HttpPost]
        public ActionResult GetAll(ML.AutorLibro autorLibro)
        {
            List<object> list = BL.AutorLibro.GetByBusqueda(autorLibro);
            autorLibro.Autor = new ML.Autor();
            autorLibro.Libro = new ML.Libro();
            autorLibro.Libro.Editorial = new ML.Editorial();
            List<object> listAutor = BL.Autor.GetAll();
            List<object> listEditorial = BL.Editorial.GetAll();

            if (list != null)
            {
                autorLibro.AutoresLibros = list;
                autorLibro.Autor.Autores = listAutor;
                autorLibro.Libro.Editorial.Editoriales = listEditorial;
                return View(autorLibro);
            }
            else
            {
                return View(autorLibro);
            }
        }
    }
}