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
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contacts/new"] = _ => {
        return View["new_contact_form.cshtml"];
      };
      Post["/contacts/added"] = _ => {
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
      Get["/contacts/{id}"] = parameters => {
        Contact selectedContact = Contact.FindById(parameters.id);
        return View["contact.cshtml", selectedContact];
      };
      Get["/contacts/all"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts_all.cshtml", allContacts];
      };
      Post["/"] = _ => {
        Contact.ClearAll();
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Post["/contacts/deleted"] = _ => {
        int targetId = int.Parse(Request.Form["delete"]);
        Contact selectedContact = Contact.FindById(targetId);
        selectedContact.DeleteContact();
        Contact.ResetIds();
        return View["contact_removed.cshtml"];
      };
      Get["contacts/search"] = _ => {
        return View["contacts_search.cshtml"];
      };
      Post["contacts/search"] = _ => {
        string searchInput = Request.Form["search-input"];
        string searchInputLower = searchInput.ToLower();
        List<Contact> searchResults = Contact.SearchFor(searchInputLower);
        return View["search_results.cshtml", searchResults];
      };
    }
  }
}
