using System;
namespace Supermarket.API
{
    internal static class ApiRoutes
    {
        internal static class Categories
        {
            public const string BaseRoute = "api/categories";

            public const string GetById = "{id:int}";

            public const string Update = "{id:int}";

            public const string Delete = "{id:int}";
        }
    }
}

