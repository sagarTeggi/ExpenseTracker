﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExpenseTracker.Models
{
    //[Table("Tb_Category")]
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("categoryName")]
        public string? CategoryName { get; set; }
    }
}
