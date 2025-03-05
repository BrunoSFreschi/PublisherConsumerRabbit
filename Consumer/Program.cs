using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

try
{
    ConnectionFactory factory = new() { HostName = "localhost" };
    using IConnection connection = await factory.CreateConnectionAsync();
    using IChannel channel = await connection.CreateChannelAsync();
    AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

    // Define o evento que será acionado quando uma mensagem for recebida
    consumer.ReceivedAsync += async (model, ea) =>
    {
        byte[] body = ea.Body.ToArray();
        string message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Recebido: {message}");
    };

    // Inicia o consumo da fila
    await channel.BasicConsumeAsync(queue: "Hello",
                                     autoAck: true,
                                     consumer: consumer);

    Console.ReadLine(); // Mantém o programa rodando
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao RabbitMQ: {ex.Message}");
    Console.WriteLine($"Detalhes: {ex.InnerException?.Message}");
}