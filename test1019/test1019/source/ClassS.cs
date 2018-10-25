using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using test1019.Models;

namespace test1019.source
{
    class ClassS
    {
        public List<Class1> FindOpenData()
        {
            List<Class1> result = new List<Class1>();

            string baseDir = Directory.GetCurrentDirectory();


            var xml = XElement.Load(@"C:/Users/mm930/source/repos/nkust1019/test1019/test1019/data/datagovtw_dataset_20181025.xml");


            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var nodes = xml.Descendants("node").ToList();

            result = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    Class1 item = new Class1();
                    item.id = int.Parse(getValue(node, "id"));
                    item.資料集名稱 = getValue(node, "資料集名稱");
                    item.服務分類 = getValue(node, "服務分類");
                    item.主要欄位說明 = getValue(node, "主要欄位說明");
                    return item;
                }).ToList();
            return result;
        }
        public void ImportToDb(List<Class1> openDatas)
        {
            Repository.ClassR Repository = new Repository.ClassR();
            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });
        }
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }
    }
}
