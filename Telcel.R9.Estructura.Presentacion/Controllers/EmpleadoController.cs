using Microsoft.AspNetCore.Mvc;
//using Negocio = Telcel.R9.Estructura.Negocio;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult GetAll()
        {
            Telcel.R9.Estructura.Negocio.Empleado empleado = new Telcel.R9.Estructura.Negocio.Empleado();
            empleado.Nombre = (empleado.Nombre == "") ? null : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == "") ? null : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == "") ? null : empleado.ApellidoMaterno;

            Negocio.Result result = Negocio.Empleado.GetEmpleado(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            return PartialView("");
        }
        [HttpPost]
        public IActionResult GetAll(Negocio.Empleado empleado)
        {
            empleado.Nombre = (empleado.Nombre == "") ? null : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == "") ? null : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == "") ? null : empleado.ApellidoMaterno;

            Negocio.Result result = Negocio.Empleado.GetEmpleado(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            return PartialView("ValidationModal");
        }
        public IActionResult Form(int? IdEmpleado)
        {
            //Negocio.Result result = new Negocio.Result();
            Negocio.Empleado empleado = new Negocio.Empleado();
            empleado.Puesto = new Negocio.Puesto();
            Negocio.Result resultNegocio = Negocio.Puesto.GetAll();
            Negocio.Result resultDepartamento = Negocio.Departamento.GetAll();
            empleado.Departamento = new Negocio.Departamento();
            if (IdEmpleado == null)
            {
                empleado.Puesto.Puestos = resultNegocio.Objects;
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                return View(empleado);
            }
            return PartialView("ValidationModal");
        }
        [HttpPost]
        public IActionResult Form(Negocio.Empleado empleado)
        {
            if(empleado.IdEmpleado == 0)
            {
                Negocio.Result result = Negocio.Empleado.Add(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro ingresado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al intentar ingresar el registro " + result.ErrorMesagge;
                }
            }
            return PartialView("ValidationModal");
        }
        public IActionResult Delete(int IdEmpleado)
        {
            Negocio.Result result = Negocio.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                ViewBag.Message = "Registro eliminado correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al intentar eliminar el registro " +result.ErrorMesagge;
            }
            return PartialView("ValidationModal");
        }
    }
}