using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();

            ML.Result result = BL.Libro.GetAllEF();
            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Algo ocurrio" + result.ErrorMessage;
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
            ML.Result resultAutor = BL.Autor.GetAllEF();
            ML.Result resultEditorial = BL.Editorial.GetAllEF();
            ML.Result resultGenero = BL.Genero.GetAllEF();

            if (IdLibro == null)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutor.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                    libro.Genero.Generos = resultGenero.Objects;
                }
                else
                {
                    ViewBag.Message = "No existe ese libro";
                }
            }

            return View(libro);
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            if (libro.IdLibro == 0)
            {
                result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                result = BL.Libro.UpdateEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha actualizado correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int? IdLibro)
        {
            ML.Result result = new ML.Result();

            if (IdLibro == null)
            {
                ViewBag.Message = "Algo Ocurrio";
                return PartialView("Modal");
            }
            else
            {
                result = BL.Libro.DeleteEF(IdLibro.Value);
                if (result.Correct)
                {
                    ViewBag.Message = "Se elimino correctamente";
                    return PartialView("Modal");
                }

                else
                {
                    ViewBag.Message = "Algo ocurrio" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }
    }
}