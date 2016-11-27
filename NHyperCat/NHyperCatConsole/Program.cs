using System;
using Newtonsoft.Json;

using NHyperCat;
using NHyperCat.JsonConvertors;

/* LICENCE INFORMATION 
* Copyright (c) 2016 Ranjan Dailata.
*  
* Enables easy creation and parsing of valid Hypercat catalogues
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

namespace NHyperCatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalogMetaDataCollection = HyperCatDataHelper.GetCatalogueMetaDataCollection();
            var itemMetaDataCollectionLondon = HyperCatDataHelper.GetItemMetaDataCollectionLondon();
            var itemMetaDataCollectionSuva = HyperCatDataHelper.GetMetaDataCollectionSuva();

            var items = new ItemCollection
            {
                new Item
                {
                    ItemMetadata = itemMetaDataCollectionLondon,
                    Href = "/london"
                },
                new Item
                {
                    ItemMetadata = itemMetaDataCollectionSuva,
                    Href = "/suva"
                }
            };
            
            var catelouge = new Catalogue
            {
                CatalogueMetaData = catalogMetaDataCollection,
                Items = items
            };

            var catalougeDataConvetor = new CatalogueDataJsonConvertor {Formatting = Formatting.Indented};

            // Serialize the Catalouge object to HyperCat Catelouge
            var hyperCatalougeJsonData = JsonConvert.SerializeObject(catelouge, 
                Formatting.Indented, catalougeDataConvetor);

            Console.WriteLine(hyperCatalougeJsonData);

            // Using HyperCat Builder
            var hyperCatBuilder = new HyperCatBuilder();
            hyperCatBuilder.AddCatalogueMetaData(catalogMetaDataCollection);
            hyperCatBuilder.AddCatalogueItem(items);
            hyperCatalougeJsonData = hyperCatBuilder.ToString();
            Console.WriteLine(hyperCatalougeJsonData);

            // Deserialize the Hypercat Catalouge to strongly typed object
            var hyperCatalouge = JsonConvert.DeserializeObject<Catalogue>(hyperCatalougeJsonData);

            Console.ReadLine();
        }
    }
}
