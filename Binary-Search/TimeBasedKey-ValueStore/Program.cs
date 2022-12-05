using System;
using System.Collections.Generic;

namespace TimeBasedKey_ValueStore
{
    class values
    {
        public string value { get; set; }
        public int timestamp { get; set; }
    }
    class Program
    {
        Dictionary<string, List<values>> dictionary = new Dictionary<string, List<values>>();
        public Program()
        {

        }

        public void set(string key, string value, int timestamp)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(new values
                {
                    value = value,
                    timestamp = timestamp
                });
            }
            else
            {
                dictionary.Add(key, new List<values> { new values
                {
                    value = value,
                    timestamp = timestamp
                }});
            }
        }

        public string get(string key, int timestamp)
        {
            List<values> valueList = null;
            if (dictionary.ContainsKey(key))
            {
                valueList = dictionary[key];
            }
            else
            {
                return "";
            }

            //binary serach
            int start = 0;
            int end = valueList.Count - 1;
            while (start < end)
            {
                int mid = start + (end - start + 1) / 2;
                if (valueList[mid].timestamp <= timestamp) start = mid;
                else end = mid - 1;
            }
            return valueList[start].timestamp <= timestamp
                ? valueList[start].value
                : "";
        }
        static void Main(string[] args)
        {
            Program timeMap = new Program();
            timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
            Console.WriteLine(timeMap.get("foo", 1));         // return "bar"
            Console.WriteLine(timeMap.get("foo", 3));         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
            Console.WriteLine(timeMap.get("foo", 4));         // return "bar2"
            Console.WriteLine(timeMap.get("foo", 5));
            Console.WriteLine("Hello World!");
        }
    }
}
