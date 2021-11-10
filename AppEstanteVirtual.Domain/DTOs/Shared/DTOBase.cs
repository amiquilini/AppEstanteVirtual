using AutoMapper;

namespace AppEstanteVirtual.Domain.DTOs.Shared
{
    public abstract class DTOBase<TSource, TDestiny>
    {
        private readonly Mapper _mapperSource;
        private readonly Mapper _mapperDestiny;

        protected DTOBase()
        {
            var mapperConfigurationSource = new MapperConfiguration(cfg =>
                cfg.CreateMap<TSource, TDestiny>()
            );

            _mapperSource = new Mapper(mapperConfigurationSource);

            var mapperConfigurationDestiny = new MapperConfiguration(cfg =>
                cfg.CreateMap<TSource, TDestiny>()
            );

            _mapperDestiny = new Mapper(mapperConfigurationDestiny);

        }
        public TDestiny ConvertToObject()
        {
            return _mapperSource.Map<TDestiny>(this);
        }

        public TSource ConvertToObjectSource()
        {
            return _mapperDestiny.Map<TSource>(this);
        }
    }
}
