using EH.Assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EH.Assessment.Data
{
    public interface IContactRepository : IRepository<ContactModel>
    {
        ContactModel GetContactById(Guid id);
        ContactModel GetContactByFieldAndValue(string p_field, string p_fieldValue);
    }
}
