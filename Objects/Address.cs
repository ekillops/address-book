using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Address
  {
    private string _streetAddress;
    private string _city;
    private string _state;
    private int _zipCode;
    private string _type;

    public Address(string newStreetAddress = "Street Address", string newCity = "City", string newState = "State", int newZip = 00000, string newType = "Home")
    {
      _streetAddress = newStreetAddress;
      _city = newCity;
      _state = newState;
      _zipCode = newZip;
      _type = newType;
    }


    public void SetStreetAddress(string newStreetAddress)
    {
      _streetAddress = newStreetAddress;
    }
    public string GetStreetAddress()
    {
      return _streetAddress;
    }

    public void SetCity(string newCity)
    {
      _city = newCity;
    }
    public string GetCity()
    {
      return _city;
    }

    public void SetState(string newState)
    {
      _state = newState;
    }
    public string GetState()
    {
      return _state;
    }

    public void SetZipCode(int newZip)
    {
      _zipCode = newZip;
    }
    public int GetZipCode()
    {
      return _zipCode;
    }

    public void SetAddressType(string newType)
    {
      _type = newType;
    }
    public string GetAddressType()
    {
      return _type;
    }
  }
}
