using AutoMapper;

namespace DoctorsHelper.BL.Core.Interfaces
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}