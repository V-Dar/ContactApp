using Api.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Storage
{
    public class ContactStorage
    {
        private List<Contact> Contacts { get; set; }
        public ContactStorage()
        {
            Contacts = new();
            for (int i = 1; i <= 5; i++)
            {
                Contacts.Add(new Contact
                {
                    Id = i,
                    Name = $"Полное имя {i}",
                    Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{i}@ksergey.ru"
                });
            }
        }
        public List<Contact> GetContacts()
        {
            return Contacts;
        }
        public bool Add(Contact contact)
        {
            if (Contacts.Any(t => t.Id == contact.Id))
                return false;
            Contacts.Add(contact);
            return true;
        }
        public bool Remove(int id) 
        {
            Contact? contact = Contacts.FirstOrDefault(t => t.Id == id);
            if (contact is not null)
            {
                Contacts.Remove(contact);
                return true;
            }
            return false;

        }
        public bool UpdateContact(ContactDto contactDto, int id)
        {
            Contact? contact = Contacts.FirstOrDefault(t => t.Id == id);
            if (contact is not null)
            {
                if (String.IsNullOrEmpty(contactDto.Email))
                    contact.Email = contactDto.Email;

                if (String.IsNullOrEmpty(contactDto.Name))
                    contact.Name = contactDto.Name;
                return true;
            }
            return false;
        }
    }
}
