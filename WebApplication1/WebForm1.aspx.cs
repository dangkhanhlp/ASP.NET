using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void btTong_Click(object sender, EventArgs e)
        {
            Double so1, so2, tong;
            so1 = Double.Parse(txtSoA.Text);
            so2 = Double.Parse(txtSoB.Text);
            tong = so1 + so2;
            txtTong.Text = tong.ToString();
        }
    }
}