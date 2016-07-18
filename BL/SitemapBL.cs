using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using BE;
using System.Data;

namespace BL
{
    public class SitemapBL
    {
        public void CreateSiteMap()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlTextWriter xmlWriter = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/Web.sitemap"), System.Text.Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            xmlWriter.WriteStartElement("siteMap", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
            xmlWriter.Close();

            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/Web.sitemap"));

            XmlElement xmlRoot = xmlDoc.DocumentElement;
            XmlElement xmlSitemapPocetna;

            xmlSitemapPocetna = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapPocetna.SetAttribute("url", "/");
            xmlSitemapPocetna.SetAttribute("title", "Početna strana");
            xmlSitemapPocetna.SetAttribute("description", "Početna strana");
            xmlRoot.AppendChild(xmlSitemapPocetna);

            XmlElement xmlSitemapMenu;
            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/chiptuning/povecanje-snage");
            xmlSitemapMenu.SetAttribute("title", "Povećanje snage motora");
            xmlSitemapMenu.SetAttribute("description", "Povećanje snage motora");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/chiptuning/smanjenje-potrosnje");
            xmlSitemapMenu.SetAttribute("title", "Smanjenje potrošnje goriva");
            xmlSitemapMenu.SetAttribute("description", "Smanjenje potrošnje goriva");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/chiptuning/najcesca-pitanja");
            xmlSitemapMenu.SetAttribute("title", "Najčešća pitanja");
            xmlSitemapMenu.SetAttribute("description", "Najčešća pitanja");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/chiptuning/eko-chiptuning-kamioni");
            xmlSitemapMenu.SetAttribute("title", "Eko chip tuning za kamione");
            xmlSitemapMenu.SetAttribute("description", "Eko chip tuning za kamione");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/projekti");
            xmlSitemapMenu.SetAttribute("title", "Projekti");
            xmlSitemapMenu.SetAttribute("description", "Projekti");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/kontakt");
            xmlSitemapMenu.SetAttribute("title", "Kontakt");
            xmlSitemapMenu.SetAttribute("description", "Kontakt");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapMenu.SetAttribute("url", "/gde-se-nalazimo");
            xmlSitemapMenu.SetAttribute("title", "Gde se nalazimo");
            xmlSitemapMenu.SetAttribute("description", "Gde se nalazimo");
            xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            //xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            //xmlSitemapMenu.SetAttribute("url", "/vozila/putnicka");
            //xmlSitemapMenu.SetAttribute("title", "Putnička");
            //xmlSitemapMenu.SetAttribute("description", "Putnička vozila");

            xmlSitemapPocetna.AppendChild(returnByType("putnicka", xmlDoc, "Putnička vozila"));
            xmlSitemapPocetna.AppendChild(returnByType("suv", xmlDoc, "SU"));
            xmlSitemapPocetna.AppendChild(returnByType("kamioni", xmlDoc, "Kamioni"));
            xmlSitemapPocetna.AppendChild(returnByType("komercijlna", xmlDoc, "Komercijalna"));
            xmlSitemapPocetna.AppendChild(returnByType("motocikli", xmlDoc, "Motocikli"));

            //xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            //xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            //xmlSitemapMenu.SetAttribute("url", "/vozila/suv");
            //xmlSitemapMenu.SetAttribute("title", "SUV");
            //xmlSitemapMenu.SetAttribute("description", "SUV vozila");
            //xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            //xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            //xmlSitemapMenu.SetAttribute("url", "/vozila/kamioni");
            //xmlSitemapMenu.SetAttribute("title", "Kamioni");
            //xmlSitemapMenu.SetAttribute("description", "Kamioni");
            //xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            //xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            //xmlSitemapMenu.SetAttribute("url", "/vozila/komercijalna");
            //xmlSitemapMenu.SetAttribute("title", "Komercijalna");
            //xmlSitemapMenu.SetAttribute("description", "Komercijalna");
            //xmlSitemapPocetna.AppendChild(xmlSitemapMenu);

            //xmlSitemapMenu = xmlDoc.CreateElement("siteMapNode");
            //xmlSitemapMenu.SetAttribute("url", "/vozila/motocikli");
            //xmlSitemapMenu.SetAttribute("title", "Motocikli");
            //xmlSitemapMenu.SetAttribute("description", "Motocikli");
            //\xmlSitemapPocetna.AppendChild(xmlSitemapMenu);


            xmlDoc.Save(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
        }

        private XmlElement returnByType(string typeUrl, XmlDocument xmlDoc, string typeName)
        {
            XmlElement xmlSitemapType = xmlDoc.CreateElement("siteMapNode");
            xmlSitemapType.SetAttribute("url", "/vozila/" + typeUrl);
            xmlSitemapType.SetAttribute("title", typeName);
            xmlSitemapType.SetAttribute("description", typeName);
            List<Manufacturer> manufacturers = new ManufacturerBL().GetByType(typeUrl, false);
            foreach (Manufacturer manufacturer in manufacturers)
            {
                XmlElement xmlSitemapManufacturer = xmlDoc.CreateElement("siteMapNode");
                xmlSitemapManufacturer.SetAttribute("url", "/vozila/" + typeUrl + "/" + manufacturer.Url);
                xmlSitemapManufacturer.SetAttribute("title", manufacturer.Name);
                xmlSitemapManufacturer.SetAttribute("description", manufacturer.Name);

                DataTable models = new ModelBL().GetByManufacturerUrl(manufacturer.Url, false, typeUrl);
                foreach (DataRow row in models.Rows)
                {
                    XmlElement xmlSitemapModel = xmlDoc.CreateElement("siteMapNode");
                    xmlSitemapModel.SetAttribute("url", "/vozila/" + typeUrl + "/" + manufacturer.Url + "/" + row["url"].ToString());
                    xmlSitemapModel.SetAttribute("title", row["name"].ToString());
                    xmlSitemapModel.SetAttribute("description", row["name"].ToString());

                    DataTable engines = new EngineBL().GetByModelUrl(row["url"].ToString(), manufacturer.Url);
                    foreach (DataRow engineRow in engines.Rows)
                    {
                        XmlElement xmlSitemapEngine = xmlDoc.CreateElement("siteMapNode");
                        xmlSitemapEngine.SetAttribute("url", "/vozila/" + typeUrl + "/" + manufacturer.Url + "/" + row["url"] + "/" + engineRow["url"].ToString());
                        xmlSitemapEngine.SetAttribute("title", engineRow["name"].ToString());
                        xmlSitemapEngine.SetAttribute("description", engineRow["name"].ToString());
                        xmlSitemapModel.AppendChild(xmlSitemapEngine);
                    }
                    xmlSitemapManufacturer.AppendChild(xmlSitemapModel);
                }
                xmlSitemapType.AppendChild(xmlSitemapManufacturer);
            }
            return xmlSitemapType;
        }
    }
}
