using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WhistleFramework.src.Helpers
{
    public class APIHelper
    {
        public List<TestObject> DeserializeJson(string stringToDeserialize)
        {
            return JsonConvert.DeserializeObject<List<TestObject>>(stringToDeserialize);
        }

        public (bool, string) ValidateItemsAreSortedByDateAsc(string responseToDeserialize)
        {
            var objectDeserialized = DeserializeJson(responseToDeserialize);
            DateTime startDate = DateTime.ParseExact("2020-01-01 01:00 AM", "yyyy-MM-dd HH:mm tt", null);
            
            if (objectDeserialized.Count.Equals(0))
            {
                return (false, "No Id's were returned");
            }
            
            for (int i = 0; i < objectDeserialized.Count; i++)
            {
                if (startDate < objectDeserialized[i].timestamp)
                {
                    startDate = objectDeserialized[i].timestamp;
                }
                else
                {
                    return (false, objectDeserialized[i].device_id);
                }
            }

            return (true, "");
            
        }

        public class TestObject
        {
            public string device_id { get; set; }
            
            public DateTime timestamp { get; set; }
        }
    }
   
}
