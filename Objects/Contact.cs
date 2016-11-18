using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private Address _address;

    private int _id;

    private static List<Contact> _instances = new List<Contact> {};

    public Contact(string newFirstName, string newLastName, string newPhoneNumber, Address newAddress = new Address("street address","city","state","zip code"))
    {
      _firstName = newFirstName;
      _lastName = newLastName;
      _phoneNumber = newPhoneNumber;
      _address = newAddress;

      _instances.Add(this);
      _id = _instances.Count;
    }

    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public string GetFirstName()
    {
      return _firstName;
    }
    public void SetLastName(string newLastName)
    {
      _lastName = newLastName;
    }
    public string GetLastName()
    {
      return _lastName;
    }

    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public int GetId()
    {
      return _id;
    }

    public Address GetAddress()
    {
      return _address;
    }

    public static List<Contact> GetAll()
    {
      return _instances;
    }

    public static int FindById(int searchId)
    {
      return _instances[searchId -1];
    }
  }
}
