using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiTestTask.Model
{
    public class EmployeeParam
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        [BsonIgnoreIfDefault]
        public int Id { get; set; }
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string Surname { get; set; }
        [BsonIgnoreIfNull]
        public string Phone { get; set; }
        [BsonIgnoreIfDefault]
        public int CompanyId { get; set; }
        [BsonIgnoreIfNull]
        public ParamPassport Passport { get; set; }
        
    }

    public class ParamPassport
    {
        [BsonIgnoreIfNull]
        public string Type { get; set; }
        [BsonIgnoreIfNull]
        public string Number { get; set; } 
    }
}

