using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Vani.Services
{
    public interface IStockerAzureStorage
    {
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> EditarArchivo(string contenedor, IFormFile archivo, string ruta);
        Task<string> GuardarArchivo(string contenedor, IFormFile archivo);
    }
}