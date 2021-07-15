using System;
using System.Collections.Generic;

namespace Entity
{
    public class PersonalEntity
    {
        public Guid PersonalId { get; set; }
        public string Dni { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ICollection<HijosEntity> Hijos { get; set; }
    }
}