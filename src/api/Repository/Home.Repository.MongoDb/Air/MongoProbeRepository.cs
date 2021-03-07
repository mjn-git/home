﻿using Home.Air.Base.Probe.Entity;
using Home.Air.Base.Probe.Repository;
using Home.Repository.MongoDb.Base;
using Home.Repository.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Home.Repository.MongoDb.Air
{
    public class MongoProbeRepository : MongoDbRepository<ProbeEntity<ObjectId>>, IProbeRepository<ObjectId>
    {
        public MongoProbeRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }

        public async Task<ProbeEntity<ObjectId>> GetLatestDataAsync(ObjectId sensorId)
        {
            var sort = Builders<ProbeEntity<ObjectId>>.Sort.Descending(s => s.ProbeDate);
            var item = Collection.Find(b => b.Sensor.Id == sensorId).Sort(sort);
            return await item.FirstOrDefaultAsync();
        }
    }
}