﻿using Publisher;


string channel = "Hello";

string message = "Hello RabbitMQ!";


await Handler.Delivery(channel, message);

await Handler.Consumer(channel);


Console.WriteLine(" Press [enter] to exit.");

