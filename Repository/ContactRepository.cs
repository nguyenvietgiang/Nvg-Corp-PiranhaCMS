using Piranha;
using Nvg_Corp.Models;
using Nvg_Corp.Data;
using Microsoft.EntityFrameworkCore;

namespace Nvg_Corp.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetByIdAsync(Guid id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task SaveAsync(Contact contact);
        Task DeleteAsync(Guid id);
    }

    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext db)
        {
            _context = db;
        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task SaveAsync(Contact contact)
        {
            if (contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
                await _context.Contacts.AddAsync(contact);
            }
            else
            {
                _context.Contacts.Update(contact);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
