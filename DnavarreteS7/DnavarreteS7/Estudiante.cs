﻿using System;
using SQLite;
namespace DnavarreteS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Usuario { get; set; }

        [MaxLength(255)]
        public string Contrasenia { get; set; }
    }
}

