using Mapster;
using MapsterSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsterSample
{
    internal class MapsterConfiguration
    {
        internal static void ConfigureMapster()
        {
            TypeAdapterConfig<Customer, CustomerDto>.NewConfig()
                .Map(dest => dest.Name, src => src.FirstName + " " + src.LastName);

            TypeAdapterConfig<CustomerDto, Customer>.NewConfig()
                .Map(dest => dest.FirstName, src => src.Name.Split(" ", StringSplitOptions.None)[0])
                .Map(dest => dest.LastName, src => src.Name.Split(" ", StringSplitOptions.None)[1]);
        }
    }
}
