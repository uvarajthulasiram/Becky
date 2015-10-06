using AutoMapper;

namespace Becky.Web.Helpers
{
    public class MappingService : IMappingService
    {
        public TDest Map<TSrc, TDest>(TSrc source) where TDest : class
        {
            Mapper.CreateMap<TSrc, TDest>();
            return Mapper.Map<TSrc, TDest>(source);
        }
    }
}