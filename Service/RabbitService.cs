using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        var port = _configuration.GetValue<int>("Rabbit:Port"); 
        var userName = _configuration["Rabbit:UserName"];
        var password= _configuration["Rabbit:Password"];   
        var queueName = _configuration["Rabbit:QueueName"];

        _queueName = queueName;
            
        _factory = new ConnectionFactory()
        {
            HostName = hostName,
            Port = port, 
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
        
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null, 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
        };
        
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