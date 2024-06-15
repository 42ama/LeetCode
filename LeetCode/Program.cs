
using System;

var rabbitMqConnectionString = "amqp://extdev-rabbitmq.sberfactoring.ru:5672//";
var url = rabbitMqConnectionString;
var withoutProtocol = url.Remove(0, 7);

var indexPort = withoutProtocol.LastIndexOf(':') + 1;
var indexVHost = withoutProtocol.IndexOf('/') + 1;

var hostName = indexPort > 0
    ? withoutProtocol.Substring(0, indexPort - 1)
    : withoutProtocol.Substring(0, indexVHost - 1);

// Получение порта.
var port = indexPort > 0
    ? int.Parse(withoutProtocol.Substring(indexPort, indexVHost - 1 - indexPort))
    : 5672;

// Получение виртуального хоста.
var virtualHost = withoutProtocol.Substring(indexVHost, withoutProtocol.Length - indexVHost);


;