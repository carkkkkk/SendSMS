using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SendSMSBusinessLogic
    {
        private readonly ILocaSMS _locaSMS;
        private readonly IViaNett _viaNett;

        public SendSMSBusinessLogic(ILocaSMS locaSMS, IViaNett viaNett)
        {
            _locaSMS = locaSMS;
            _viaNett = viaNett;
        }

        public void SendMessage(string phoneNumber, string message, SendService service)
        {
            string phoneNumberWithoutFormat = "", ret = "";

            try
            {
                switch(service)
                {
                    case SendService.LocaSMS:
                        phoneNumberWithoutFormat = phoneNumber
                            .Replace("+", "")
                            .Replace("(", "")
                            .Replace(")", "")
                            .Replace(" ", "")
                            .Replace("-", "");

                        // Remove código internacional
                        phoneNumberWithoutFormat = phoneNumberWithoutFormat.Remove(0, 2);

                        ret = _locaSMS.SendSMS(phoneNumberWithoutFormat, message);

                        if (ret.Split(':').Length < 2)
                        {
                            throw new Exception("Erro no retorno do serviço de SMS");
                        }
                        else if (int.Parse(ret.Split(':')[0]) == 0)
                        {
                            throw new Exception(ret.Split(':')[1]);
                        }
                        break;
                    case SendService.ViaNett:
                        phoneNumberWithoutFormat = phoneNumber
                            .Replace("+", "")
                            .Replace("(", "")
                            .Replace(")", "")
                            .Replace(" ", "")
                            .Replace("-", "");

                        ret = _viaNett.SendSMSSimple1(long.Parse(phoneNumberWithoutFormat), message);

                        if (ret.Split(':').Length < 2)
                        {
                            throw new Exception("Erro no retorno do serviço de SMS");
                        }
                        else if (int.Parse(ret.Split(':')[0]) == 0)
                        {
                            throw new Exception(ret.Split(':')[1]);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
