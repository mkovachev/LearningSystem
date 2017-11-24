using AutoMapper;

namespace LearningSystem.Web.Infrastructure.Mapping
{
    public interface ICustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
