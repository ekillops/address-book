using System;
using System.Collections.Generic;
using AddressBook.Objects;

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


    public Contact(string newFirstName, string newLastName, string newPhoneNumber, Address newAddress)
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

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }

    public static Contact FindById(int searchId)
    {
      return _instances[searchId -1];
    }

    public void DeleteContact()
    {
      _instances.Remove(this);
    }
    // Method to reset contact ids to match list index after contacts have been deleted
    public static void ResetIds()
    {
      foreach (Contact contact in _instances) {
        contact._id = _instances.IndexOf(contact) + 1;
      }
    }

    public static List<Contact> SearchFor(string searchString)
    {
      string searchStringLower = searchString.ToLower();
      List<Contact> outputList = new List<Contact> {};
      foreach (Contact contact in _instances) {
        string fullName = contact.GetFirstName() + " " + contact.GetLastName();
        string fullNameLower = fullName.ToLower();
        if (fullNameLower.Contains(searchStringLower))
        {
          outputList.Add(contact);
        }
      }
      return outputList;
    }
  }
}
