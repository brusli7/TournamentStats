using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;

namespace MirrorcareServer.Models.Responses
{
    public class ItemHttpResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }

        public ItemHttpResponse(IEnumerable<T> items, HttpStatusCode code)
        {
            Items = items;
            ResponseStatusCode = code;

        }

    }

    public class SingleItemHttpResponse<T>
    {
        public T Item { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }

        public SingleItemHttpResponse(T item, HttpStatusCode code)
        {
            Item = item;
            ResponseStatusCode = code;

        }

    }
}