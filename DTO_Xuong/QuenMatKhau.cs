using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
    public class PasswordResetRequestDTO
    {
        public string UserEmail { get; set; }
        public DateTime RequestTime { get; set; }
    }

}
