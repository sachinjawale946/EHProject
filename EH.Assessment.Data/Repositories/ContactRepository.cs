using EH.Assessment.Models;
using System;
using System.Linq;

namespace EH.Assessment.Data
{
    public class ContactRepository : Repository<ContactModel>, IContactRepository
    {
        public ContactRepository(EHDBContext eHDBContext) : base(eHDBContext)
        {
        }

        public ContactModel GetContactById(Guid p_contactId)
        {
            return GetAll().Where(c => c.ContactId == p_contactId).FirstOrDefault();
        }

        public ContactModel GetContactByFieldAndValue(string p_field, string p_fieldValue)
        {
            return GetAll().Where(m => m.GetType().GetProperty(p_field).GetValue(m, null).ToString().ToLower().Equals(p_fieldValue.ToLower())).FirstOrDefault();
        }
    }
}
