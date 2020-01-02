using GlobalStore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace GlobalStore
{
  public class WebInteraction
    {
        public string BASEURL = "http://localhost:52191/GlobalStoreWebService.asmx/";
        public string GETBYBARCODE = "getProductByBarcode";
        public string GETADMIN = "getAdmin";
        
        public WebInteraction()
        { 
            
        }

        
        public bool getStatus(string password)
        {
            bool accept = false;
            byte[] data = Encoding.GetEncoding(1251).GetBytes("password=" + password);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(BASEURL + GETADMIN + "?");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = data.Length;
            httpWebRequest.Expect = "application/json";
            using (StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                accept = Boolean.Parse(result);
            }
            return accept;
        }

        public  Product getProductByBarcode(string barcode)
        {
            byte[] data = Encoding.GetEncoding(1251).GetBytes("barcode=" + barcode);
            Product product = new Product();
            HttpWebRequest httpWebRequest =  (HttpWebRequest)WebRequest.Create(BASEURL+ GETBYBARCODE + "?");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = data.Length;
            httpWebRequest.Expect = "application/json";
            
            using (StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                product = (Product)JsonConvert.DeserializeObject(result);
            }
            
            return product; 
        }

    }
}
