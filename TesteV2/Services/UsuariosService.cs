using TesteV2.Entities;
using TesteV2.Interfaces.Repositories;
using TesteV2.Interfaces.Services;
using TesteV2.Request.Usuarios;

namespace TesteV2.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuariosService(IUsuariosRepository usuariosRepository) => _usuariosRepository = usuariosRepository;

        public async Task Create(PostUsuarios request)
        {
            var memoryStream = new MemoryStream();
            request.Imagem.CopyTo(memoryStream);

            var usuario = new Usuarios()
            {
                UserName = request.UserName,
                Email = request.Email,
                Telefone = request.Telefone,
                Senha = request.Senha,
                Imagem = memoryStream.ToArray()
            };
            
            await _usuariosRepository.Create(usuario);
        }

        public async Task Delete(int id)
        {
            var usuario = await _usuariosRepository.ReadById(id);
            await _usuariosRepository.Delete(usuario);
        }

        public async Task<IEnumerable<Usuarios>> ReadAll(Usuarios filter)
        {
            return await _usuariosRepository.ReadAll(filter);
        }

        public async Task<Usuarios?> ReadByEmail(string email)
        {
            return await _usuariosRepository.ReadByEmail(email);
        }

        public async Task Update(Usuarios usuarios)
        {
            await _usuariosRepository.Update(usuarios);
        }
    }
}
