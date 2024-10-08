using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongoDB.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }  
       
        [BsonElement("Nome")]
        public string? Nome { get; set; } = null; 

        [BsonElement("Preco")]
        public string? Preco { get; set; }

        [BsonElement("Descricao")]
        public string? Descricao { get; set; } = null; 
    }
}
