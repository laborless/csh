using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Constructor
        public Form1()
        {
            InitializeComponent();

            this.axKHOpenAPI1.OnEventConnect += axKHOpenAPI_OnEventConnect;

            if (axKHOpenAPI1.CommConnect() != 0)
            {
                MessageBox.Show("Login Fail");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            switch (e.nErrCode)
            {
                case 0:
                    MessageBox.Show("정상처리");
                    break;
                default:
                    MessageBox.Show("Login Fail_2");
                    break;
            }
        }

        //Destructor
        ~Form1()
        {
            //if still connected with server, terminate connection
            if(this.axKHOpenAPI1.GetConnectState() == 1)
            {
                this.axKHOpenAPI1.CommTerminate();
                MessageBox.Show("Log off");
                MessageBox.Show("test");
            }
        }
    }
}
