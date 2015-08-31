using System;
using System.IO;

namespace txtComment
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string[] comments = File.ReadAllLines(Server.MapPath("~/App_Data/guestbook.txt"));

            lstGuestbook.DataSource = comments;
            lstGuestbook.DataBind();

            //foreach(string comment in comments)
            //{
            //    lstGuestbook.Items.Add(comment);
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lstGuestbook.Items.Add(txtComment.Text);
            using (StreamWriter fileUpdate = File.AppendText(Server.MapPath("~/App_Data/guestbook.txt")))
            {
                fileUpdate.WriteLine(txtComment.Text);
            }
        }
    }
}