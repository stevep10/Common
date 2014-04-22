using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleRWSProject
{
    public partial class sample : Form
    {
        public sample()
        {
            InitializeComponent();
        }

        private void btnAreYouThere_Click(object sender, EventArgs e)
        {

            try {

                RWS.GAWebServicesClient rwsClient = new RWS.GAWebServicesClient();
                RWS.Authentication authHeader = new RWS.Authentication();

                authHeader.TpId = txtB2BAccount.Text;
                authHeader.Password = txtPassword.Text;
                authHeader.PillarId = "";
                authHeader.StateCode = "";
                authHeader.CustomerId = "";

                RWS.areYouThere ru = new SampleRWSProject.RWS.areYouThere();
                RWS.areYouThereResponse ruresp = new SampleRWSProject.RWS.areYouThereResponse();
                
                ruresp = rwsClient.areYouThere(authHeader, ru);
                txtOut.Text = ruresp.response;

            }
            catch (Exception ex)
            {
                txtOut.Text = "Error: " + ex.Message;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ORD.RetailWebServiceClient ordClient = new ORD.RetailWebServiceClient();
            ORD.Authentication authHeader = new ORD.Authentication();

            authHeader.B2BAccount = txtB2BAccount.Text;
            authHeader.Password = txtPassword.Text;
            authHeader.PillarId = "";
            authHeader.StateCode = "";
            authHeader.CustomerId = "";

            ORD.placeWSOrder ord = new ORD.placeWSOrder();
            ORD.placeWSOrderResponse ordresp = new ORD.placeWSOrderResponse();
            ORD.placeWSOrderRequest ordreq = new ORD.placeWSOrderRequest();
            
            ord.OrderType = "PC01Order";
            ord.WSOrder = "X1234567890 F05 F00123654 F27042011 FD  F01 F0000002118 F                    " 
                        + Environment.NewLine + "0000000050148800078UD" 
                        + Environment.NewLine + "0000000050512300060CD" 
                        + Environment.NewLine + "Z 00004";
            
            ordreq.placeWSOrder = ord;
            ordreq.Authentication = authHeader;
            ordresp = ordClient.placeWSOrder(authHeader, ordreq.placeWSOrder);

            txtOut.Text = ordresp.@return;

        }
    }
}
