using Publisher;


string channel = "Hello";

string message = "Hello RabbitMQ!";


await Handler.Delivery(channel, message);


Console.WriteLine(" Press [enter] to exit.");

