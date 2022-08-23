using ConsoleApp.Services.DTO;

namespace ConsoleApp.Services.Services
{
    public class TipoDTO : IDTOInterface
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
