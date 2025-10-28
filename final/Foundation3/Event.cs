using System;

public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;
    private string _hashtag;
    private string _promoCode;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;

        _hashtag = "#" + title.Replace(" ", "");
        _promoCode = "PROMO-" + title.Replace(" ", "").ToUpper().Substring(0, Math.Min(8, title.Length));
    }

    public string GetStandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nHashtag: {_hashtag}\nPromo Code: {_promoCode}";

    public virtual string GetShortDescription()
    {
        return $"Event - {_title} - {_date}";
    }

    public string GetHashtag() => _hashtag;
    public string GetPromoCode() => _promoCode;
}