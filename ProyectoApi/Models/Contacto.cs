namespace ProyectoApi.Models
{
    public class Contacto
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
