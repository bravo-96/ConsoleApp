using ConsoleApp.Services.DTO;

namespace ConsoleApp.Services.Services
{
    public class SeguroDTO : IDTOInterface
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
