using JunkWebApi.Dto;
using JunkWebApi.Models;
namespace JunkWebApi.Mappings.Components
{
    public static class ComponentMapper
    {
       public static Component ToComponent(ComponentDto componentDto) 
       {
            return new Component
            {
                Name=componentDto.Name,
                Status=componentDto.Status,
                Quantity=componentDto.Quantity
            };
       }
    }
}
