using Fluxor;

namespace FluxorState.Store.CounterUseCase
{
    [FeatureState]
    public record CounterState
    {
        public int ClickCount { get; init; }
    }
}