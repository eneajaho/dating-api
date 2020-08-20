using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using DatingAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DatingAPI.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems,
            int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static int CalculateAge(this DateTime date)
        {
            var age = DateTime.Today.Year - date.Year;

            if (date.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }

        public static string GetUserIpAddress(this HttpContext context)
        {
            // https://stackoverflow.com/a/61479085/7220620
            
            var ipAddress = context.Connection.RemoteIpAddress;

            if (ipAddress == null)
                return "";

            // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
            // This usually only happens when the browser is on the same machine as the server.
            if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                ipAddress = Dns.GetHostEntry(ipAddress).AddressList
                    .First(x => x.AddressFamily == AddressFamily.InterNetwork);

            return ipAddress.ToString();
        }
    }
}