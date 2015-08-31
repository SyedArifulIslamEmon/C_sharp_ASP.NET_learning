using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Configuration;

public partial class approveImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var guestbookFileName = Server.MapPath(
            ConfigurationManager.AppSettings["guestbookFileName"]);
        var img = Request.QueryString["img"];
        string fileName= Server.MapPath("~/uploads/"+img);
        

        //if(File.Exists(fileName))
        //{
            //string[] records = File.ReadAllLines(
            //    Server.MapPath("~/App_Data/record.txt"));

            //for (int i = 2; i < records.Length; i+=4)
            //{
            //    if(records[i]==img)
            //    {
            //         records[i+1]="1";
            //    }
            //}

            //File.WriteAllLines(Server.MapPath("~/App_Data/record.txt"), records);

        var xDoc = XDocument.Load(guestbookFileName);
        var found = xDoc.Element("guestBook").Elements("entry")
            .Where(x => x.Element("imgName").Value==img);

        if(found.Count()==1)
        {
            var entry = found.First();

            entry.Element("approved").SetValue(1);
            xDoc.Save(guestbookFileName);

            msgLabel.Text = "Image is approved.";
            imgPage.Text = "See approved images.";
        }
        else
        {
            msgLabel.Text = "Image does not exist.";
        }
        //}
    }
}