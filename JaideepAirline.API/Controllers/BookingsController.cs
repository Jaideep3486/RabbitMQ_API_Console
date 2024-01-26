using JaideepAirline.API.Models;
using JaideepAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaideepAirline.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
  

    private readonly ILogger<BookingController> _logger;
    private readonly IMessageProducer _IMessageProdObj;

    //This is the in-memory Database
    public static readonly List<Booking> _booking=new(); 

    public BookingController(ILogger<BookingController> logger,IMessageProducer jmessageProducer)
    {
        _logger = logger;
        _IMessageProdObj= jmessageProducer;
    }

    [HttpPost(Name = "PostBooking")] // this action is of post type
    public IActionResult PostBooking(Booking book) //Created a new action -this action takes a booking 
    {
       if(!ModelState.IsValid) return BadRequest(); // we check if all the required fields are there

       _booking.Add(book); // we add this to our local db

       _IMessageProdObj.SendingMessages<Booking>(book); //Connecting with message producer and pushing the booking in it

       return Ok();

    }
}
