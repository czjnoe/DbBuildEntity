/*
*┌──────────────────────────────────────────┐
*│  描述：XmlUtil                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 18:49:07                        
*└──────────────────────────────────────────┘
*/
using DbBuildEntity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
    public class JsonUtil
    {
        private static List<ConfigModel> list = new List<ConfigModel>();
        public JsonUtil()
        {
            Init();
        }

        public List<ConfigModel> Items
        {
            get
            {
                if(list==null)
                    list = new List<ConfigModel>();
                return list;
            }
        }

        private void Init()
        {
            string json = string.Empty;
            using (StreamReader sr = new StreamReader(Global.configStringFullPath, Encoding.UTF8))
            {
                json = sr.ReadToEnd().ToString();
            }
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConfigModel>>(json);
        }

        public void Add(ConfigModel model)
        {
            list.Add(model);
            Save();
        }

        public void Edit(ConfigModel model)
        {
            var index = list.FindIndex(f => f.Guid.Equals(model.Guid));
            if (index != -1)
            {
                list.RemoveAt(index);
                list.Add(model);
            }
            Save();
        }

        public void Delete(ConfigModel model)
        {
            var index=list.FindIndex(f => f.Guid.Equals(model.Guid));
            if(index!= -1)
            {
                list.RemoveAt(index);
            }
            Save();
        }

        private void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            if (File.Exists(Global.configStringFullPath))
            {
                File.Delete(Global.configStringFullPath);
            }
            //文件存在，文本则覆盖
            using (StreamWriter sw = new StreamWriter(Global.configStringFullPath, false, Encoding.UTF8))
            {
                sw.WriteLine(json);
            }
        }
    }
}
