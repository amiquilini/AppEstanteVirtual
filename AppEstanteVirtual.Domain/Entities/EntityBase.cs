using AutoMapper;

namespace AppEstanteVirtual.Domain.Entities
{
    public class EntityBase<TSource, TDestiny, TOutPut>
    {
        private readonly Mapper _mapperTDestiny;
        private readonly Mapper _mapperTOutPut;

        protected EntityBase()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.CreateMap<TSource, TDestiny>()
            );

            _mapperTDestiny = new Mapper(mapperConfiguration);

            var mapperConfiguration3 = new MapperConfiguration(cfg =>
                cfg.CreateMap<TSource, TOutPut>()
            );

            _mapperTOutPut = new Mapper(mapperConfiguration3);
        }

        public TDestiny ConvertToObject() => _mapperTDestiny.Map<TDestiny>(this);

        public TOutPut ConvertToObjectOutPut() => _mapperTOutPut.Map<TOutPut>(this);
    }
}
