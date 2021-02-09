using EH.Assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EH.Assessment.Data
{
    public class ErrorLogRepository : Repository<ErrorLogModel>, IErrorLogRepository
    {
        public ErrorLogRepository(EHDBContext eHDBContext) : base(eHDBContext)
        {
        }
    }
}
