# RabbitCommunicationLib 

A library to assist in developing asycnronous micro-services using RabbitMQ within MentorEngine.


## Transfer Models
When creating a service you need to define at least one TransferModel that implements `ITransferModel`, 
this is used for serialization and de-serialization of data.

TransferModel types are referred to as `TConsumeModel` and `TProduceModel` for message consumption and production, respectively.

---

## Usage

### Establish a connection with a RabbitMQ Server.

A connection that implements `IQueueConnection` is required for all services - For standard use, instantiating the
`QueueConnection` in `/helpers` is sufficient.

```csharp
var connection = new QueueConnection("amqp://*******", "DD2DD");

```

It is reccomended to pull these variables from the Enviroment. 

```csharp
using RabbitCommunicationLib.Helpers;

public static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.ConfigureServices((hostContext, services) =>
		{
		...

		var connection = new QueueConnection(
			hostContext.Configuration.GetValue<string>("AMQP_URI"),
			hostContext.Configuration.GetValue<string>("AMQP_URL_QUEUE"));

		...
```

---

### Create a Service ( Consumer || Producer )

#### Consumer

A Consumer requires you to create a class that inherits from `Consumer<TConsumeModel>` class 
and overrides the `HandleMessage` method.

You must supply a `TConsumeModel`.

The consumer has an optional prefetch count, which defaults to 1.
This means that only one message is processed at a time. A second one is only consumed if the first one has been acknowledged.
**Be careful of resending a corrupt message, if it ends up in a loop of being constantly resend, no other message can be processed.** 

```csharp
using RabbitCommunicationLib.Consumer;

class ExampleConsumer : Consumer<DC_DD_Model>
{
	public ExampleConsumer(IQueueConnection queueConnection) : base(queueConnection) { }

	protected override void HandleMessage(IBasicProperties properties, DC_DD_Model model)
	{
		Console.WriteLine($"Heres a DownloadUrl: {model.DownloadUrl}");
	}
}

```

#### Producer

A Producer can be instantiated without the need of a parent class.

You must supply a `TProduceModel`.

To produce a message:
- Define a `correlationId<string>` (Usually MatchId or, if MatchId is not available, a randomly generated GUID)
- Define a  `produceModel<TProduceModel>`

```csharp
using RabbitCommunicationLib.Producer;

...

	// Create the producer using an existing connection
	DemoUrlProducer = new Producer<DD_DC_Model>(queueConnection);

	// Publish a message
	DemoUrlProducer.PublishMessage(matchId, new DD_DC_Model { DemoUrl = "http://mentor.gg/bestdemo.dem" });

```

---

### Create a RPC Service ( RPCServer || RPCClient )

#### RPCServer

An RPCServer has the similar requirements as the standard Consumer but you must also specifiy a `TProduceModel` for replies.

Instead of overidding the `HandleMessage` method, an RPCServer expects you to return a reply of type `TProduceModel` using `HandleMessageAndReply`

```csharp
using RabbitCommunicationLib.Consumer;

class ExampleRPCServer : RPCServer<DC_DD_Model, DD_DC_Model>
{
    public ExampleRPCServer(IQueueConnection queueConnection) : base(queueConnection) { }


	protected override DD_DC_Model HandleMessageAndReply(IBasicProperties properties, DC_DD_Model model)
	{
		Console.WriteLine($"Heres a DownloadUrl: {model.DownloadUrl}");

		...
		
		return new DD_DC_Model { DemoUrl = "http://mentor.gg/bestdemo.dem" }
	}
}

```

#### RPCClient

An RPCClient has the similar requirements as the standard Producer but you must also specify a `TConsumeModel` for reply handling.

```csharp
using RabbitCommunicationLib.Producer;

class ExampleRPCClient : RPCClient<DC_DD_Model, DD_DC_Model>
{
    public ExampleRPCClient(IQueueConnection queueConnection) : base(queueConnection) { }


	protected override void HandleReply(IBasicProperties properties, DD_DC_Model model)
	{
		Console.WriteLine($"Heres a DemoUrl: {model.DemoUrl}");
	}
}

```

Invocation is the same as a standard producer.

```csharp

	// Create the producer using an existing connection
	DemoUrlProducer = ExampleProducer(queueConnection)

	// Publish a message
	DemoUrlProducer.PublishMessage(matchId, new DD_DC_Model { DemoUrl = "http://mentor.gg/bestdemo.dem" });


```


---

### Add Services to your application

After creating the application-specific implementation of a Rabbit service,
It can be added as a `IHostedServer` with the `AddHostedService()` method.

**Dependency Injection**: Use the `IServiceProvider` inside your Implementation Factory to inject existing services 
such as `ILogger` in your implementation.

```csharp

public static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.ConfigureServices((hostContext, services) =>
		{

		...

		services.AddHostedService(sp =>
			{
				// Use the pre-existing connection defined from earlier
				return new FooService(connection);
			}
		);

		...
```


## Diagrams

### Basic Rabbit Exchange
 ```mermaid
	graph LR
    A((Publisher)) --> B{Exchange}
    B -->  C[Queue]
    C -->|subscribe| D((Consumer)) 

style C fill: #EA6248
style D fill:#6BB7F1
class A publisher;

classDef publisher fill:#84EBFD;

 ```

### RPC Pattern

```mermaid
graph LR
Client[Client]
Send[Send-Queue]
Server[Server]
Reply[Reply-Queue]

Client--> |Publish| Send
Send --> |Consume| Server
Server --> |Publish| Reply
Reply --> |Consume| Client

class Send,Reply queue;

classDef queue fill:#EA6248;

```



	