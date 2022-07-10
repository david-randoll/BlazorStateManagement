using Fluxor;
using FluxorState.Data;

namespace FluxorState.Store.WeatherUseCase
{
    [FeatureState]
    public class WeatherState
    {
        public bool IsLoading { get; }
        public IEnumerable<WeatherForecast> Forecasts { get; }

        private WeatherState() { }
        public WeatherState(bool isLoading, IEnumerable<WeatherForecast> forecasts)
        {
            this.IsLoading = isLoading;
            this.Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
        }
    }
}
