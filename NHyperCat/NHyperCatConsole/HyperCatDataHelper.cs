using NHyperCat;

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
    public static class HyperCatDataHelper
    {
        public static CatalogueMetaDataCollection GetCatalogueMetaDataCollection()
        {
            return new CatalogueMetaDataCollection
            {
                new CatalogueMetaData
                {
                    val = "application/vnd.hypercat.catalogue+json",
                    rel = "urn:X-hypercat:rels:isContentType"
                },
                new CatalogueMetaData
                {
                    val =  "Hypercat Reference - City Energy Data",
                    rel =  "urn:X-hypercat:rels:hasDescription:en"
                },
                new CatalogueMetaData
                {
                    val = "urn:X-hypercat:search:simple",
                    rel = "urn:X-hypercat:rels:supportsSearch"
                }
            };
        }

        public static ItemMetaDataCollection GetItemMetaDataCollectionLondon()
        {
            return new ItemMetaDataCollection
            {
                new ItemMetaData {
                    val = "London",
                    rel = "urn:X-hypercat:rels:hasDescription:en"
                },
                new ItemMetaData {
                    val = "51.5072",
                    rel = "http://www.w3.org/2003/01/geo/wgs84_pos#lat"
                },
                new ItemMetaData {
                    val = "0.1275",
                    rel = "http://www.w3.org/2003/01/geo/wgs84_pos#long"
                },
                 new ItemMetaData {
                    val = "2010-03-01T13:00:00Z",
                    rel = "lastUpdated"
                },
                 new ItemMetaData {
                    val = "81735",
                    rel = "uniqueId"
                }
            };
        }

        public static ItemMetaDataCollection GetMetaDataCollectionSuva()
        {
            return new ItemMetaDataCollection
            {
                 new ItemMetaData {
                    val = "Suva",
                    rel = "urn:X-hypercat:rels:hasDescription:en"
                },
                  new ItemMetaData {
                    val = "-18.1416",
                    rel = "http://www.w3.org/2003/01/geo/wgs84_pos#lat"
                },
                  new ItemMetaData {
                    val = "178.4419",
                    rel = "http://www.w3.org/2003/01/geo/wgs84_pos#long"
                },
                  new ItemMetaData {
                    val = "2015-01-09T13:00:00Z",
                    rel = "lastUpdated"
                },
                  new ItemMetaData {
                    val = "87230",
                    rel = "uniqueId"
                }
            };
        }
    }
}
