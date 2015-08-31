using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

//public class Sorter : IComparer<XElement>
//{
//    public int Compare(XElement a, XElement b)
//    {
//        return string.Compare(a.Element("lastName").Value, b.Element("lastName").Value);
//    }
//}

public partial class imgDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string[] imgPaths = Directory.GetFiles(Server.MapPath("~/uploads/"));
            var pathDict = new ArrayList();
            var guestbookFileName = Server.MapPath(
                ConfigurationManager.AppSettings["guestbookFileName"]);

            var xDoc = XDocument.Load(guestbookFileName);

            // LINQ language query sorting with 'orderby' clause
            //var records = (from element in xDoc.Element("guestBook").Elements("entry")
            //    .Where(x => x.Element("approved").Value == "1")
            //    orderby element.Element("lastName").Value, element.Element("firstName").Value
            //    select element);

            // Sorting using custom IComparer class (see Sorter above)
            //var records = xDoc.Element("guestBook").Elements("entry")
            //    .Where(x => x.Element("approved").Value == "1").ToList();
            //records.Sort(new Sorter());

            // LINQ functional query sorting with OrderBy method
            var records = xDoc.Element("guestBook").Elements("entry")
                .Where(x => x.Element("approved").Value == "1")
                .OrderBy(x => x.Element("lastName").Value + " "
                    + x.Element("firstName").Value);

            //var records = xDoc.Element("guestBook").Elements("entry")
            //    .Where(x => x.Element("approved").Value == "1");                

            foreach (var entry in records)
            {
                pathDict.Add(new
                {
                    firstName = entry.Element("firstName").Value,
                    lastName = entry.Element("lastName").Value,
                    url = "~/uploads/" + entry.Element("imgName").Value
                });
            }
            //var records=File.ReadAllLines(Server.MapPath("~/App_Data/record.txt"));

            //for (int i = 0; i < records.Length; i+=4)
            //{
            //    var firstName = records[i];
            //    var lastName = records[i + 1];
            //    var imgName = records[i + 2];
            //    var indicator = records[i + 3];

            //    if(indicator=="0")
            //    {
            //        continue;
            //    }

            //    pathDict.Add(new 
            //    {
            //        firstName=firstName,
            //        lastName=lastName,
            //        url="~/uploads/"+imgName
            //    });
            //}

            //foreach (string imgPath in imgPaths)
            //{
            //    var shortFileName=Path.GetFileName(imgPath);

            //    if (shortFileName == "Thumbs.db")
            //        continue;

            //    pathDict.Add(new
            //    {
            //        name = shortFileName,
            //        url = "~/uploads/" + shortFileName
            //    });
            //}


            lvImages.DataSource = pathDict;
            lvImages.DataBind();

        }
    }
}