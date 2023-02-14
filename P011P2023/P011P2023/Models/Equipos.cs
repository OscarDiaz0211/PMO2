using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace P011P2023.Models
{
    public class Equipos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [MaxLength(60)]
        public string Nombre { get; set; }

        [MaxLength(60)]
        public DateTime Fundacion { get; set; }

        [MaxLength(60)]
        public string Correo { get; set; }

        public Byte[] Logo { get; set; }

        [MaxLength(60)]
        public string Categoria { get; set; }


    }
}
