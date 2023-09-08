using System.Reflection;

namespace Sat.Recruitment.Core.Generics.Mappers
{
    public static class MapperExtension
    {
        public static void MatchAndMap<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class, new()
            where TDestination : class, new()
        {
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList();

                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    var destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                    destinationProperty?.SetValue(destination, sourceProperty.GetValue(source, null), null);
                }
            }
        }
    }
}
