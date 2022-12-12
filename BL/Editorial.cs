using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.EditorialGetAll();
                    result.Objects = new List<object>();

                    if (codigo != null)
                    {
                        foreach (var obj in codigo)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.NombreEditorial = obj.Nombre;

                            result.Objects.Add(editorial);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
