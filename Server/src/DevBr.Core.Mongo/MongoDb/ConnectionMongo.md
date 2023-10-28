** Modelos de conexão com replicas
primeiro modelo
```csharp
	var connString = "mongodb://localhost:27029,localhost:27027,localhost:27028?connect=replicaSet";
	var client = new MongoClient(connString);
	var db = client.GetDatabase("test");
```

segundo modelo
```csharp
	var settings = new MongoClientSettings
	{
	   Servers = new[]
	   {
		  new MongoServerAddress("localhost", 27027),
		  new MongoServerAddress("localhost", 27028),
		  new MongoServerAddress("localhost", 27029)
	   },
	   ConnectionMode = ConnectionMode.Automatic,
	   ReplicaSetName = "m101",
	   WriteConcern = new WriteConcern(WriteConcern.WValue.Parse("3"),wTimeout:TimeSpan.Parse("10"))
	};
	var client = new MongoClient(settings);
```

connection = "mongodb://servername/?safe=true&connect=replicaset";
m_server = MongoServer.Create(connectionString);

