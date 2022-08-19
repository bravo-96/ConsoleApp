using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Services.Services.Interfaces
{
    public interface IColorService
    {
        ColorDTO Insert( ColorDTO model );
        ColorDTO Update( ColorDTO model );
        Task Delete( int id );
        IEnumerable<ColorDTO> GetAll();
        ColorDTO GetById( int id );
    }
}
