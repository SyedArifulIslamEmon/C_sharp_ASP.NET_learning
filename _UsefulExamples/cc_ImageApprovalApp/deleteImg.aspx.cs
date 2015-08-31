using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Configuration;

public partial class deleteImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var guestbookFileName = Server.MapPath(
            ConfigurationManager.AppSettings["guestbookFileName"]);
        var img = Request.QueryString["img"];
        string imgPath = Server.MapPath("~/uploads/" + img);

        //var records = new List<string>(File.ReadAllLines(
        //       Server.MapPath("~/App_Data/record.txt")));
        //var found = false;

        //for (int i = 0; i < records.Count; i += 4)
        //{
        //    if ((string)records[i + 2] == img)
        //    {
        //        found = true;
        //        records.RemoveRange(i, 4);

        //        break;
        //    }
        //}

        var xDoc = XDocument.Load(guestbookFileName);
        var found = xDoc.Element("guestBook").Elements("entry")
            .Where(x => x.Element("imgName").Value == img);



        if (found.Count()==1)
        {
            var entry = found.First();
            entry.Remove();
            xDoc.Save(guestbookFileName);
            File.Delete(imgPath);
            deleteLabel.Text = "Image was successfully deleted.";
            //File.WriteAllLines(Server.MapPath("~/App_Data/record.txt"), 
            //    records.ToArray());
        }
        else
        {
            deleteLabel.Text = "Image does not exist.";
        }
    }
}