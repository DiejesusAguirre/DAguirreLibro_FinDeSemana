using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Que accion desee realizar: \n"
                + "1- Agregar (Add) \n"
                + "2- Actualizar (Update) \n"
                + "3- Eliminar (Delete) \n"
                + "4- Mostrar Todo (GetAll) \n"
                + "5- Mostrar algun registro con el ID (GetByID) \n");
            int x = int.Parse(Console.ReadLine());

            switch (x)
            {
                case 1:
                    PL.Libro.Add();
                    Console.ReadKey();
                    break;
                case 2:
                    PL.Libro.Update();
                    Console.ReadKey();
                    break;
                case 3:
                    PL.Libro.Delete();
                    Console.ReadKey();
                    break;
                case 4:
                    PL.Libro.GetAll();
                    Console.ReadKey();
                    break;
                case 5:
                    PL.Libro.GetById();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
