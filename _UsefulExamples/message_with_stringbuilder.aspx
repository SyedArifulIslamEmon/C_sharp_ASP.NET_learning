// string builder with message body
var body = new System.Text.StringBuilder();

var message = new MailMessage();
message.From = new MailAddress("DoNotReply@ccis.edu");
message.To.Add(new MailAddress("ywang23@ccis.edu"));
message.IsBodyHtml = true;
message.Subject = "* Promotional Items Order from " + txtFirstName.Text + " " +
   txtLastName.Text.ToString();

// append html to message body
body.Append(string.Format(@"<h3>Promotional Items Order Info</h3><p>{0}</p>
               <table border=""1"" cellpadding=""4"" cellspacing=""0"">
               <caption><strong>Customer Info</strong></caption>
               <tr><td><strong>Name</strong>:{1}</td><td>{2}</td></tr>
               <tr><td><strong>Department</strong>:</td><td>{3}</td></tr>
               <tr><td><strong>Mailing Address</strong>:</td><td>{4}{5}{6}{7}</td></tr>
               <tr><td><strong>Date Needed</strong>:</td><td>{8}</td></tr>
               <tr><td><strong>Email</strong>:</td><td>{9}</td></tr>
               <tr><td><strong>GL#</strong>:</td><td>{10}</td></tr></table><br/>",
               DateTime.Now, txtFirstName.Text, txtLastName.Text, txtDepartment.Text,
               txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtDateNeeded.Text,
               txtEmail.Text, txtGL.Text));

// append more html
body.Append(string.Format(@"
               <table border=""1"" cellpadding=""4"" cellspacing=""0"">
               <caption><strong>Order Details</strong></caption>
               <thead>
               <td><strong>Item</strong></td>
               <td><strong>Amount</strong></td>
               <td><strong>Total</strong></td>
               </thead><tbody>
               "));


// loop
foreach ( )
{
    foreach ( )
    {
        if ( )
        {
            // append more stuff through loop
            body.Append("<tr><td>" + itemTitle + "</td>" + "<td>" + txtAmount +
                "</td>" + "<td>" + itemTotal.ToString("c") + "</td></tr>");
        }
    }
}

// append even more stuff to message body
body.Append(string.Format(@"
    <tr>
        <td colspan=""2"">
            <strong>Grand Total:</strong>
        </td>
        <td>
            <strong>{0:c}</strong>
        </td>
    </tr>
    </tbody>
    </table>",
    orderTotal));

message.Body = body.ToString();      // convert message body to string before sending
SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);

try
{
    client.Send(message);
    var ThankYouItem = Sitecore.Context.Item.Children["Thank-you"];
    var ThankYouUrl = Sitecore.Links.LinkManager.GetItemUrl(ThankYouItem);
    Response.Redirect(ThankYouUrl);

}
catch (SmtpException ex)
{
    smtpException.Visible = true;
}
