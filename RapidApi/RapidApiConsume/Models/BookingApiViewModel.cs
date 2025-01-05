using System.Text.Json.Serialization;

public class BookingApiViewModel
{
    public bool Status { get; set; }

    public string? Message { get; set; }

    public long timestamp { get; set; }

  

    public List<Result>? results { get; set; }// proje değiştirip başlatıyorsun ya sürekli. onun yerine aynı anda da birden fazla proje ayağa kaldırabilirsin
}



public class Result
{
    public string? hotel_name { get; set; }
    public string? city { get; set; }
    public double? rating { get; set; }
}
