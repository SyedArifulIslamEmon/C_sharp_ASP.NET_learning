using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckOtherTextBox
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBox1.Visible = true;
                RequiredFieldValidator.Enabled = true;
            }
            else
            {
                TextBox1.Visible = false;
                RequiredFieldValidator.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
                 var other_field = "";

                 if (CheckBox1.Checked)
                 {
                    other_field = String.Format("<tr><th>Other:</th><td>{0}</td></tr>", TextBox1.Text);
                 }
            */


            // when calender not valid, returns to page instead of submission
            // check before sending out email
            if(!IsValid)
            {
                return;
            }

            // define new email, from 'donotreply@ccis.edu' to 'ywang23@ccis.edu' 
            var message = new System.Net.Mail.MailMessage("donotreply@ccis.edu", 
                "ywang23@ccis.edu");

            // set email body to html
            message.IsBodyHtml = true;

            // format email body
            message.Body = String.Format(@"
                <table>
                <tbody>
                <tr>
                <th>Name: </th>
                <td>{0}</td>
                </tr>
                <tr>
                <th>Date: </th>
                <td>{1}</td>
                </tr>
                {2}
                </tbody>
                </table>",
                txtName.Text,
                calDate.SelectedDate.ToShortDateString(), // only displays date, not time.
                // if checkbox 'Other' is checked, display text in the related textbox.
                // if not, display nothing.
                CheckBox1.Checked
                    ? String.Format("<tr><th>Other:</th><td>{0}</td></tr>", TextBox1.Text)
                    : ""
                );

            // set email subject/title
            message.Subject = "* New Submission";

            // set email cilent, send email trough email client
            var client = new System.Net.Mail.SmtpClient("ccsmtp.ccis.edu");
            client.Send(message);
        }

        // custome validator on calender date choosing
        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // if date not selected or set on default, submission not valid
            if (calDate.SelectedDate == null 
                || calDate.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
        }

    }
}