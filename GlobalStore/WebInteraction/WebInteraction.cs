using GlobalStore.Entity;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace GlobalStore
{
  public class WebInteraction
    {
        public string BASEURL = "http://localhost:63434/GlobalStoreWebService.asmx/";
        public string GETBYBARCODE = "getProductByBarcode";
        public string GETADMIN = "getAdmin";
        public string GETMESSAGE = "getMsg";
       
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

        public Product getProductByBarcode(string barcode)
        {
              byte[] data = Encoding.GetEncoding(1251).GetBytes("barcode=" + barcode);
               Product product = new Product();
               HttpWebRequest httpWebRequest =  (HttpWebRequest)WebRequest.Create(BASEURL +   GETBYBARCODE+ "?");
               httpWebRequest.Method = "POST";
             

               httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
               httpWebRequest.ContentLength = data.Length;
               httpWebRequest.Accept = "application/x-www-form-urlencoded";
                Stream newStream = httpWebRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();


               var httpResp = (HttpWebResponse)httpWebRequest.GetResponse();
               using (StreamReader streamReader = new StreamReader(httpResp.GetResponseStream()))
               {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(streamReader.ReadToEnd());

               }

              
            
        }
        

    }
}
