using FirstApiProject.Data;
using FirstApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FirstApiProject.Controllers
{
    [ApiController]

    [Route("api/v1/[controller]")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext dbContext) {
            this._context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest) {
            var contacts = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone,
            };

            await _context.Contacts.AddAsync(contacts);    
            await _context.SaveChangesAsync();
            return Ok(contacts); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            Contact contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.Email = updateContactRequest.Email; 
            contact.FullName = updateContactRequest.FullName;
            contact.Phone = updateContactRequest.Phone;
            contact.Address = updateContactRequest.Address;

            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            Contact contact = await _context.Contacts.FindAsync(id);
            if (contact == null) { 
                return NotFound();
            }

            _context.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
