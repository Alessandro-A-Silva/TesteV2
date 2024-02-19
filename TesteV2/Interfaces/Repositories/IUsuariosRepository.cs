using TesteV2.Entities;
using TesteV2.Request.Usuarios;

namespace TesteV2.Interfaces.Repositories
{
    public interface IUsuariosRepository
    {
        Task Create(Usuarios usuario);
        Task<Usuarios?> ReadByEmail(string email);
        Task<Usuarios?> ReadById(int id);
        Task<IEnumerable<Usuarios>> ReadAll(Usuarios filter);
        Task Delete(Usuarios usuario);
        Task Update(Usuarios usuario);
    }
}
