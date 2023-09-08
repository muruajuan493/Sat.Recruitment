namespace Sat.Recruitment.Core.Generics.Mappers
{
    public class BaseMapper<TDto, TEntity>
            where TDto : class, new()
            where TEntity : class, new()
    {
        public static TEntity DtoToEntity(TDto model)
        {
            TEntity entity = new();

            model.MatchAndMap(entity);

            return entity;
        }
        public static IEnumerable<TEntity> DtoToEntity(IEnumerable<TDto> models)
        {
            var data = models.Select(d => DtoToEntity(d));

            return data;
        }

        public static TDto EntityToDto(TEntity entity)
        {
            TDto model = new();

            entity.MatchAndMap(model);

            return model;
        }
        public static IEnumerable<TDto> EntityToDto(IEnumerable<TEntity> entities)
        {
            return entities.Select(e => EntityToDto(e));
        }
    }
}
