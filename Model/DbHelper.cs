using Contact_Manager.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Model
{
    public class DbHelper
    {
        private ContactDbContext _context;
        public DbHelper(ContactDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<ContactModel> GetContacts()
        {
            List<ContactModel> response = new List<ContactModel>();
            var contactList = _context.Contacts.ToList();
            contactList.ForEach(row => response.Add(new ContactModel()
            {
                Id = row.Id,
                Salutation = row.Salutation,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Birthdate = row.Birthdate,
                CreationDateTimestamp = row.CreationDateTimestamp,
                Email = row.Email,
                PhoneNumber = row.PhoneNumber
            }));
            return response;
        }

        public ContactModel GetContactById(int id)
        {
            ContactModel response = new ContactModel();
            var row = _context.Contacts.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (row == null)
            {
                return null; 
            }
            return new ContactModel()
            {
                Id = row.Id,
                Salutation = row.Salutation,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Birthdate = row.Birthdate,
                CreationDateTimestamp = row.CreationDateTimestamp,
                Email = row.Email,
                PhoneNumber = row.PhoneNumber
                
            };
        }
        /// <summary>
        /// It serves the Create/Update
        /// </summary>
        public void SaveContact(ContactModel contactModel)
        {
            Contact dbTable;

            if (contactModel.Id > 0)
            {
                dbTable = _context.Contacts.FirstOrDefault(d => d.Id == contactModel.Id);
                if (dbTable != null)
                {
                    // Update properties only if they are not null in contactModel
                    if (contactModel.Salutation != null)
                        dbTable.Salutation = contactModel.Salutation;
                    if (contactModel.FirstName != null)
                        dbTable.FirstName = contactModel.FirstName;
                    if (contactModel.LastName != null)
                        dbTable.LastName = contactModel.LastName;
                    if (contactModel.Birthdate != null)
                        dbTable.Birthdate = contactModel.Birthdate;
                   
                    if (contactModel.Email != null)
                        dbTable.Email = contactModel.Email;
                    if (contactModel.PhoneNumber != null)
                        dbTable.PhoneNumber = contactModel.PhoneNumber;

                    _context.SaveChanges();
                }
                else
                {
                    
                    throw new InvalidOperationException("Contact with the provided Id does not exist.");
                }
            }
            else
            {
                // Create a new Contact instance
                dbTable = new Contact
                {
                    Salutation = contactModel.Salutation,
                    FirstName = contactModel.FirstName,
                    LastName = contactModel.LastName,
                    DisplayName = contactModel.DisplayName,
                    Birthdate = contactModel.Birthdate,
                    CreationDateTimestamp = contactModel.CreationDateTimestamp,
                    Email = contactModel.Email,
                    PhoneNumber = contactModel.PhoneNumber
                };

                // Add to the context and save changes
                _context.Contacts.Add(dbTable);
                _context.SaveChanges();
                
            }
        }
       




        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteContact(int id)
        {
            var contact = _context.Contacts.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
    
