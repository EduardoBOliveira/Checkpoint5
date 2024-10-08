using CrudMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudMongoDB.Services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtoCollection;

        public ProdutoService(IOptions<ProdutoDatabaseSettings> produtoServices)
        {
            var mongoClient = new MongoClient(produtoServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(produtoServices.Value.DatabaseName);

            _produtoCollection = mongoDatabase.GetCollection<Produto>(produtoServices.Value.ProdutoCollectionName);
        }

        // Método para buscar todos os produtos
        public async Task<List<Produto>> GetAsync() =>
            await _produtoCollection.Find(_ => true).ToListAsync();

        // Método para buscar produto por Id
        public async Task<Produto> GetAsync(string id) =>
            await _produtoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Método para criar um novo produto
        public async Task CreateAsync(Produto produto) =>
            await _produtoCollection.InsertOneAsync(produto);

        // Método para atualizar um produto existente
        public async Task UpdateAsync(string id, Produto produto) =>
            await _produtoCollection.ReplaceOneAsync(x => x.Id == id, produto);

        // Método para remover um produto pelo Id
        public async Task RemoveAsync(string id) =>
            await _produtoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
