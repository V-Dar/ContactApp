using Api.Model;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ContactManagementController : BaseController
    {
        private readonly ContactStorage contactStorage;

        public ContactManagementController(ContactStorage contactStorage)
        {
            this.contactStorage = contactStorage;
        }

        [HttpPost("contacts")]
        public void CreateContact([FromBody]Contact contact)
        {
            contactStorage.Contacts.Add(contact);
        }

        [HttpGet("contacts")]
        public List<Contact> GetContacts()
        {
            return contactStorage.Contacts;
        }

        [HttpDelete("contacts/{id}")]
        public void DeleteContact(int id)
        {
            Contact? contact = contactStorage.Contacts.FirstOrDefault(t => t.Id == id);
            if(contact is not null)
                contactStorage.Contacts.Remove(contact);
        }

        [HttpPut("contacts/{id}")]
        public void UpdateContact([FromBody] ContactDto contactDto, int id)
        {
            Contact? contact = contactStorage.Contacts.FirstOrDefault(t => t.Id == id);
            if (contact is not null)
            {
                if (String.IsNullOrEmpty(contactDto.Email))
                    contact.Email = contactDto.Email;

                if (String.IsNullOrEmpty(contactDto.Name))
                    contact.Name = contactDto.Name;
            }
        }
    }
}
