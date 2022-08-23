using ConsoleApp.Services.DTO;

namespace ConsoleApp.Services.Services
{
    public class ModeloDTO : IDTOInterface
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
