using System;

public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weatherForecast}\nHashtag: {GetHashtag()}\nPromo Code: {GetPromoCode()}"; // 🌟 Added promo code
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering - {_weatherForecast}";
    }
}