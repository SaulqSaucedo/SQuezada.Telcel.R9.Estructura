using Microsoft.EntityFrameworkCore;

namespace Telcel.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            Empleado objEmpleado = new Empleado();
                            objEmpleado.IdEmpleado = obj.IdEmpleado;
                            objEmpleado.Nombre = obj.Nombre;
                            objEmpleado.ApellidoPaterno = obj.ApellidoPaterno;
                            objEmpleado.ApellidoMaterno = obj.ApellidoMaterno;
                            objEmpleado.Puesto = new Puesto();
                            objEmpleado.Puesto.IdPuesto = obj.IdPuesto;
                            objEmpleado.Puesto.Nombre = obj.PuestoNombre;
                            objEmpleado.Departamento = new Departamento();
                            objEmpleado.Departamento.IdDepartamento = obj.IdDepartamento;
                            objEmpleado.Departamento.Nombre = obj.DepartamentoNombre;

                            result.Objects.Add(objEmpleado);
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
        public static Result GetById(int IdEmpleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetById").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado objEmpleado = new Empleado();
                            objEmpleado.IdEmpleado = obj.IdEmpleado;
                            objEmpleado.Nombre = obj.Nombre;
                            objEmpleado.ApellidoPaterno = obj.ApellidoPaterno;
                            objEmpleado.ApellidoMaterno = obj.ApellidoMaterno;
                            objEmpleado.Puesto = new Puesto();
                            objEmpleado.Puesto.IdPuesto = obj.IdPuesto;
                            objEmpleado.Puesto.Nombre = obj.PuestoNombre;
                            objEmpleado.Departamento = new Departamento();
                            objEmpleado.Departamento.IdDepartamento = obj.IdDepartamento;
                            objEmpleado.Departamento.Nombre = obj.DepartamentoNombre;

                            result.Objects.Add(objEmpleado);
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
        public static Result GetEmpleado(Negocio.Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetNombre '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}'").ToList();
                
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado objEmpleado = new Empleado();
                            objEmpleado.IdEmpleado = obj.IdEmpleado;
                            objEmpleado.Nombre = obj.Nombre;
                            objEmpleado.ApellidoPaterno = obj.ApellidoPaterno;
                            objEmpleado.ApellidoMaterno = obj.ApellidoMaterno;
                            objEmpleado.Puesto = new Puesto();
                            objEmpleado.Puesto.IdPuesto = obj.IdPuesto;
                            objEmpleado.Puesto.Nombre = obj.PuestoNombre;
                            objEmpleado.Departamento = new Departamento();
                            objEmpleado.Departamento.IdDepartamento = obj.IdDepartamento;
                            objEmpleado.Departamento.Nombre = obj.DepartamentoNombre;

                            result.Objects.Add(objEmpleado);
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
        public static Result Add(Negocio.Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");
                
                    if(query > 0)
                    {
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
        public static Result Delete(int IdEmpleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.SQuezadaEstructuraContext context = new AccesoDatos.SQuezadaEstructuraContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");

                    if(query > 0)
                    {
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