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
        public IActionResult CreateContact([FromBody]Contact contact)
        {
            bool result = contactStorage.Add(contact);
            if (result)
                return Ok(contact);
            return Conflict("Контакт с указанным id уже существует.");
        }

        [HttpGet("contacts")]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(contactStorage.GetContacts());
        }

        [HttpDelete("contacts/{id}")]
        public ActionResult DeleteContact(int id)
        {
            bool result = contactStorage.Remove(id);
            if (result)
                return NoContent();
            return BadRequest("Контакт с указанным id не найден.");
        }

        [HttpPut("contacts/{id}")]
        public ActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
        {  
            bool result = contactStorage.UpdateContact(contactDto, id);
            if (result)
                return Ok();
            return Conflict("Контакт с указанным id не существует.");
        }
    }
}
