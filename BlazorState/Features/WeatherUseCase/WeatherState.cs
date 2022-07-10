using BlazorState.Data;

namespace BlazorState.Features.WeatherUseCase;

public partial class WeatherState : State<WeatherState>
{
    public bool IsLoading { get; private set; }
    public IEnumerable<WeatherForecast> Forecasts { get; private set; }

    public override void Initialize()
    {
        Forecasts = new List<WeatherForecast>();
        IsLoading = false;
    }
}