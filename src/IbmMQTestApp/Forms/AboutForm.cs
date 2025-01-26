using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbmMQTestApp.Forms
{
    public partial class AboutForm : Form
    {
        private string _version = "1.0.0";


        private string ibmText = "About IBM MQ\n\n" +
                           "IBM MQ is a robust messaging middleware that simplifies and accelerates the integration of diverse applications and business data across multiple platforms. " +
                           "It provides a reliable and secure messaging infrastructure that ensures the delivery of messages between applications, systems, and services.\n" +
                           "IBM MQ is a product of IBM Corporation. All rights to IBM MQ, including its trademarks, service marks, and logos, are the exclusive property of IBM Corporation. " +
                           "Unauthorized use of IBM MQ or any of its components is strictly prohibited.\n" +
                           "For more information about IBM MQ, please visit the official IBM website at https://www.ibm.com/products/mq.\n\n" +
                           "© " + DateTime.Now.Year + " IBM Corporation. All rights reserved.";

        private string aboutText = "Designed to help and improve Developers and Stakeholders to build their goals.\n" +
                                   "Develop by: Rafael WMS\n" +
                                   "Github: https://github.com/rafaelwms \n" +
                                   "Site: https://rafaelwms.com.br";

        public AboutForm()
        {
            InitializeComponent();
            label1.Text = ibmText;
            label3.Text = aboutText;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
