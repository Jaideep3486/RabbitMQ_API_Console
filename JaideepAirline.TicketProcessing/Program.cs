// See https://aka.ms/new-console-template for more information
using System.Text;
using Microsoft.VisualBasic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
Console.WriteLine("Welcome to Jaideep Ticketing Service !");

var JaiFactory = new ConnectionFactory(){

HostName="localhost",
UserName="user",
Password="mypass",
VirtualHost="/"

};

var jaiconn = JaiFactory.CreateConnection();

using var jaichannel = jaiconn.CreateModel();

jaichannel.QueueDeclare("booking", durable: true, exclusive: false, autoDelete: false, arguments: null);


var consumer=new EventingBasicConsumer(jaichannel);

consumer.Received +=(jmodel,jeventArgs)=>{

//getting Byte Array
var jbody=jeventArgs.Body.ToArray();
//convert Byte Array to text
var jmessage=Encoding.UTF8.GetString(jbody);

Console.WriteLine($"A Message has be recieved - {jmessage}");

};
//here we are consuming the message
jaichannel.BasicConsume("booking",true,consumer);

//Preventing application from running forever
Console.ReadKey();