using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Interview.Models;
using Newtonsoft.Json;

namespace Interview.Repository
{
    public class DataRepository : IDataRepository
    {
        private string _dataFilePath;
        private List<DataModel> _data;

        public DataRepository()
        {
            this._dataFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "data.json");

            string fileContent = File.ReadAllText(_dataFilePath);
            _data = JsonConvert.DeserializeObject<List<DataModel>>(fileContent);
        }

        public DataModel Get(Guid id)
        {
            DataModel dataModel = null;
            foreach (var d in _data)
            {
                if (d.Id == id)
                {
                    dataModel = d;
                    break;
                }
            }

            return dataModel;
        }

        public void Update(DataModel model)
        {
            var modelToUpdate = Get(model.Id);
            modelToUpdate = model;
            string content = JsonConvert.SerializeObject(
                _data, Formatting.Indented);
            File.WriteAllText(_dataFilePath, content);
        }

        public void Delete(Guid id)
        {
            foreach (var dm in _data)
            {
                if (dm.Id == id)
                {
                    _data.Remove(dm);
                    break;
                }
            }
            string content = JsonConvert.SerializeObject(
                _data, Formatting.Indented);
            File.WriteAllText(_dataFilePath, content);
        }

        public void Add(DataModel model)
        {
            _data.Add(model);
            string content = JsonConvert.SerializeObject(
                _data, Formatting.Indented);
        }
    }
}