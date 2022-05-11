using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public List<object> Puestos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Puestos.FromSqlRaw("PuestoGetAll").ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Puesto puesto = new Puesto();
                            puesto.IdPuesto = item.IdPuesto;
                            puesto.Nombre = item.Nombre;

                            result.Objects.Add(puesto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMesagge = ex.Message;
            }
            return result;
        }
    }
}