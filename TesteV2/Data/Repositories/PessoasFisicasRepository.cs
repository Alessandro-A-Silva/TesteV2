using Microsoft.EntityFrameworkCore;
using TesteV2.Data.Contexts;
using TesteV2.Data.Queries;
using TesteV2.Entities;
using TesteV2.Interfaces.Repositories;

namespace TesteV2.Data.Repositories
{
    public class PessoasFisicasRepository : IPessoasFisicasRepository
    {
        private readonly AppMySqlDbContext _context;
        public PessoasFisicasRepository(AppMySqlDbContext context) => _context = context;

        public async Task Create(PessoasFisicas pessoasFisicas)
        {
            _context.PessoasFisicas.Add(pessoasFisicas);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PessoasFisicas pessoasFisicas)
        {
            _context.Entry(pessoasFisicas).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PessoasFisicas>> ReadAll(PessoasFisicas filter)
        {
            return await  _context.PessoasFisicas.FilterById(filter.Id)
                                                 .FilterByNome(filter.Nome)
                                                 .FilterBySobrenom(filter.Sobrenome)
                                                 .FilterByDataNascimento(filter.DataNascimento)
                                                 .FilterByEmail(filter.Email)
                                                 .FilterByCpf(filter.Cpf)
                                                 .FilterByRg(filter.Rg)
                                                 .Include(x => x.Enderecos)
                                                 .Include(x => x.Contatos)
                                                 .ToListAsync();
        }

        public async Task<PessoasFisicas?> ReadByCpf(string cpf)
        {
            return await _context.PessoasFisicas.Include(x => x.Enderecos)
                                                .Include(x => x.Contatos)
                                                .FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<PessoasFisicas?> ReadByEmail(string email)
        {
            return await _context.PessoasFisicas.Include(x => x.Enderecos)
                                                .Include(x => x.Contatos)
                                                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<PessoasFisicas?> ReadById(int id)
        {
            return await _context.PessoasFisicas.Include(x => x.Enderecos)
                                                .Include(x => x.Contatos)
                                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(PessoasFisicas pessoasFisicas)
        {
            _context.Entry(pessoasFisicas).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
