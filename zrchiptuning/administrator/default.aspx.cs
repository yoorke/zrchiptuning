using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BL;
using System.Threading;
using Utility;

namespace zrchiptuning.administrator
{
    public delegate void LoadEngines(string url, int modelID);

    public partial class _default : System.Web.UI.Page
    {
        public delegate void LoadModels();
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadModels_Click(object sender, EventArgs e)
        {
            //new ModelBL().LoadData();
            //LoadModels loadData = new LoadModels(new ModelBL().LoadData);
            //loadData.BeginInvoke(null, null);

            //List<Model> models = new ModelBL().GetAll();
            //foreach(Model model in models)
            //{
                //LoadEngines loadEngines = new LoadEngines(new EngineBL().LoadData);
                //loadEngines.BeginInvoke(model.Manufacturer.Url + "/" + model.Url, model.ID, null, null);
                //Thread.Sleep(1000);
            //}
        }

        protected void btnLoadEngines_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateSitemap_Click(object sender, EventArgs e)
        {
            new SitemapBL().CreateSiteMap();
        }
    }
}