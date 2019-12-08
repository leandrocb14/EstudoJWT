using EstudoJWT.MongoDB;
using EstudoJWT.MongoDB.Model;
using MongoDB.Driver;

namespace EstudoJWT.DAO
{
    public class UsuarioDAO
    {
        private readonly IMongoCollection<Usuario> collectionUsuario;

        public UsuarioDAO()
        {
            MongoConnection mongoConnection = new MongoConnection();
            collectionUsuario = mongoConnection.GetCollectionUsuario();
        }

        public void Adicionar(Usuario pUsuario)
        {
            collectionUsuario.InsertOne(pUsuario);
        }

        public void AlterarUsuario(Usuario pUsuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Id, pUsuario.Id);
            var update = Builders<Usuario>.Update.Set(u => u, pUsuario);
            collectionUsuario.UpdateOne(filter, update);
        }

        public Usuario BuscaUsuarioPorEmail(string pEmail)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Email, pEmail);
            return collectionUsuario.Find(filter).FirstOrDefault();
        }

        public Usuario BuscaUsuarioPorEmailESenha(Usuario pUsuario)
        {
            var usuarioFilter = Builders<Usuario>.Filter;
            var filter = usuarioFilter.And(
                usuarioFilter.Eq(u => u.Email, pUsuario.Email),
                usuarioFilter.Eq(u => u.Senha, pUsuario.Senha)
            );
            return collectionUsuario.Find(filter).FirstOrDefault();
        }
    }
}