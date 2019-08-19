using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppMvvm.Models
{
    public class ItemInspeccion
    {
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string Tipo { get; set; }
        public bool RequiereFoto { get; set; }
        public bool Deshabilitable { get; set; }
    }
}