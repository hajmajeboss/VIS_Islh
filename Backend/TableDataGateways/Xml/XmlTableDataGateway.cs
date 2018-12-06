using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Backend.Models;

namespace Backend.TableDataGateways.Xml
{
    public abstract class XmlTableDataGateway : ITableDataGateway, IDisposable
    {
        protected XmlDocument Document { get; set; }
        protected const string DOCUMENT_PATH = "";

        public abstract bool Delete(Model obj);
        public abstract bool Insert(Model obj);
        public abstract List<Model> SelectAll();
        public abstract Model SelectOne(string id);
        public abstract bool Update(Model obj);


        protected XmlTableDataGateway()
        {
            Document = new XmlDocument();         
            Document.Load(DOCUMENT_PATH);
        }

        public void Dispose()
        {
            Document.Save(DOCUMENT_PATH);
        }
    }
}
