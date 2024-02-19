using TesteV2.Data.Contexts;
using TesteV2.Entities;
using TesteV2.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using TesteV2.Data.Queries;
namespace TesteV2.Data.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppMySqlDbContext _mySqlContext;
        public UsuariosRepository(AppMySqlDbContext mySqlContext) => _mySqlContext = mySqlContext;

        public async Task Create(Usuarios usuario)
        {
            _mySqlContext.Usuarios.Add(usuario);
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task Delete(Usuarios usuario)
        {
            _mySqlContext.Entry(usuario).State = EntityState.Deleted;
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuarios>> ReadAll(Usuarios filter)
        {
            return await _mySqlContext.Usuarios.FilterById(filter.Id)
                                               .FilterByUserName(filter.UserName)
                                               .FilterByEmail(filter.UserName)
                                               .FilterByTelefone(filter.Telefone)
                                               .ToListAsync();
        }

        public async Task<Usuarios?> ReadByEmail(string email)
        {
            return await _mySqlContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Usuarios?> ReadById(int id)
        {
            return await _mySqlContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Usuarios usuario)
        {
            _mySqlContext.Entry(usuario).State = EntityState.Modified;
            await _mySqlContext.SaveChangesAsync();
        }
    }
}
