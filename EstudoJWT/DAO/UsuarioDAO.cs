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

    }
}