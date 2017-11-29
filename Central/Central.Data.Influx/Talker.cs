using System;
using InfluxDB.Collector;
using System.Collections.Generic;

namespace Central.Data.Influx
{
    public class Talker
    {
        public Talker()
        {
            Metrics.Collector = new CollectorConfiguration()
            .Tag.With("host", Environment.GetEnvironmentVariable("COMPUTERNAME"))
            .Batch.AtInterval(TimeSpan.FromSeconds(2))
            .WriteTo.InfluxDB("http://192.168.99.100:32770", "data")
            .CreateCollector();
        }

        public void AddMeasureEntry(string measure, Dictionary<string, string> tagDictionary, Dictionary<string, object> fieldDictionary)
        {
            Metrics.Write(measure, fieldDictionary, tagDictionary);
        }

        ////public void IncrementData(string measure, Dictionary<string, object> tagDictionary, Dictionary<string, object> fieldDictionary)
        ////{
        ////    Metrics.Increment("iterations");

        ////    object process = null;

        ////    Metrics.Write("jobs",
        ////        new Dictionary<string, object>
        ////        {
        ////            { "jobId", Guid.NewGuid },
        ////            { "user", process.UserProcessorTime.TotalMilliseconds }
        ////        });

        ////    Metrics.Measure("working_set", process.WorkingSet64);
        ////}
    }
}
