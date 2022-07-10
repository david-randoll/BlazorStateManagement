using Fluxor;

namespace FluxorState.Store.CounterUseCase
{
    public class IncrementCounterAction
    {
        [ReducerMethod]
        public static CounterState Reducer(CounterState state, IncrementCounterAction action)
        {
            return state with
            {
                ClickCount = state.ClickCount + 1
            };
        }
    }
}