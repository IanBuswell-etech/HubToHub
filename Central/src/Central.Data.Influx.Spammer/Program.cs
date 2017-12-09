using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Data.Influx.Spammer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var influxTalker = new Talker();

            var count = 10;

            var measureName = "test";

            var jobId = Guid.NewGuid().ToString();

            for (var i = 0; i < count; i++)
            {
                SpamInflux(influxTalker, measureName, jobId, rand);
                Task.Delay(500).Wait();
            }

            Console.WriteLine("\n Done!");
            Console.ReadKey();
        }

        private static void SpamInflux(Talker instance, string measureName, string jobId, Random rand)
        {
            ////var jobId = Guid.NewGuid().ToString();
            var data = new { aField = "test", bField = "test2", rnd = rand.Next() };

            var fields = new Dictionary<string, object>
            {
                { "job", data },
            };

            var tags = new Dictionary<string, string>
            {
                { "jobId", jobId }
            };

            instance.AddMeasureEntry(measureName, tags, fields);

            var dataAgg = fields.Aggregate(new StringBuilder(), 
                (sb, kvp) => sb.Append($"Key = '{kvp.Key}' : value = '{kvp.Value}'"),
                sb => sb.ToString());

            Console.WriteLine($"Spam measureName: '{measureName}', \n jobId:{jobId} \n data: {dataAgg}");
        }
    }
}
