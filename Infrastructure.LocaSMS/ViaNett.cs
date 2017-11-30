using Domain.Interfaces;
using Infrastructure.LocaSMS.ViaNettService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.LocaSMS
{
    public class ViaNett: IViaNett
    {
        public string SendSMSSimple1(long phoneNumber, string message)
        {
            CPAWebServiceSoapClient service = null;
            string retService = "";

            try
            {
                service = new CPAWebServiceSoapClient("CPAWebServiceSoap12");

                retService = service.SendSMS_Simple1("felipeptrevizan@yahoo.com.br", "bn8ft", phoneNumber, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retService;
        }
    }
}
