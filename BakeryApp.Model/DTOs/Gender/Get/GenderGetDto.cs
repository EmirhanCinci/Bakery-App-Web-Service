using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Gender.Get
{
    public class GenderGetDto : Dto<int>
    {
        public string Name { get; set; }
    }
}
