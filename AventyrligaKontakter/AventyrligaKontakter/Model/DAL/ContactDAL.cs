using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AventyrligaKontakter.Model.DAL
{
    public class ContactDAL : DALBase
    {
        public void DeleteContact(int contactID)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByID(int contactID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            throw new NotImplementedException();
        }

        public void InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}