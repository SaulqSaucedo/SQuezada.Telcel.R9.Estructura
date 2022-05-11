using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public List<object> Departamentos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Departamentos.FromSqlRaw("DepartamentoGetAll").ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            Departamento departamento = new Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            result.Objects.Add(departamento);
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