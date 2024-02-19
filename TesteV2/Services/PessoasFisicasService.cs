using TesteV2.Entities;
using TesteV2.Interfaces.Repositories;
using TesteV2.Interfaces.Services;
using TesteV2.Request.PessoasFisicas;

namespace TesteV2.Services
{
    public class PessoasFisicasService : IPessoasFisicasService
    {
        private readonly IPessoasFisicasRepository _pessoasFisicasRepository;
        public PessoasFisicasService(IPessoasFisicasRepository pessoasFisicasRepository) => _pessoasFisicasRepository = pessoasFisicasRepository;

        public async Task Create(PostPessoasFisicas request)
        {
            var pessoasFisicas = new PessoasFisicas()
            {
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                DataNascimento = request.DataNascimento,
                Email = request.Email,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Enderecos = request.Enderecos.Select(x => new Enderecos()
                {
                    Logradouro = x.Logradouro,
                    Numero = x.Numero,
                    Cep = x.Cep,
                    Cidade = x.Cidade,
                    Complemento = x.Complemento,
                    Estado = x.Estado,

                }).ToList(),
                Contatos = request.Contatos.Select(x => new Contatos()
                {
                    Nome = x.Nome,
                    Contato = x.Contato,
                    TipoContato = x.Contato,
                }).ToList()
            };
            await _pessoasFisicasRepository.Create(pessoasFisicas);
        }

        public async Task Delete(int id)
        {
            var pessoasFisicas = await _pessoasFisicasRepository.ReadById(id);
            await _pessoasFisicasRepository.Delete(pessoasFisicas);
        }

        public async Task<IEnumerable<PessoasFisicas>> ReadAll(GetPessoasFisicas filter)
        {
            return await _pessoasFisicasRepository.ReadAll(new PessoasFisicas()
            {
                Id = filter.Id,
                Nome = filter.Nome,
                Sobrenome = filter.Sobrenome,
                DataNascimento = filter.DataNascimento,
                Email = filter.Email,
                Cpf = filter.Cpf,
                Rg = filter.Rg
            });
        }

        public async Task<PessoasFisicas?> ReadByCpf(string cpf)
        {
            return await _pessoasFisicasRepository.ReadByCpf(cpf);
        }

        public async Task<PessoasFisicas?> ReadByEmail(string email)
        {
            return await _pessoasFisicasRepository.ReadByEmail(email);
        }

        public async Task Update(PessoasFisicas pessoasFisicas)
        {
            await _pessoasFisicasRepository.Update(pessoasFisicas);
        }
    }
}
