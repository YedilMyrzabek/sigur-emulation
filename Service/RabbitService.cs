using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class RabbitService : IRabbitService
{
    private readonly IConfiguration _configuration;
    private readonly ConnectionFactory _factory;
    private readonly string _queueName;
    
    public RabbitService(IConfiguration configuration)
    {
        _configuration = configuration;
        
        var hostName = _configuration["Rabbit:HostName"];
        var userName = _configuration["Rabbit:UserName"];
        var password= _configuration["Rabbit:Password"];   
        var queueName = _configuration["Rabbit:QueueName"];

        _queueName = queueName;

        _factory = new ConnectionFactory()
        {
            HostName = hostName,
            UserName = userName,
            Password = password
        };
    }
    
    public async Task SendMessage<T>(T message)
    {
        await using var connection = await _factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,  
            arguments: null
        );
        
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);
        
        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: _queueName,
            mandatory: true,
            body: body,
            cancellationToken: default
        );
    }
}