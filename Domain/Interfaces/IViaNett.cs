using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IViaNett
    {
        string SendSMSSimple1(long phoneNumber, string message);
    }
}
