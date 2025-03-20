using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Publisher;

class Handler
{
    internal static async Task Consumer(string queueName)
    {

        ConnectionFactory factory = new() { HostName = "localhost" };

        try
        {
            using IConnection connection = await factory.CreateConnectionAsync();
            using IChannel channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);

                Console.WriteLine($" [x] Received - {message}");

                await Task.Delay(500);
            };

            await channel.BasicConsumeAsync(queue: queueName,
                autoAck: true,
                consumer: consumer);

            Console.WriteLine("Aguardando mensagem...");

            await Task.Delay(-1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao se conectar ao RabbitMQ: {ex.Message}");
            Console.WriteLine($"Detalhes: {ex.InnerException?.Message}");
        }
    }

    internal static async Task Delivery(string channelName, string message)
    {
        ConnectionFactory factory = new() { HostName = "localhost" };

        try
        {
            using IConnection connection = await factory.CreateConnectionAsync();

            using IChannel channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: channelName,
                                           durable: false,
                                           exclusive: false,
                                           autoDelete: false,
                                           arguments: null);


            byte[] body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: "",
                                            routingKey: channelName,
                                            body: body);

            Console.WriteLine($" [x] Sent {message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao RabbitMQ: {ex.Message}");
            Console.WriteLine($"Detalhes: {ex.InnerException?.Message}");
        }
    }
}