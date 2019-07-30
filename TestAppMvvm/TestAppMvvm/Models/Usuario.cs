using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppMvvm.Models
{
    public class Usuario
    {

        [PrimaryKey, AutoIncrement]
        public int ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        [MaxLength(100)]
        public string CLAVE { get; set; }
        public string IMAGEN { get; set; }

    }
}
