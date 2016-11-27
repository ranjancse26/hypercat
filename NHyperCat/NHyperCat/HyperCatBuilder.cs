using Newtonsoft.Json;
using NHyperCat.JsonConvertors;
using System.Collections.Generic;

namespace NHyperCat
{
    public class HyperCatBuilder
    {
        public HyperCatBuilder()
        {
            Formatting = Formatting.None;
            Catalogue = new Catalogue
            {
                Items = new ItemCollection(),
                CatalogueMetaData = new CatalogueMetaDataCollection()
            };
        }

        public HyperCatBuilder(string value)
        {
            var metaDataCollection = new CatalogueMetaDataCollection
            {
                new CatalogueMetaData
                {
                    rel = "urn:X-hypercat:rels:isContentType",
                    val = "application/vnd.hypercat.catalogue+json"
                },
                new CatalogueMetaData
                {
                    rel = "urn:X-hypercat:rels:hasDescription:en",
                    val = value
                }
            };
            Catalogue = new Catalogue
            {
                Items = new ItemCollection(),
                CatalogueMetaData = metaDataCollection
            };
        }

        public HyperCatBuilder(List<CatalogueMetaData> catalogueMetaDataCollection,
                               ItemCollection items,
                               Formatting formatting)
        {
            Formatting = formatting;
            Catalogue = new Catalogue
            {
                Items = items,
                CatalogueMetaData = catalogueMetaDataCollection
            };
        }

        public HyperCatBuilder(List<CatalogueMetaData> catalogueMetaDataCollection,
                               ItemCollection items)
        {
            Formatting = Formatting.None;
            Catalogue = new Catalogue
            {
                Items = items,
                CatalogueMetaData = catalogueMetaDataCollection
            };
        }

        Catalogue Catalogue { get; }

        public Formatting Formatting { get; set; }

        public void AddCatalogueMetaData(CatalogueMetaData catalogueMetaData)
        {
            Catalogue.CatalogueMetaData.Add(catalogueMetaData);
        }

        public void AddCatalogueItem(Item item)
        {
            Catalogue.Items.Add(item);
        }

        public void AddCatalogueItem(string href, List<ItemMetaData> metaDataCollection)
        {
            Catalogue.Items.Add(new Item
            {
                Href = href,
                ItemMetadata = metaDataCollection
            });
        }
        
        // Collection methods

        public void AddCatalogueMetaData(List<CatalogueMetaData> catalogueMetaDataCollection)
        {
            Catalogue.CatalogueMetaData.AddRange(catalogueMetaDataCollection);
        }
        
        public void AddCatalogueItem(List<Item> items)
        {
            Catalogue.Items.AddRange(items);
        }

        // Serialize the Catalouge object to HyperCat Catelouge
        public override string ToString()
        {
            var catalougeDataConvetor = new CatalogueDataJsonConvertor
            {
                Formatting = Formatting
            };

            return JsonConvert.SerializeObject(Catalogue,
                Formatting, catalougeDataConvetor);
        }
    }
}
