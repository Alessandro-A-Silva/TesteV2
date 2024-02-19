using TesteV2.Entities;
using TesteV2.Request.PessoasFisicas;

namespace TesteV2.Interfaces.Services
{
    public interface IPessoasFisicasService
    {
        Task Create(PostPessoasFisicas request);
        Task<PessoasFisicas?> ReadByEmail(string email);
        Task<PessoasFisicas?> ReadByCpf(string cpf);
        Task<IEnumerable<PessoasFisicas>> ReadAll(GetPessoasFisicas filter);
        Task Delete(int id);
        Task Update(PessoasFisicas pessoasFisicas);
    }
}
