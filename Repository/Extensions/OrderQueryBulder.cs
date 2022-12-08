namespace IvanRealEstate.Repository.Extensions
{
    using System.Text;
    using System.Reflection;

    public static class OrderQueryBulder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var ordersParams = orderByQueryString.Trim().Split(',');
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in ordersParams)
            {
                if (string.IsNullOrEmpty(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfo
                    .FirstOrDefault(pi => pi.Name
                    .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
