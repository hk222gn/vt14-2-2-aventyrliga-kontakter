using AventyrligaKontakter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AventyrligaKontakter
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
            //try
            //{
            //    return Service.GetContacts();
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett fel inträffade när inläsningen av kontakter skulle utföras.");
            //    return null;
            //}
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när inläsningen av kontakter skulle utföras.");
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int contactID)
        {
            try
            {
                var contact = Service.GetContact(contactID);
                if (contact == null)
                {
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", contactID));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när inläsningen av kontakter skulle utföras.");
            }
        }
        public void ContactListView_DeleteItem(int contactID)
        {
            try
            {
                Service.DeleteContact(contactID);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när inläsningen av kontakter skulle utföras.");
            }
        }
    }
}