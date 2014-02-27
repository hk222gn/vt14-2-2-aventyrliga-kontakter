using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AventyrligaKontakter.Model.DAL
{
    public class ContactDAL : DALBase
    {
        public void DeleteContact(int contactID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactID;
                    //cmd.Parameters.AddWithValue("@ContactID", contactID);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to update a contact");
                }
            }
        }

        public Contact GetContactByID(int contactID)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspGetContact", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ContactID", contactID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var contactId = reader.GetOrdinal("ContactID");
                            var FirstName = reader.GetOrdinal("FirstName");
                            var LastName = reader.GetOrdinal("LastName");
                            var EmailAddress = reader.GetOrdinal("EmailAddress");

                            return new Contact
                            {
                                ContactID = reader.GetInt32(contactId),
                                FirstName = reader.GetString(FirstName),
                                LastName = reader.GetString(LastName),
                                EmailAddress = reader.GetString(EmailAddress)
                            };
                        }
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to get a contact");
                }
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                
                    var contact = new List<Contact>();
                    var cmd = new SqlCommand("Person.uspGetContacts", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactID = reader.GetOrdinal("ContactID");
                        var FirstName = reader.GetOrdinal("FirstName");
                        var LastName = reader.GetOrdinal("LastName");
                        var EmailAddress = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contact.Add(new Contact
                            {
                                ContactID = reader.GetInt32(contactID),
                                FirstName = reader.GetString(FirstName),
                                LastName = reader.GetString(LastName),
                                EmailAddress = reader.GetString(EmailAddress)
                            });
                        }
                    }
                    contact.TrimExcess();

                    return contact;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to get the contacts");
                }
            }
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(maximumRows);

                    SqlCommand cmd = new SqlCommand("Person.uspGetContactsPageWise", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactID = reader.GetOrdinal("ContactID");
                        var FirstName = reader.GetOrdinal("FirstName");
                        var LastName = reader.GetOrdinal("LastName");
                        var EmailAddress = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                ContactID = reader.GetInt32(contactID),
                                FirstName = reader.GetString(FirstName),
                                LastName = reader.GetString(LastName),
                                EmailAddress = reader.GetString(EmailAddress)
                            });
                        }
                    }
                    contacts.TrimExcess();

                    return contacts;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to get contacts page wise");
                }
            }
        }

        public void InsertContact(Contact contact)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactID;

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to add a contact");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactID;

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Something went wrong when attempting to update a contact");
                }
            }
        }
    }
}