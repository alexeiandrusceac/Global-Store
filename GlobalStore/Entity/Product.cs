using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalStore.Entity
{
    public class Product
    {

        public int ID { get; set; }
        public string TitleRO { get; set; }

        public string TitleEN { get; set; }

        public string TitleRU { get; set; }
        public int Barcode { get; set; }

        public double Price { get; set; }
        public double PricePromo { get; set; }
        public double QtySet { get; set; }
        public double PriceOffer { get; set; }
        public double QtyBox { get; set; }

        public byte[] Image { get; set; }
        
        public string DescriptionEN { get; set; }
        public string DescriptionRU { get; set; }
        public string DescriptionRO { get; set; }
        public double PriceAngro { get; set; }

        public string Model { get; set; }
        public string Country { get; set; }

        public Product convertToProductFromObj(object dataProduct)
        {
            return new Product
            {
                ID = (int)dataProduct.GetType().GetProperty("ID").GetValue(dataProduct),
                TitleRO = (string)dataProduct.GetType().GetProperty("TitleRO").GetValue(dataProduct),
                TitleRU = (string)dataProduct.GetType().GetProperty("TitleRU").GetValue(dataProduct),
                TitleEN = (string)dataProduct.GetType().GetProperty("TitleEN").GetValue(dataProduct),
                Barcode = (int)dataProduct.GetType().GetProperty("Barcode").GetValue(dataProduct),
                Price = (double)dataProduct.GetType().GetProperty("Price").GetValue(dataProduct),
                PriceOffer = (double)dataProduct.GetType().GetProperty("PriceOffer").GetValue(dataProduct),
                Image = (byte[])dataProduct.GetType().GetProperty("Image").GetValue(dataProduct),
                PricePromo = (double)dataProduct.GetType().GetProperty("PricePromo").GetValue(dataProduct),
                QtySet = (double)dataProduct.GetType().GetProperty("QtySet").GetValue(dataProduct),
                QtyBox = (double)dataProduct.GetType().GetProperty("QtyBox").GetValue(dataProduct),
                DescriptionEN = (string)dataProduct.GetType().GetProperty("DescriptionEN").GetValue(dataProduct),
                DescriptionRO = (string)dataProduct.GetType().GetProperty("DescriptionRO").GetValue(dataProduct),
                DescriptionRU = (string)dataProduct.GetType().GetProperty("DescriptionRU").GetValue(dataProduct),
                Model = (string)dataProduct.GetType().GetProperty("Model").GetValue(dataProduct),

            };
        }
        public string getDescription(Language lang)
        {
            switch (lang)
            {
                case Language.RO:

                    return this.DescriptionRO.ToString();
                    
                case Language.EN:
                    return this.DescriptionEN.ToString();
                    
                case Language.RU:
                    return this.DescriptionRU.ToString();
                    
                default:
                    return this.DescriptionRO.ToString();
                    
            }
        }

        public string getTitle(Language lang)
        {
            
            switch (lang)
            {
                case Language.RO:

                    return this.TitleRO.ToString(); 
                    
                case Language.EN:
                    return this.TitleEN.ToString();
                    
                case Language.RU:
                    return this.TitleRU.ToString();
                    
                default:
                    return this.TitleRO.ToString();
                    
            }
        }

    }
}
