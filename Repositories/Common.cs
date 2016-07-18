using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using Utility.ExceptionHandling;

namespace Repositories
{
    public class SpNames
    {
        private static SpNames _instance;
        private XElement _xElement = XElement.Load(System.Web.HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["spNamesPath"]));
        public XElement XElement
        {
            get { return _xElement; }
        }

        public static SpNames Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SpNames();
                return _instance;
            }
        }
    }

    public class Common
    {
        public string GetSpName(string className, string elementName)
        {
            string result = string.Empty;
            try
            {
                result = (from el in SpNames.Instance.XElement.Elements()
                          where ((string)el.Element("name")).ToLower() == className.ToLower()
                          select el.Element(elementName).Value).FirstOrDefault();
            }
            catch(NullReferenceException ex)
            {
                throw new DLException(className + " does not have element " + elementName + " in spNames.xml", ex);
            }
            return result;
        }
    }
}
