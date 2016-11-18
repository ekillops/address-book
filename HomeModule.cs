using Nancy;
using System;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/contacts/new"] = _ => {
        return View["new_contact_form.cshtml"];
      };
      Post["/contact/added"] = _ => {
        string inputFirstName = Request.Form["name-first"];
        string inputLastName = Request.Form["name-last"];
        string inputPhoneNumber = Request.Form["phone-number"];

        string inputAddressStreet = Request.Form["address-street"];
        string inputAddressCity = Request.Form["address-city"];
        string inputAddressState = Request.Form["address-state"];
        string inputAddressZip = Request.Form["address-zip"];

        Address newContactAddress = new Address(inputAddressStreet, inputAddressCity, inputAddressState, inputAddressZip);
        Contact newContact = new Contact(inputFirstName, inputLastName, inputPhoneNumber, newContactAddress);

        return View["contact_added.cshtml", newContact];
      };
    }
  }
}
