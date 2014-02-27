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

        private string Status
        {
            get { return Session["Status"] as string; }
            set { Session["Status"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Status"] != null)
            {
                Panel1.Visible = true;
                ResultLabel.Text = Status;
                Session.Remove("Status");
            }
        }

        public IEnumerable<Contact> ContactListView_GetData()
        {
            try
            {
                return Service.GetContacts();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när inläsningen av kontakter skulle utföras.");
                return null;
            }
        }

        public IEnumerable<Contact> ContactListView_GetDataPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
            
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
                Session["Status"] = "Kontakten har lagts till.";
                Response.Redirect("/Default.aspx");
            }
        }

        public void ContactListView_UpdateItem(int contactID)
        {
            try
            {
                var contact = Service.GetContact(contactID);
                if (contact == null)
                {
                    ModelState.AddModelError("", String.Format("Kontakten med id {0} hittades ej.", contactID));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);
                }
                Session["Status"] = "Kontakten har updaterats.";
                Response.Redirect("/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när updateringen av kontakter skulle utföras.");
            }
        }

        public void ContactListView_DeleteItem(int contactID)
        {
            try
            {
                Service.DeleteContact(contactID);
                Session["Status"] = "Kontakten har raderats.";
                Response.Redirect("/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när borttagning av en kontakt skulle utföras.");
            }
        }
    }
}