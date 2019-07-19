using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Exstension;
using WCF.Helpers;
using WCF.WinUI.ServiceReference1;

namespace WCF.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
  ServiceOf_DTOProductsClient client = new ServiceOf_DTOProductsClient();
        private void Form1_Load(object sender, EventArgs e)
        {


         



        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
   
}
