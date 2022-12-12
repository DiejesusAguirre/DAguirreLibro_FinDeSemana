using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            Console.WriteLine("Ingrese el Nombre del Libro: \n");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del Autor: \n");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese El de Numero de Pagnas: \n");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la Fecha de Publicacion: \n");
            libro.FechaDePublicacion = Console.ReadLine();
            Console.WriteLine("Ingresa el ID del Editorial: \n");
            libro.Editorial.IdEditorial= int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la Edicion del Libro: \n");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del Genero del Libro: \n");
            libro.Genero.IdGenero= int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                Console.WriteLine("El Libro se Registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Libro no se Registro correctamente");
                Console.ReadKey();
            }
        }
        public static void Update()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            Console.WriteLine("Ingrese el ID del libro que desee actualizar: \n");
            libro.IdLibro= int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo Nombre del Libro: \n");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ID del Autor: \n");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese El nuevo de Numero de Pagnas: \n");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la nuevo Fecha de Publicacion: \n");
            libro.FechaDePublicacion = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo ID del Editorial: \n");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la nuevo Edicion del Libro: \n");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ID del Genero del Libro: \n");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Libro.Update(libro);
            if (result.Correct)
            {
                Console.WriteLine("El Libro se Actualizo correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Libro no se Actualizo correctamente");
                Console.ReadKey();
            }
        }
        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            Console.WriteLine("Ingrese el ID del libro que desee eliminar: \n");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Libro.Delete(libro);
            if (result.Correct)
            {
                Console.WriteLine("El Libro se Elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Libro no se Registro correctamente");
                Console.ReadKey();
            }
        }
        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();
            if (result.Correct)
            {
                foreach(ML.Libro libro in result.Objects) 
                {
                    Console.WriteLine("El ID del Libro es: " + libro.IdLibro);
                    Console.WriteLine("El Nombre del Libro es: " + libro.Nombre);
                    Console.WriteLine("El Nombre del Autor es: " + libro.Autor.NombreAutor);
                    Console.WriteLine("El numero de Paginas del libro son: " + libro.NumeroPaginas);
                    Console.WriteLine("La fecha de publicacion es: " + libro.FechaDePublicacion);
                    Console.WriteLine("El Nombre de la Editorial es: " + libro.Editorial.NombreEditorial);
                    Console.WriteLine("La Edicion del libro es: " + libro.Edicion);
                    Console.WriteLine("El Genero del Libro es: " + libro.Genero.NombreGenero + "\n \n");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error en la ejecucion");
            }
        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el ID del libro que desee que se muestre: \n");
            int IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Libro.GetById(IdLibro);
            if (result.Correct)
            {
                ML.Libro libro = new ML.Libro();

                libro = (ML.Libro)result.Object;

                Console.WriteLine("El ID del Libro es: " + libro.IdLibro);
                Console.WriteLine("El Nombre del Libro es: " + libro.Nombre);
                Console.WriteLine("El Nombre del Autor es: " + libro.Autor.NombreAutor);
                Console.WriteLine("El numero de Paginas del libro son: " + libro.NumeroPaginas);
                Console.WriteLine("La fecha de publicacion es: " + libro.FechaDePublicacion);
                Console.WriteLine("El Nombre de la Editorial es: " + libro.Editorial.NombreEditorial);
                Console.WriteLine("La Edicion del libro es: " + libro.Edicion);
                Console.WriteLine("El Genero del Libro es: " + libro.Genero.NombreGenero);
            }
            else
            {
                Console.WriteLine("Ocurrio un error en la ejecucion");
            }
        }
    }
}
