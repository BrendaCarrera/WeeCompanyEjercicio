using System.ComponentModel.DataAnnotations;

namespace WeeCompanyEjercicio.Models
{
    public class ModelDatos
    {
        //para que acepte nulos ?
        public int Id { get; set; }
        [Required]
        public string Compania { get; set; }
        [Required]
        public string Contacto { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }
    }
}
