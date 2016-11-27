using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace NHyperCat
{
    public class HyperCatParser
    {
        private Catalogue Catalogue { get; set; }

        public void Parse(string hyperCatJson)
        {
            Catalogue = JsonConvert.DeserializeObject<Catalogue>(hyperCatJson);
        }

        public Catalogue GetCatalogue()
        {
            return Catalogue;
        }

        public List<CatalogueMetaData> GetCatalogueMetaData()
        {
            return Catalogue.CatalogueMetaData;
        }

        public List<Item> GetAllItems()
        {
            return Catalogue.Items;
        } 

        public List<Item> GetItemByHref(string href)
        {
            return (from item in Catalogue.Items
                    where item.Href.Equals(href)
                    select item).ToList();
        }
    }
}
