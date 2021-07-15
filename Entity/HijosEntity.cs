using System;

namespace Entity
{
    public class HijosEntity
    {
        public Guid DerHabId { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreCompleto { get; set; }
        public Guid PersonalId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        //Personal
        public PersonalEntity Personal { get; set; }
    }
}