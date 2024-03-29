﻿using Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IDatabaseContext
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }

    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoClient _сlient;

        public DatabaseContext(IOptions<DatabaseSettings> configuration)
        {
            _сlient = new MongoClient(configuration.Value.ConnectionString);
            _db = _сlient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _db.GetCollection<T>(name);
    }
}
