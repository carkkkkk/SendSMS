using Domain.Interfaces;
using Infrastructure.LocaSMS.LocaSMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.LocaSMS
{
    public class LocaSMS : ILocaSMS
    {
        public string SendSMS(string phoneNumber, string message)
        {
            ServiceSMSSoapClient service = null;
            string retService = "";

            try
            {
                service = new ServiceSMSSoapClient();

                retService = service.SendSMS("11987524404", "264783", new rSMS
                {
                    Destinations = new Destination[]
                    {
                        new Destination
                        {
                            Number = phoneNumber,
                        }
                    },
                    Msg = message,
                    Subject = "ENVIOSMS_LOCASMS",
                    WarningBeginningTransmission = false,
                    Preso = false
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retService;
        }
    }
}
