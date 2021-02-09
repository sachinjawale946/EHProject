using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EH.Assessment.Models
{
    public class ContactTypeModel
    {
        public int ContactTypeId { get; set; }
        public string ContactType { get; set; }
    }
}
