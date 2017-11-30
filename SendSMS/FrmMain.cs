using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendSMS
{
    public partial class FrmMain : Form
    {
        private readonly SendSMSBusinessLogic _sendSMSBusinessLogic;

        public FrmMain(SendSMSBusinessLogic sendSMSBusinessLogic)
        {
            InitializeComponent();

            _sendSMSBusinessLogic = sendSMSBusinessLogic;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendService service;

            try
            {
                if (rbLocaSMS.Checked)
                    service = SendService.LocaSMS;
                else
                    service = SendService.ViaNett;

                _sendSMSBusinessLogic.SendMessage(txtPhoneNumber.Text, txtMessage.Text, service);

                MessageBox.Show("Mensagem enviada com sucesso.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
