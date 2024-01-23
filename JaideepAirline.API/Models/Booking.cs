namespace  JaideepAirline.API.Models;

public class Booking
{

public int Id { get; set; }

public string PassengerName { get; set; }="";

public string PassportNmb { get; set; }="";

public string From { get; set; }="";

public string To { get; set; }="";


public int Status { get; set; }


}