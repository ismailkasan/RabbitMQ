﻿using System.Text;
using RabbitMQ.Client;

// create factory
var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();


channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

const string message = "My first RabbitMQ message";

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);


Console.WriteLine($" [x] Sent {message}");
