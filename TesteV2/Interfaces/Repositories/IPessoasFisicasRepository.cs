using TesteV2.Entities;

namespace TesteV2.Interfaces.Repositories
{
    public interface IPessoasFisicasRepository
    {
        Task Create(PessoasFisicas pessoasFisicas);
        Task Delete(PessoasFisicas pessoasFisicas);
        Task Update(PessoasFisicas pessoasFisicas);
        Task<PessoasFisicas?> ReadByEmail(string email);
        Task<PessoasFisicas?> ReadByCpf(string cpf);
        Task<PessoasFisicas?> ReadById(int id);
        Task<IEnumerable<PessoasFisicas>> ReadAll(PessoasFisicas filter);
    }
}
