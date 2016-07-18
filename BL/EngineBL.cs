using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using BE;
using System.Data;
using System.Web.Security;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;

namespace BL
{
	public class EngineBL
	{
		public List<BE.Engine> GetAll()
		{
            return new EngineRepository().GetAll();
		}

		public int Save(BE.Engine engine)
		{
			EngineRepository repository = new EngineRepository();
			if(engine.ID > 0)
				return repository.Update(engine);
			else
				return repository.Insert(engine);
		}

		public bool Delete(BE.Engine engine)
		{
            return new EngineRepository().Delete(engine);
		}

		public BE.Engine GetEngine(int id)
		{
            return new EngineRepository().GetByID(id);
		}

        public DataTable GetByModelUrl(string modelUrl, string manufacturerUrl)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("modelUrl", modelUrl));
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));
                
            return new EngineRepository().GetDataTable("engine", "getByModelUrl", parameters);
        }

        public Engine GetEngine(string url, string modelUrl, string manufacturerUrl)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("url", url));
            parameters.Add(new QueryParameter("modelUrl", modelUrl));
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));

            List<Engine> engines = new EngineRepository().GetByParameter("getByUrl", parameters, false);
            return engines.Count > 0 ? engines[0] : null;
        }

        public DataTable GetEngineData(Engine engine, int stage)
        {
            
            //Engine engine = GetEngine(url);
            DataTable data = new DataTable();
            data.Columns.Add("parameter", typeof(string));
            data.Columns.Add("series", typeof(string));
            data.Columns.Add("chiptuning", typeof(string));
            data.Columns.Add("difference", typeof(string));

            if (engine != null && engine.Stages != null && engine.Stages.Count > 0 && engine.Stages.Count > stage)
            {
                DataRow newRow = data.NewRow();
                newRow["parameter"] = "Snaga";
                newRow["series"] = engine.PowerKw.ToString() + "kW/" + engine.PowerKs.ToString() + "ks";
                newRow["chiptuning"] = engine.Stages[stage].PowerKw.ToString() + "kW/" + engine.Stages[stage].PowerKs.ToString() + "ks";
                newRow["difference"] = (engine.Stages[stage].PowerKw - engine.PowerKw).ToString() + "kW/" + (engine.Stages[stage].PowerKs - engine.PowerKs).ToString() + "ks";
                data.Rows.Add(newRow);

                newRow = data.NewRow();
                newRow["parameter"] = "Obrtni moment";
                newRow["series"] = engine.Torq.ToString() + "Nm";
                newRow["chiptuning"] = engine.Stages[stage].Torq.ToString() + "Nm";
                newRow["difference"] = (engine.Stages[stage].Torq - engine.Torq).ToString() + "Nm";
                data.Rows.Add(newRow);

                //newRow = data.NewRow();
                //newRow["parameter"] = "Maksimalna brzina";
                //newRow["series"] = engine.MaxSpeed.ToString() + "km/h";
                //newRow["chiptuning"] = engine.Stages[0].MaxSpeed.ToString() + "km/h";
                //newRow["difference"] = (engine.Stages[0].MaxSpeed - engine.MaxSpeed).ToString() + "km/h";
                //data.Rows.Add(newRow);
            }

            return data;
        }

        public List<Engine> GetByModelID(int modelID, bool addSelect)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("modelID", modelID));

            return (addSelect) ? getEmpty(new EngineRepository().GetByParameter("getByModelID", parameters)) : new EngineRepository().GetByParameter("getByModelID", parameters);
        }

        private List<Engine> getEmpty(List<Engine> engines)
        {
            engines.Insert(0, new Engine("Odaberi", 0, 0, 0, 0, 0, null, -1, null, "Odaberi"));
            return engines;
        }

        public List<Engine> GetListByModelUrl(string modelUrl, bool addSelect, string manufacturerUrl)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("modelUrl", modelUrl));
            parameters.Add(new QueryParameter("manufacturerUrl", manufacturerUrl));
            return (addSelect) ? getEmpty(new EngineRepository().GetByParameter("getByModelUrl", parameters)) : new EngineRepository().GetByParameter("getByModelUrl", parameters);
        }

        public async void LoadData(string url, int modelID)
        {
            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync("http://www.smchiptuning.com/auto/" + url);
            string source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(source);

            List<HtmlNode> engines = html.DocumentNode.SelectNodes("//tr[@onclick]").ToList();

            foreach(HtmlNode engineNode in engines)
            {
                string engineUrl = engineNode.ChildNodes[5].FirstChild.Attributes["href"].Value;
                string name = engineNode.ChildNodes[5].InnerText;
                string ks = engineNode.ChildNodes[7].InnerText;
                string kw = engineNode.ChildNodes[9].InnerText;
                Engine engine = new Engine();
                StringBuilder capacity = new StringBuilder();
                int i = 0;
                while (name[i] != ' ' && i < name.Length - 1)
                    capacity.Append(name[i++]);
                double capacityOut = 0;
                double.TryParse(capacity.ToString(), out capacityOut);
                engine.Capacity = capacityOut;
                engine.PowerKs = int.Parse(ks);
                engine.PowerKw = int.Parse(kw);
                engine.Url = engineUrl.Substring(engineUrl.LastIndexOf("/") + 1);
                engine.Fuel = new Fuel(string.Empty, 1);
                engine.MaxSpeed = 0;
                engine.Torq = 0;
                engine.Name = name;
                engine.TorqRpm = 0;
                engine.KsRpm = 0;
                engine.ID = new GenericRepository<Engine>().Insert(engine);
                
                
            }
        }
    }
}