﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Result
    {
        public bool Correct { get; set; }
        public Exception Ex { get; set; }
        public string ErrorMesagge { get; set; }
        public List<object> Objects { get; set; }
        public object Object { get; set; }
    }
}