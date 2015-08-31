using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = "Yao's hello world";
        }


        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
        }
    }
}