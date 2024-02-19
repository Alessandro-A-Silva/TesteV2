using TesteV2.Entities;

namespace TesteV2.Data.Queries
{
    public static class PessoasFisicasQuery
    {
        public static IQueryable<PessoasFisicas> FilterById(this IQueryable<PessoasFisicas> query, int id)
        {
            if (id > 0)
                return query.Where(x => x.Id == id);

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterByNome(this IQueryable<PessoasFisicas> query, string? nome)
        {
            if (!string.IsNullOrEmpty(nome))
                return query.Where(x => x.Nome.Contains(nome));

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterBySobrenom(this IQueryable<PessoasFisicas> query, string? sobrenome)
        {
            if (!string.IsNullOrEmpty(sobrenome))
                return query.Where(x => x.Sobrenome.Contains(sobrenome));

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterByDataNascimento(this IQueryable<PessoasFisicas> query, DateTime? dataNascimento)
        {
            if (dataNascimento != null)
                return query.Where(x => x.DataNascimento == dataNascimento);

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterByEmail(this IQueryable<PessoasFisicas> query, string? email)
        {
            if (!string.IsNullOrEmpty(email))
                return query.Where(x => x.Email.Contains(email));

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterByCpf(this IQueryable<PessoasFisicas> query, string? cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
                return query.Where(x => x.Cpf == cpf);

            return query;
        }

        public static IQueryable<PessoasFisicas> FilterByRg(this IQueryable<PessoasFisicas> query, string? rg)
        {
            if (!string.IsNullOrEmpty(rg))
                return query.Where(x => x.Rg == rg);

            return query;
        }
    }
}
