using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using BE;
using System.Data;
using System.Web.Security;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading;
using System.Web;

namespace BL
{
    

    public class ModelBL
	{
		public List<BE.Model> GetAll()
		{
            return new ModelRepository().GetAll();
		}

		public int Save(BE.Model model)
		{
			ModelRepository repository = new ModelRepository();
			if(model.ID > 0)
				return repository.Update(model);
			else
				return repository.Insert(model);
		}

		public bool Delete(BE.Model model)
		{
            return new ModelRepository().Delete(model);
		}

		public BE.Model GetModel(int id)
		{
            return new ModelRepository().GetByID(id);
		}

        public List<Model> GetByManufacturerID(int manufacturerID, bool addSelect)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("manufacturerID", manufacturerID));

            return (addSelect) ? getEmpty(new ModelRepository().GetByParameter("getByManufacturer", parameters)) : new ModelRepository().GetByParameter("getByManufacturer", parameters);
        }

        public DataTable GetByManufacturerUrl(string manufacturerUrl, bool addSelect, string typeUrl)
        {
          List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));
            if (typeUrl != string.Empty)
                parameters.Add(new QueryParameter("typeUrl", typeUrl));

            return (addSelect) ? getEmpty(new ModelRepository().GetDataTable("model", "getByManufacturerUrl", parameters)) : new ModelRepository().GetDataTable("model", "getByManufacturerUrl", parameters);
        }

        public List<Model> GetListByManufacturerUrl(string manufacturerUrl, bool addSelect, string type)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));
            parameters.Add(new QueryParameter("typeUrl", type));

            return (addSelect) ? getEmpty(new ModelRepository().GetByParameter("getByManufacturerUrl", parameters)) : new ModelRepository().GetByParameter("getByManufacturer", parameters);
        }

        public Model GetByUrl(string url, string manufacturerUrl)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("url", url));
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));

            List<Model> models = new ModelRepository().GetByParameter("getByUrl", parameters, false);
            return models.Count > 0 ? models[0] : null;
        }

        private List<Model> getEmpty(List<Model> models)
        {
            models.Insert(0, new Model("Odaberi", null, null, -1, null, string.Empty, "Odaberi"));
            return models;
        }

        private DataTable getEmpty(DataTable dataTable)
        {
            DataRow newRow = dataTable.NewRow();
            newRow[0] = -1;
            newRow[1] = "Odaberi";
            newRow[2] = 0;
            dataTable.Rows.InsertAt(newRow, 0);
            return dataTable;
        }

        public void LoadData(int manufacturerID)
        {
            //FormsAuthentication.SetAuthCookie("admin", true);
            //List<Manufacturer> manufacturers = new GenericRepository<Manufacturer>().GetAll();
            Manufacturer manufacturer = new GenericRepository<Manufacturer>().GetByID(manufacturerID);

            //foreach (Manufacturer manufacturer in manufacturers)
            //{ 
                //if (manufacturer.Url == url.Substring(url.LastIndexOf('/') + 1))
                    //selectedManufacturer = manufacturer;

                HttpClient http = new HttpClient();
                WebClient client = new WebClient();
            //var response = await http.GetByteArrayAsync("http://www.smchiptuning.com/auto/" + manufacturer.Url);

            //string source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            //source = WebUtility.HtmlDecode(source);
            //string source = client.DownloadString("http://www.smchiptuning.com/auto/" + manufacturer.Url);
            //string source = client.DownloadString("http://www.smchiptuning.com/kamioni/" + manufacturer.Url);
            string source = client.DownloadString("http://www.smchiptuning.com/moto/" + manufacturer.Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(source);

                List<HtmlNode> models = html.DocumentNode.Descendants().Where(x => (x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("slike"))).ToList();

            
            
            

                foreach(HtmlNode modelNode in models)
                {
                    BE.Model model = new Model();
                    model.Name = modelNode.InnerText;
                    model.ImageUrl = modelNode.FirstChild.FirstChild.Attributes["src"].Value.Substring(modelNode.FirstChild.FirstChild.Attributes["src"].Value.LastIndexOf('/') + 1).Replace(' ', '-');
                //model.Type = new BE.Type("Putnicka", 1, "putnicka");
                //model.Type = new BE.Type("Kamioni", 3, "kamioni");
                    model.Type = new BE.Type("Motocikli", 5, "motocikli");
                    string modelUrl = modelNode.FirstChild.Attributes["href"].Value;
                    model.Url = modelUrl.Substring(modelUrl.LastIndexOf('/') + 1);
                    model.Manufacturer = manufacturer;
                    model.SupplierID = 1;

                    client = new WebClient();
                    client.DownloadFile("http://www.smchiptuning.com/" + modelNode.FirstChild.FirstChild.Attributes["src"].Value, HttpContext.Current.Server.MapPath("~/images/car-logos/" + manufacturer.Url + "/models/" + modelNode.FirstChild.FirstChild.Attributes["src"].Value.Substring(modelNode.FirstChild.FirstChild.Attributes["src"].Value.LastIndexOf("/") + 1).Replace(' ', '-')));

                    model.ID = new GenericRepository<Model>().Insert(model);

                    //LoadEngines loadEngines = new LoadEngines(new EngineBL().LoadData);
                    //loadEngines.BeginInvoke(manufacturer.Url + "/" + model.Url, model.ID, null, null);

                    client = new WebClient();
                //string enginesSource = client.DownloadString("http://www.smchiptuning.com/auto/" + manufacturer.Url + "/" + model.Url);
                //string enginesSource = client.DownloadString("http://www.smchiptuning.com/kamioni/" + manufacturer.Url + "/" + model.Url);
                string enginesSource = client.DownloadString("http://www.smchiptuning.com/moto/" + manufacturer.Url + "/" + model.Url);
                HtmlDocument enginesHtml = new HtmlDocument();
                    enginesHtml.LoadHtml(enginesSource);

                    List<HtmlNode> engines = enginesHtml.DocumentNode.SelectNodes("//tr[@onclick]").ToList();

                    foreach(HtmlNode engineNode in engines)
                    {
                    
                    try
                    { 
                        string engineUrl = engineNode.ChildNodes[5].FirstChild.Attributes["href"].Value;
                        string name = engineNode.ChildNodes[5].InnerText;
                        string ks = engineNode.ChildNodes[7].InnerText;
                        string kw = engineNode.ChildNodes[9].InnerText;
                        Engine engine = new Engine();
                        StringBuilder capacity = new StringBuilder();
                        int i = 0;
                        while (i <= name.Length - 1 && name[i] != ' ')
                            capacity.Append(name[i++]);
                        double capacityOut = 0;
                        double.TryParse(capacity.ToString().Replace('.',','), out capacityOut);
                        engine.Capacity = capacityOut;
                        engine.PowerKs = int.Parse(ks);
                        engine.PowerKw = int.Parse(kw);
                        engine.Url = engineUrl.Substring(engineUrl.LastIndexOf("/") + 1).Replace(manufacturer.Url, "").Replace(model.Url, "").Replace(".", "");
                        if (engine.Url.StartsWith("--"))
                            engine.Url = engine.Url.Substring(2, engine.Url.Length - 2);
                        engine.Fuel = new Fuel(string.Empty, 1);
                        engine.MaxSpeed = 0;
                        engine.Torq = 0;
                        engine.Name = name;
                        engine.TorqRpm = 0;
                        engine.KsRpm = 0;

                        string engineSource = client.DownloadString("http://www.smchiptuning.com/" + engineUrl);
                        HtmlDocument engineHtml = new HtmlDocument();
                        engineHtml.LoadHtml(engineSource);

                        List<HtmlNode> engineRows = engineHtml.DocumentNode.SelectNodes("//table[@id='tabela']").Descendants("tr").ToList();

                        string originalPower = engineRows[1].ChildNodes[3].InnerText;
                        int originalPowerKs = 0;
                        //int.TryParse(originalPower.Substring(0, originalPower.IndexOf("/")), out originalPowerKs);
                        int.TryParse(originalPower, out originalPowerKs);
                        int originalKsRpm = 0;
                        //int.TryParse(originalPower.Substring(originalPower.IndexOf("/") + 1), out originalKsRpm);

                        string originalTorq = engineRows[2].ChildNodes[3].InnerText;
                        int originalTorqValue = 0;
                        int.TryParse(originalTorq.Substring(0, originalTorq.IndexOf("/")), out originalTorqValue);
                        int originalTorqRpm = 0;
                        int.TryParse(originalTorq.Substring(originalTorq.IndexOf("/") + 1), out originalTorqRpm);

                        engine.KsRpm = originalKsRpm;
                        //engine.KsRpm = 0;
                        engine.Torq = originalTorqValue;
                        engine.TorqRpm = originalTorqRpm;

                        

                        engine.ID = new GenericRepository<Engine>().Insert(engine);

                        new GenericRepository<ModelEngine>().Insert(new ModelEngine(model, engine, -1));

                        string stage1Power = engineRows[1].ChildNodes[5].InnerText;
                        int stage1PowerKs = 0;
                        //int.TryParse(stage1Power.Substring(0, stage1Power.IndexOf("/")), out stage1PowerKs);
                        int.TryParse(stage1Power, out stage1PowerKs);
                        int stage1KsRpm = 0;
                        //int.TryParse(stage1Power.Substring(stage1Power.IndexOf("/") + 1), out stage1KsRpm);

                        string stage1Torq = engineRows[2].ChildNodes[5].InnerText;
                        int stage1TorqValue = 0;
                        int.TryParse(stage1Torq.Substring(0, stage1Torq.IndexOf("/")), out stage1TorqValue);
                        int stage1TorqRpm = 0;
                        int.TryParse(stage1Torq.Substring(stage1Torq.IndexOf("/") + 1), out stage1TorqRpm);

                        //string stage2Power = engineRows[1].ChildNodes[7].InnerText;
                        //int stage2PowerKs = 0;
                        //int.TryParse(stage2Power.Substring(0, stage2Power.IndexOf("/")), out stage2PowerKs);
                        //int.TryParse(stage2Power, out stage2PowerKs);
                        //int stage2KsRpm = 0;
                        //int.TryParse(stage2Power.Substring(stage2Power.IndexOf("/") + 1), out stage2KsRpm);

                        //string stage2Torq = engineRows[2].ChildNodes[7].InnerText;
                        //int stage2TorqValue = 0;
                        //int.TryParse(stage2Torq.Substring(0, stage2Torq.IndexOf("/")), out stage2TorqValue);
                        //int stage2TorqRpm = 0;
                        //int.TryParse(stage2Torq.Substring(stage2Torq.IndexOf("/") + 1), out stage2TorqRpm);



                        EngineStage stage = new EngineStage();
                        stage.EngineID = engine.ID;
                        stage.Stage = new Stage("Stage 1", 1005);
                        stage.MaxSpeed = 0;
                        stage.PowerKs = stage1PowerKs;
                        stage.PowerKsRpm = stage1KsRpm;
                        stage.Torq = stage1TorqValue;
                        stage.TorqRpm = stage1TorqRpm;
                        stage.PowerKw = (int)(stage.PowerKs / 1.36);

                        new GenericRepository<EngineStage>().Insert(stage);

                        //stage = new EngineStage();
                        //stage.EngineID = engine.ID;
                        //stage.Stage = new Stage("Stage 2", 1006);
                        //stage.MaxSpeed = 0;
                        //stage.PowerKs = stage2PowerKs;
                        //stage.PowerKsRpm = stage2KsRpm;
                        //stage.Torq = stage2TorqValue;
                        //stage.TorqRpm = stage2TorqRpm;
                        //stage.PowerKw = (int)(stage.PowerKs / 1.36);

                        //new GenericRepository<EngineStage>().Insert(stage);

                        Thread.Sleep(1000);
                    }
                    catch(Exception ex)
                    {

                    }
                    }
                    
                    
                

                

            }
            //}
        }

        public void LoadDataMcChip(int manufacturerID, int typeID)
        {
            Manufacturer manufacturer = new GenericRepository<Manufacturer>().GetByID(manufacturerID);

            WebClient client = new WebClient();
            string source = client.DownloadString("http://mcchip-dkr.com/en/chiptuning/car_" + manufacturer.Url);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(source);

            List<HtmlNode> models = html.DocumentNode.Descendants("a").Where(x => (x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("uk-thumbnail"))).ToList();

            foreach(HtmlNode modelNode in models)
            {
                try
                {
                    Model model = new Model();
                    model.Name = modelNode.InnerText.Trim();
                    string modelUrl = modelNode.Attributes[1].Value;
                    model.Url = modelNode.Attributes[1].Value.Substring(modelNode.Attributes[1].Value.IndexOf("_") + 1).Replace(manufacturer.Url, "").Substring(1);

                    string imageUrl = modelNode.ChildNodes[1].Attributes[0].Value;
                    model.ImageUrl = modelNode.ChildNodes[1].Attributes[0].Value.Substring(modelNode.ChildNodes[1].Attributes[0].Value.LastIndexOf("/") + 1);
                    model.Type = new GenericRepository<BE.Type>().GetByID(typeID);
                    model.Manufacturer = manufacturer;
                    model.SupplierID = 2;

                    client = new WebClient();
                    client.DownloadFile("http://www.mcchip-dkr.com" + modelNode.ChildNodes[1].Attributes[0].Value, HttpContext.Current.Server.MapPath("~/images/car-logos/" + manufacturer.Url + "/models/mc/" + modelNode.ChildNodes[1].Attributes[0].Value.Substring(modelNode.ChildNodes[1].Attributes[0].Value.LastIndexOf("/") + 1)));

                    model.ID = new GenericRepository<Model>().Insert(model);

                    client = new WebClient();
                    string enginesSource = client.DownloadString("http://mcchip-dkr.com" + modelUrl);

                    HtmlDocument enginesHtml = new HtmlDocument();
                    enginesHtml.LoadHtml(enginesSource);
                    List<HtmlNode> engines = enginesHtml.DocumentNode.SelectNodes("//tr[@onclick]").ToList();

                    foreach (HtmlNode engineNode in engines)
                    {
                        Engine engine = new Engine();
                        engine.Name = engineNode.ChildNodes[3].InnerText;
                        string engineUrl = engineNode.ChildNodes[1].ChildNodes[0].Attributes[0].Value;
                        engine.Url = engineNode.ChildNodes[1].ChildNodes[0].Attributes[0].Value.Substring(engineNode.ChildNodes[1].ChildNodes[0].Attributes[0].Value.IndexOf("_") + 1).Replace(manufacturer.Url, "").Substring(1).Replace(model.Url, "").Substring(1);
                        double capacity = 0;
                        double.TryParse(engineNode.ChildNodes[5].InnerText.Substring(0, engineNode.ChildNodes[5].InnerText.IndexOf(" ")), out capacity);
                        engine.Capacity = capacity;
                        int powerKw = 0;
                        int powerKs = 0;
                        int.TryParse(engineNode.ChildNodes[7].InnerText.Substring(engineNode.ChildNodes[7].InnerText.IndexOf("/") + 1, engineNode.ChildNodes[7].InnerText.IndexOf("kW") - engineNode.ChildNodes[7].InnerText.IndexOf("/") - 1), out powerKw);
                        int.TryParse(engineNode.ChildNodes[7].InnerText.Substring(0, engineNode.ChildNodes[7].InnerText.IndexOf("PS")), out powerKs);
                        engine.PowerKs = powerKs;
                        engine.PowerKw = powerKw;
                        engine.Fuel = new GenericRepository<Fuel>().GetByID(1);
                        engine.MaxSpeed = 0;
                        engine.Torq = 0;
                        engine.KsRpm = 0;
                        engine.TorqRpm = 0;

                        client = new WebClient();
                        string engineString = client.DownloadString("http://mcchip-dkr.com" + engineUrl);
                        HtmlDocument engineHtml = new HtmlDocument();
                        engineHtml.LoadHtml(engineString);

                        List<HtmlNode> engineData = engineHtml.DocumentNode.SelectNodes("//tr").ToList();
                        EngineStage stage = new EngineStage();
                        int count = 0;
                        foreach (HtmlNode engineDataNode in engineData)
                        {



                            if (count < 4)
                            {
                                if (engineDataNode.InnerText.ToString().StartsWith(" Torque"))
                                {
                                    engine.Torq = int.Parse(engineDataNode.ChildNodes[3].InnerText.Substring(0, engineDataNode.ChildNodes[3].InnerText.IndexOf(" ")));
                                    stage.Torq = int.Parse(engineDataNode.ChildNodes[5].InnerText.Substring(0, engineDataNode.ChildNodes[5].InnerText.IndexOf(" ")));
                                    stage.TorqRpm = 0;
                                }
                                if (engineDataNode.InnerText.ToString().StartsWith(" Maximum speed"))
                                {
                                    engine.MaxSpeed = int.Parse(engineDataNode.ChildNodes[3].InnerText.Substring(0, engineDataNode.ChildNodes[3].InnerText.IndexOf(" ")));
                                    stage.MaxSpeed = int.Parse(engineDataNode.ChildNodes[5].InnerText.Substring(0, engineDataNode.ChildNodes[5].InnerText.IndexOf(" ")));


                                }



                                if (engineDataNode.InnerText.ToString().StartsWith(" Performance"))
                                {

                                    stage.PowerKw = int.Parse(engineDataNode.ChildNodes[7].InnerText.Substring(engineDataNode.ChildNodes[7].InnerText.IndexOf("/") + 2, engineDataNode.ChildNodes[7].InnerText.IndexOf("kW") - engineDataNode.ChildNodes[7].InnerText.IndexOf("/") - 2));
                                    stage.PowerKs = int.Parse(engineDataNode.ChildNodes[7].InnerText.Substring(0, engineDataNode.ChildNodes[7].InnerText.IndexOf("PS")));
                                }
                                count++;
                            }
                        }
                        engine.ID = new GenericRepository<Engine>().Insert(engine);
                        stage.EngineID = engine.ID;
                        stage.Stage = new Stage("Stage 1", 1005);
                        new GenericRepository<ModelEngine>().Insert(new ModelEngine(model, engine, -1));
                        new GenericRepository<EngineStage>().Insert(stage);
                    }
                }
                catch(Exception ex)
                {
                    Console.Write(modelNode.InnerText);
                }
            }
        }

        public void LoadFromAllCarTuning(string modelUrl, int modelID)
        {
            WebClient client = new WebClient();
            string source = client.DownloadString(modelUrl);

            string allCarTuningBaseUrl = "https://allcartuning.com/";

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(source);

            Model model = new ModelBL().GetModel(modelID);

            List<HtmlNode> engines = html.DocumentNode.Descendants("a").Where(x => (x.Attributes["href"] != null && x.Attributes["href"].Value.Contains("en/chiptuning-configurator-car/details/"))).ToList();

            foreach(HtmlNode engine in engines)
            {
                string engineData = client.DownloadString(allCarTuningBaseUrl + engine.Attributes["href"].Value);
                HtmlDocument htmlEngine = new HtmlDocument();
                htmlEngine.LoadHtml(engineData);

                Engine engineModel = new Engine();

                HtmlNode nameString = htmlEngine.DocumentNode.Descendants("span").Where(x => x.Attributes.Count > 0 && x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("modelsHeader")).ToList()[0];
                string nameValue = nameString.FirstChild.InnerText.Substring(nameString.FirstChild.InnerText.LastIndexOf("&nbsp;")).Remove(0, 6);

                engineModel.Name = nameValue;
                engineModel.Url = nameValue.ToLower().Replace(' ', '-');
                engineModel.Capacity = 0;
                int powerKs = 0;
                int torq = 0;
                int powerKw = 0;

                int powerKsTuning = 0;
                int powerKwTuning = 0;
                int torqTuning = 0;

                List<HtmlNode> values = htmlEngine.DocumentNode.Descendants("div").Where(x => x.Attributes.Count > 0 && x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("cvalue")).ToList();
                int.TryParse(values[0].InnerText.Substring(0, values[0].InnerText.IndexOf(' ')), out powerKs);
                int.TryParse(values[1].InnerText.Substring(0, values[1].InnerText.IndexOf(' ')), out powerKsTuning);
                powerKw = Convert.ToInt32(powerKs / 1.36);

                int.TryParse(values[2].InnerText.Substring(0, values[2].InnerText.IndexOf(' ')), out torq);
                int.TryParse(values[3].InnerText.Substring(0, values[3].InnerText.IndexOf(' ')), out torqTuning);
                powerKwTuning = Convert.ToInt32(powerKsTuning / 1.36);

                engineModel.Fuel = new FuelBL().GetFuel(1);
                engineModel.KsRpm = 0;
                engineModel.MaxSpeed = 0;
                engineModel.PowerKs = powerKs;
                engineModel.PowerKw = powerKw;
                engineModel.Torq = torq;
                engineModel.TorqRpm = 0;
                engineModel._isActive = true;

                engineModel.ID = new GenericRepository<Engine>().Insert(engineModel);

                EngineStage stage = new EngineStage();
                stage.EngineID = engineModel.ID;
                stage.MaxSpeed = 0;
                stage.PowerKs = powerKsTuning;
                stage.PowerKsRpm = 0;
                stage.PowerKw = powerKwTuning;
                stage.Stage = new StageBL().GetStage(1005);
                stage.Torq = torqTuning;
                stage.TorqRpm = 0;

                new GenericRepository<ModelEngine>().Insert(new ModelEngine(model, engineModel, -1));
                new GenericRepository<EngineStage>().Insert(stage);
            }
        }
	}
}