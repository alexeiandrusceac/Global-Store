using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalStore.Entity
{
    public class Product
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }
        /// <summary>
        /// Denumirea produsului in limba romana
        /// </summary>
        [JsonProperty(PropertyName = "TitleRO")]
        public string TitleRO { get; set; }

        /// <summary>
        /// Denumirea produsului in limba engleza
        /// </summary>
        [JsonProperty(PropertyName = "TitleEN")]
        public string TitleEN { get; set; }
        /// <summary>
        /// Denumirea produsului in limba rusa
        /// </summary>
        [JsonProperty(PropertyName ="TitleRU")]
        public string TitleRU { get; set; }
        /// <summary>
        /// Codul de bare pentru unitatea de masura bucata
        /// </summary>
        [JsonProperty(PropertyName ="BarcodeBuc")]
        public string BarcodeBuc { get; set; }
        /// <summary>
        /// Codul de bare pentru unitatea de masura set
        /// </summary>
        [JsonProperty(PropertyName ="BarcodeSet")]
        public string BarcodeSet { get; set; }
        /// <summary>
        /// Codul de bare pentru unitatea de masura cutie
        /// </summary>
        [JsonProperty(PropertyName ="BarcodeBox")]
        public string BarcodeBox { get; set; }

        /// <summary>
        /// Pretul produsul de retail
        /// </summary>
        [JsonProperty(PropertyName ="Price")]
        public double Price { get; set; }
        /// <summary>
        /// Pretul produsului angro
        /// </summary>
        [JsonProperty(PropertyName = "PriceAngro")]
        public double PriceAngro { get; set; }
        /// <summary>
        /// Numarul de produse in stoc de partea angro
        /// </summary>
        [JsonProperty(PropertyName ="StocReal")]
        public double StocReal { get; set; }
        /// <summary>
        /// Tara produsului 
        /// </summary>
        [JsonProperty(PropertyName ="Country")]
        public string Country { get; set; }
        /// <summary>
        /// Pretul promotional pentru retail
        /// </summary>

        [JsonProperty(PropertyName ="PricePromo")] 
        public double PricePromo { get; set; }
        /// <summary>
        /// Numarul de produse in set
        /// </summary>
        [JsonProperty(PropertyName ="QtySet")]
        public double QtySet { get; set; }
        /// <summary>
        /// Numarul de produse in cutie
        /// </summary>
        [JsonProperty(PropertyName ="QtyBox")]
        public double QtyBox { get; set; }
        /// <summary>
        /// Modelul produsului
        /// </summary>
        [JsonProperty(PropertyName ="Model")]
        public string Model { get; set; }
        /// <summary>
        /// Imaginea produsului
        /// </summary>
        [JsonProperty(PropertyName ="Image")]
        public string[] Image { get; set; }
        /// <summary>
        /// Denumirea imaginii produsului
        /// </summary>
        [JsonProperty(PropertyName ="ImageTitle")]
        public string ImageTitle { get; set; }
        /// <summary>
        /// Brandul produsului
        /// </summary>
        [JsonProperty(PropertyName ="Brand")]
        public string Brand { get; set; }
        /// <summary>
        /// Descrierea produsului in limba engleza
        /// </summary>
        [JsonProperty(PropertyName ="DescriptionEN")]
        public string DescriptionEN { get; set; }
        /// <summary>
        /// Descrierea produsului in limba rusa
        /// </summary>
        [JsonProperty(PropertyName ="DescriptionRU")]
        public string DescriptionRU { get; set; }
        /// <summary>
        /// Descrierea produsului in limba romana
        /// </summary>
        [JsonProperty(PropertyName ="DescriptionRO")]
        public string DescriptionRO { get; set; }
        /// <summary>
        /// Numarul de produse in stoc pe partea retail
        /// </summary>
        [JsonProperty(PropertyName ="StocRetail")]
        public double StocRetail { get; set; }
        /// <summary>
        /// Actia unitate masura
        /// </summary>
        [JsonProperty(PropertyName ="DiscountUnit")]
        public string DiscountUnit { get; set; }
        /// <summary>
        /// Actia cantitate 
        /// </summary>
        [JsonProperty(PropertyName ="DiscountQuantity")]
        public double DiscountQuantity { get; set; }
        /// <summary>
        /// Actia procent de reducere
        /// </summary>
        [JsonProperty(PropertyName ="DiscountPercent")]
        public double DiscountPercent { get; set; }
        /// <summary>
        /// Pretul la actie
        /// </summary>
        [JsonProperty(PropertyName ="DiscountPrice")]
        public double DiscountPrice { get; set; }

        /// <summary>
        /// Unitatea de masura cu care se vinde produsul
        /// </summary>
        [JsonProperty(PropertyName ="UnitSaleBuc")]
        public int UnitSaleBuc { get; set; }
        [JsonProperty(PropertyName ="UnitSaleSet")]
        public int UnitSaleSet { get; set; }
        [JsonProperty(PropertyName ="UnitSaleBox")]
        public int UnitSaleBox { get; set; }

        /// <summary>
        /// Pret fix pentru produse retail care nu se face reducere
        /// </summary>
        public int PriceFix { get; set; }

        /// <summary>
        /// Articolul de la uzina
        /// </summary>
        public string FactoryCode { get; set; }
        /// <summary>
        /// Nr de bucati pentru Calea Iesilor 28/2
        /// </summary>
        public int StocET1 { get; set; }

        /// <summary>
        /// Nr de bucati pentru Calea Orheiului 
        /// </summary>
        public int StocCO { get; set; }
        /// <summary>
        /// Nr de bucati pentru Miorita
        /// </summary>
        public int StocM { get; set; }

        /// <summary>
        /// Codul de identitate al categoriei generale
        /// </summary>
        public int BaseCod { get; set; }

        public List<ProductDescription> descProduct { get; set; }



        public Product convertToProductFromObj(object dataProduct)
        {
            
            ID = (int)dataProduct.GetType().GetProperty("ID").GetValue(dataProduct);
            TitleRO = (string)dataProduct.GetType().GetProperty("TitleRO").GetValue(dataProduct);
            TitleRU = (string)dataProduct.GetType().GetProperty("TitleRU").GetValue(dataProduct);
            TitleEN = (string)dataProduct.GetType().GetProperty("TitleEN").GetValue(dataProduct);
            BarcodeBuc = (string)dataProduct.GetType().GetProperty("BarcodeBuc").GetValue(dataProduct);
            BarcodeBox = (string)dataProduct.GetType().GetProperty("BarcodeBox").GetValue(dataProduct);
            BarcodeSet = (string)dataProduct.GetType().GetProperty("BarcodeSet").GetValue(dataProduct);
            Price = (double)dataProduct.GetType().GetProperty("Price").GetValue(dataProduct);
            DiscountPrice = (double)dataProduct.GetType().GetProperty("DiscountPrice").GetValue(dataProduct);
            Image = (string[])dataProduct.GetType().GetProperty("Image").GetValue(dataProduct);
            PricePromo = (double)dataProduct.GetType().GetProperty("PricePromo").GetValue(dataProduct);
            QtySet = (double)dataProduct.GetType().GetProperty("QtySet").GetValue(dataProduct);
            QtyBox = (double)dataProduct.GetType().GetProperty("QtyBox").GetValue(dataProduct);
            DescriptionEN = (string)dataProduct.GetType().GetProperty("DescriptionEN").GetValue(dataProduct);
            DescriptionRO = (string)dataProduct.GetType().GetProperty("DescriptionRO").GetValue(dataProduct);
            DescriptionRU = (string)dataProduct.GetType().GetProperty("DescriptionRU").GetValue(dataProduct);
            Model = (string)dataProduct.GetType().GetProperty("Model").GetValue(dataProduct);

            foreach (ProductDescription pDesc in (List<ProductDescription>)dataProduct.GetType().GetProperty("descProduct").GetValue(dataProduct))
            {
                descProduct.Add(new ProductDescription
                {
                    Name = pDesc.Name,
                    Value = pDesc.Value,
                    ValueRO = pDesc.ValueRO,
                    ValueRU = pDesc.ValueRU,
                    ValueEN = pDesc.ValueEN
                });
                
            }
            return this;
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
