using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPath
    {
        public static class Catalog
        {
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}Eventbrands";
            }
            public static string GetAllPrices(string baseUri)
            {
                return $"{baseUri}Eventbrands";
            }
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}Eventtypes";
            }


            public static string GetAllEventItems(string baseUri,
                int page, int take, int? location, int? price, int? type)
            {
                var filterQs = string.Empty;

                if (location.HasValue || price.HasValue || type.HasValue)
                {
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                    var priceQs = (price.HasValue) ? price.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/location/{locationQs}/price/{priceQs}/type/{typeQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";

            }

        }
    }
}

