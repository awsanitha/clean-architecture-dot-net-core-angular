using Mapster;
using Core.Entities;
using LinkitAir.ViewModels;
using System.Collections.Generic;

namespace LinkitAir.ViewModelHelpers
{
    public class FlightViewModelAdapterHelper
    {
        public List<FlightViewModel> customAdapt(IEnumerable<FlightInstance> flightInstances)
        {
            List<FlightViewModel> flightInstanceViewModels = new List<FlightViewModel>();
            var config = new TypeAdapterConfig();
            foreach(var flightInstance in flightInstances)
            {
                config.NewConfig<FlightInstance, FlightViewModel>()
               .Map(
                   dest => dest.OriginAirportName, src => src.FlightRoute.Origin.Name
                 ).Map(
                   dest => dest.DestinationAirportName, src => src.FlightRoute.Destination.Name
                 ).Map(
                   dest => dest.OriginCityName, src => src.FlightRoute.Origin.City.Name
                 ).Map(
                   dest => dest.DestinationCityName, src => src.FlightRoute.Destination.City.Name
                 ).Map(
                   dest => dest.FlightInstanceId, src => src.Id
                 ).Map(
                   dest => dest.FlightCode, src => src.Code
                 ).Map(
                   dest => dest.DepartureTime, src => src.DepartureTime.ToString("dddd, dd MMMM yyyy HH:mm")
                 ).Map(
                   dest => dest.ArrivalTime, src => src.ArrivalTime.ToString("dddd, dd MMMM yyyy HH:mm")
                 );
                flightInstanceViewModels.Add(flightInstance.Adapt<FlightViewModel>(config));
            }
            
            return flightInstanceViewModels;
        }

        public FlightViewModel customAdapt(FlightInstance flightInstance)
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<FlightInstance, FlightViewModel>()
                .Map(
                    dest => dest.OriginAirportName, src => src.FlightRoute.Origin.Name
                  ).Map(
                    dest => dest.DestinationAirportName, src => src.FlightRoute.Destination.Name
                  ).Map(
                    dest => dest.OriginCityName, src => src.FlightRoute.Origin.City.Name
                  ).Map(
                    dest => dest.DestinationCityName, src => src.FlightRoute.Destination.City.Name
                  ).Map(
                    dest => dest.FlightInstanceId, src => src.Id
                  ).Map(
                    dest => dest.FlightCode, src => src.Code
                  );
            var flightInstanceViewModel = flightInstance.Adapt<FlightViewModel>(config);
            return flightInstanceViewModel;
        }
    }
}
