﻿using Home.Air.Base.Probe.Entity;
using Home.Air.Base.Sensor.Entity;

namespace Home.Air.Base.Client
{
    public interface ISensorClientService<TKey>
    {
        ProbeModel GetProbeData(SensorEntity<TKey> sensorEntity);
    }
}