using BlazorState.Data;
using MediatR;

namespace BlazorState.Features.WeatherUseCase;

public partial class WeatherState
{
    public class GetWeatherForecastDataAction : IAction
    {

    }

    public class GetWeatherForecastDataHandler : ActionHandler<GetWeatherForecastDataAction>
    {
        private readonly WeatherForecastService _weatherForecastService;

        public GetWeatherForecastDataHandler(IStore aStore, WeatherForecastService weatherForecastService)
            : base(aStore)
        {
            _weatherForecastService = weatherForecastService;
        }

        WeatherState WeatherState => Store.GetState<WeatherState>();

        public override async Task<Unit> Handle(GetWeatherForecastDataAction action, CancellationToken aCancellationToken)
        {
            WeatherState.IsLoading = true;
            WeatherState.Forecasts = new List<WeatherForecast>();

            var forecasts = await _weatherForecastService.GetForecastAsync(DateTime.Now);
            WeatherState.Forecasts = forecasts;
            WeatherState.IsLoading = false;

            return Unit.Value;
        }
    }
}