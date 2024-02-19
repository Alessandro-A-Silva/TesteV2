using TesteV2.Entities;
using TesteV2.Request.Usuarios;

namespace TesteV2.Interfaces.Services
{
    public interface IUsuariosService
    {
        Task Create(PostUsuarios request);
        Task<Usuarios?> ReadByEmail(string email);
        Task<IEnumerable<Usuarios>> ReadAll(Usuarios filter);
        Task Delete(int id);
        Task Update(Usuarios usuarios);
    }
}
