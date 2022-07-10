using Fluxor;
using FluxorState.Data;

namespace FluxorState.Store.WeatherUseCase
{
    public class GetWeatherForecastData
    {
        public record Action
        {
            [ReducerMethod]
            public static WeatherState Reducer(WeatherState state, Action action)
            {
                return new WeatherState(isLoading: true, forecasts: null);
            }
        }

        private record ResultAction(IEnumerable<WeatherForecast> Forecasts)
        {
            [ReducerMethod]
            public static WeatherState Reducer(WeatherState state, ResultAction action)
            {
                return new WeatherState(isLoading: false, forecasts: action.Forecasts);
            }
        }

        private record Effects(WeatherForecastService WeatherForecastService)
        {
            [EffectMethod]
            public async Task HandlerAsync(Action action, IDispatcher dispatcher)
            {
                var forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
                dispatcher.Dispatch(new ResultAction(forecasts));
            }
        }
    }
}
