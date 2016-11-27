using System;
using System.Text;
using Newtonsoft.Json;

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

namespace NHyperCat.JsonConvertors
{
    public class CatalogueDataJsonConvertor : JsonConverter
    {
        public CatalogueDataJsonConvertor()
        {
            Formatting = Formatting.None;
        }

        public Formatting Formatting { get; set; }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CatalogueDataJsonConvertor);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var catalogue = new Catalogue();
            serializer.Populate(reader, catalogue);
            return catalogue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.Formatting = Formatting;
            var catalogue = value as Catalogue;

            if (catalogue != null)
            {
                var catalogueStringBuilder = new StringBuilder();
                var itemMetaDataConvetor = new ItemMetaDataJsonConverter();
                var itemJsonConvertor = new ItemJsonConverter();

                var catalogueMetaDataJson = JsonConvert.SerializeObject(
                    catalogue.CatalogueMetaData, Formatting,
                    itemMetaDataConvetor);

                catalogueStringBuilder.Append("{");

                catalogueStringBuilder.Append($"{"\"catalogue-metadata\""} " +
                    $":[{catalogueMetaDataJson}]");

                string itemsDataJson = "";
                if (catalogue.Items.Count > 0)
                {
                    catalogueStringBuilder.Append(",");
                    itemsDataJson = JsonConvert.SerializeObject(catalogue.Items,
                        Formatting, itemJsonConvertor);
                    catalogueStringBuilder.Append($"{"\"items\""} " +
                                                  $":[{itemsDataJson}]");
                }
                else
                {
                    catalogueStringBuilder.Append($"{"\"items\""} " +
                        $":[{itemsDataJson}]");
                }

                catalogueStringBuilder.Append("}");

                writer.WriteRaw(catalogueStringBuilder.ToString());
            }
        }
    }
}