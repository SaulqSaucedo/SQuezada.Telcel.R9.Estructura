﻿using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
