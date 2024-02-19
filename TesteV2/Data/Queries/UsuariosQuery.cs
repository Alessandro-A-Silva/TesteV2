using TesteV2.Entities;

namespace TesteV2.Data.Queries
{
    public static class UsuariosQuery
    {
        public static IQueryable<Usuarios> FilterById(this IQueryable<Usuarios> query, int id)
        {
            if(id > 0)
                return query.Where(x => x.Id == id);

            return query;
        }

        public static IQueryable<Usuarios> FilterByUserName(this IQueryable<Usuarios> query, string? userName)
        {
            if(!string.IsNullOrEmpty(userName))
                return query.Where(x => x.UserName.Contains(userName));

            return query;
        }

        public static IQueryable<Usuarios> FilterByEmail(this IQueryable<Usuarios> query, string? email)
        {
            if (!string.IsNullOrEmpty(email))
                return query.Where(x => x.Email == email);

            return query;
        }

        public static IQueryable<Usuarios> FilterByTelefone(this IQueryable<Usuarios> query, string? telefone)
        {
            if (!string.IsNullOrEmpty(telefone))
                return query.Where(x => x.Telefone == telefone);

            return query;
        }

        public static IQueryable<Usuarios> FilterBySenha(this IQueryable<Usuarios> query, string? senha)
        {
            if (!string.IsNullOrEmpty(senha))
                return query.Where(x => x.Senha == senha);

            return query;
        }
    }
}
