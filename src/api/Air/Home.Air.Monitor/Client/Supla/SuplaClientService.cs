﻿using Home.Air.Base.Client;
using Home.Air.Base.Probe.Entity;
using Home.Air.Base.Sensor.Entity;
using System;
using System.Net;

namespace Home.Air.Monitor.Client.Supla
{
    public class SuplaClientService<TKey> : ISensorClientService<TKey>
    {
        public ProbeModel GetProbeData(SensorEntity<TKey> sensorEntity)
        {
            var url = sensorEntity.SensorApiAdress;
            var client = new WebClient();
            var responseString = client.DownloadString(url);
            var probe = new ProbeModel
            {
                ProbeDate = DateTime.Now
            };
            return probe;
        }
    }
}