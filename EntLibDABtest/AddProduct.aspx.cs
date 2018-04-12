using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntLibDABtest
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            new DLEmployee().PersonelEkle(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        }
    }
}