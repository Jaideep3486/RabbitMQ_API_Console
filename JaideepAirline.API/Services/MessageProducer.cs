using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using RabbitMQ.Client;

namespace JaideepAirline.API.Services;

public class MessageProducer : IMessageProducer
{

public void SendingMessages<Jai>(Jai message)
{

var JaiFactory = new ConnectionFactory(){

HostName="localhost",
UserName="user",
Password="mypass",
VirtualHost="/"

};

var jaiconn = JaiFactory.CreateConnection();

using var jaichannel = jaiconn.CreateModel();

jaichannel.QueueDeclare("booking",durable:true,exclusive:true);

var jsonString=JsonSerializer.Serialize(message);
var body = Encoding.UTF8.GetBytes(jsonString);

jaichannel.BasicPublish("","bookings",body:body);

}


}
