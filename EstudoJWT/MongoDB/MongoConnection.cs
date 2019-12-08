using EstudoJWT.MongoDB.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudoJWT.MongoDB
{
    public class MongoConnection
    {
        private const string DATABASE_NAME = "JWTTeste";
        private const string COLLECTION_NAME_USUARIO = "Usuario";

        private readonly IMongoDatabase mongoDatabase;

        public MongoConnection()
        {
            var cliente = new MongoClient("mongodb://localhost:27017");
            mongoDatabase = cliente.GetDatabase(DATABASE_NAME);
            CreateIndex();
        }

        public IMongoCollection<Usuario> GetCollectionUsuario() =>        
            mongoDatabase.GetCollection<Usuario>(COLLECTION_NAME_USUARIO);

        public void CreateIndex()
        {
            GetCollectionUsuario().Indexes.CreateOne(Builders<Usuario>.IndexKeys.Ascending(u => u.Email));
        }
        
    }
}