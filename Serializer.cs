using System.Text;

namespace Homework5;

internal static class Serializer
{
    public static string Serialize(object obj)
    {
        return obj.GetType().GetProperties()
            .Select(propInfo => $"{propInfo.Name}:{propInfo.GetValue(obj)}")
            .Aggregate(new StringBuilder(), (acc, elem) => {
                if (acc.Length != 0)
                    acc.Append(',');
                acc.Append(elem);

                return acc;
            })
            .ToString();
    }
}
