using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Entities.Global
{
    public class ErrorModel
    {
        public string? ErrorCode { get; set; }

        public string? ErrorDescription { get; set; }

        public int NoOfRowsEffected { get; set; }
    }
}
