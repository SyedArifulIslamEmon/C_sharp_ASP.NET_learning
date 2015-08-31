using System;
using System.Linq;
using System.Web.UI;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void submit_Click(object sender, EventArgs e)
    {
        var guestbookFileName = Server.MapPath(
            ConfigurationManager.AppSettings["guestbookFileName"]);

        //string[] allowedExtensions = {".pdf",".doc",".docx",".png"};
        //string fileExtension = System.IO.Path.GetExtension(resumeFile.PostedFile.FileName);

        string savePath = Server.MapPath("~/uploads/");

        // !!! --- to discuss --- !!!
        //string fileName = imgFile.PostedFile.FileName;

        string[] allowedExtensions = { ".jpg", ".png" }; // declare and set array
        string fileExtension = Path.GetExtension(imgFile.PostedFile.FileName);

        string newFileName = String.Format(@"{0}{1}", Guid.NewGuid(), fileExtension);

        if(!allowedExtensions.Contains(fileExtension.ToLower()))
        {
            string errorMessage = "Allowed file types: "
                + string.Join(", ", allowedExtensions);
            Validators.Add(new ValidationError(errorMessage));
            Validate();
            return;
        }

        imgFile.SaveAs(savePath + newFileName);
        var approveStatus = 0; 
        string imgURL = "http://wwwtest.ccis.edu/test/yw/uploads/" + newFileName;

        // write image info to file
        //using (StreamWriter fileUpdate = File.AppendText(Server.MapPath("~/App_Data/record.txt")))
        //{
        //    fileUpdate.WriteLine(firstName.Text);
        //    fileUpdate.WriteLine(lastName.Text);
        //    fileUpdate.WriteLine(newFileName);
        //    fileUpdate.WriteLine(approveStatus);
        //}

        var xDoc = XDocument.Load(guestbookFileName);
        var entry = new XElement("entry");
        entry.Add(new XElement("firstName",firstName.Text));
        entry.Add(new XElement("lastName", lastName.Text));
        entry.Add(new XElement("imgName", newFileName));
        entry.Add(new XElement("approved", approveStatus));
        xDoc.Element("guestBook").Add(entry);
        xDoc.Save(guestbookFileName);

        /*
        bool failed = true;

        foreach(var ext in allowedExtensions)
        {
            if (ext == fileExtension.ToLower())
            {
                failed = false;
                break;
            }
        }

        if (failed)
        {
            Validators.Add(new ValidationError("ERROR!"));
            return;
        }
        */
        
        //if (!resumeFile.PostedFile.FileName.ToLower().EndsWith(x))
        //{
        //    Validators.Add(new ValidationError("Only PDF files are allowed"));
        //    Validate();
        //    return;
        //}
        

        var smtp = new System.Net.Mail.SmtpClient(
            System.Configuration.ConfigurationManager.AppSettings["smtpServer"]);
        var message = new System.Net.Mail.MailMessage("donotreply@ccis.edu", "ywang23@ccis.edu");
        message.Subject = "* New Application from " + firstName.Text + " " + lastName.Text;
        message.IsBodyHtml = true;
        message.Body = string.Format(@"
            <table border='1' cellpadding='4'>
            <tbody>
            <tr>
            <th>
            First Name:
            </th>
            <td>
            {0}
            </td>
            </tr>
            <tr>
            <th>
            Last Name:
            </th>
            <td>
            {1}
            </td>
            </tr>
            </tbody>
            </table>
            <img src='{2}' height='100' width='100'/>
            <br/>
            <a href='http://wwwtest.ccis.edu/test/yw/deleteImg.aspx?img={3}'>Delete</a>
            <a href='http://wwwtest.ccis.edu/test/yw/approveImg.aspx?img={3}'>Approve</a>
            ", firstName.Text, lastName.Text, imgURL, newFileName);

        //message.Attachments.Add(new System.Net.Mail.Attachment(resumeFile.PostedFile.InputStream, 
        //    resumeFile.PostedFile.FileName));

        //message.Attachments.Add(new System.Net.Mail.Attachment(imgFile.PostedFile.InputStream,
        //    imgFile.PostedFile.FileName));

        try
        {
            smtp.Send(message);
        }
        catch(System.Net.Mail.SmtpException)
        {
            Validators.Add(new ValidationError("Error sending message"));
            Validate();
            return;
        }

        Response.Redirect("thanks.aspx", true);            
    }
}

public class ValidationError : IValidator {
  private string _ErrorMessage;
  private bool _IsValid;
  public string ErrorMessage { get { return this._ErrorMessage; } set { this._ErrorMessage = value; } }
  public bool IsValid { get { return this._IsValid; } set { this._IsValid = value; } }
  public ValidationError(string message) { this.ErrorMessage = message; }
  public void Validate() { this.IsValid = false; }
}
