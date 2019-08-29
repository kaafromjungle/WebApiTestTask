﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiTestTask.Model
{
    public class Employee
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Phone { get; set; } 
        public int CompanyId { get; set; }
        public Passport Passport { get; set; } 
    }

    public class Passport
    {
        public string Type { get; set; } 
        public string Number { get; set; } 
    }
}