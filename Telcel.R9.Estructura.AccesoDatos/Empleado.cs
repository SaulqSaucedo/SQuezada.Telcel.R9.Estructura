using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public int IdPuesto { get; set; }
        public int IdDepartamento { get; set; }
        public string? PuestoNombre { get; set; }
        public string? DepartamentoNombre { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Puesto IdPuestoNavigation { get; set; } = null!;
    }
}
