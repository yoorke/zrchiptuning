using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Services;
using BL;
using BE;
using System.Data;
using Utility;

namespace zrchiptuning
{
    public partial class WebMethods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static string GetTypes(bool addSelect)
        {
            List<BE.Type> types = new TypeBL().GetAll(addSelect);
            var typeItems = (from type in types
                             select new
                             {
                                 id = type.Url,
                                 name = type.Name
                             });
            return JsonConvert.SerializeObject(typeItems, Formatting.None);
        }

        [WebMethod()]
        public static string GetManufacturers(bool addSelect, string type)
        {
            List<Manufacturer> manufacturers = new ManufacturerBL().GetByType(type, addSelect);
            var manufacturerItems = (from manufacturer in manufacturers
                                     
                                     select new
                                     {
                                         id = manufacturer.Url,
                                         name = manufacturer.Name
                                     });
            return JsonConvert.SerializeObject(manufacturerItems, Formatting.None);
        }

        [WebMethod()]
        public static string GetModels(bool addSelect, string manufacturer, string type)
        {
            List<Model> models = new ModelBL().GetListByManufacturerUrl(manufacturer, addSelect, type);
            var modelItems = (from model in models
                              
                              select new
                              {
                                  id = model.Url,
                                  name = model.Name
                              });
            return JsonConvert.SerializeObject(modelItems, Formatting.None);
        }

        [WebMethod()]
        public static string GetEngines(bool addSelect, string modelUrl, string manufacturerUrl)
        {
            List<Engine> engines = new EngineBL().GetListByModelUrl(modelUrl, addSelect, manufacturerUrl);
            var engineItems = (from engine in engines
                               select new
                               {
                                   id = engine.Url,
                                   name = engine.Name,
                                   power = engine.PowerKw
                               });
            return JsonConvert.SerializeObject(engineItems, Formatting.None);
        }

        [WebMethod()]
        public static string SendMail(string heading, string email, string message)
        {
            if (Common.SendMail(heading, email, message))
                JsonConvert.SerializeObject("Poruka uspešno poslata");
            else
                throw new Exception("Nije moguće poslati poruku.");
            return string.Empty;
        }
    }
}