using AutoMapper;

namespace Filed.API.Models
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PaymentModel, PaymentEntity>();
        }
    }
}
