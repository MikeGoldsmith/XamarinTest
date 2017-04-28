using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Configuration.Client;
using Newtonsoft.Json;

namespace clientest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var config = new ClientConfiguration
			{
				Servers = new List<Uri> { new Uri("http://10.112.161.101") }
			};
			var cluster = new Cluster(config);
			var bucket = cluster.OpenBucket("default");

			bucket.Upsert("test", new Person("mike"));
			var getResult = bucket.Get<Person>("test");

			Console.WriteLine(JsonConvert.SerializeObject(getResult.Value));
		}
	}

	class Person
	{
		public string Name { get; set; }

		public Person(string name)
		{
			Name = name;
		}
	}
}
