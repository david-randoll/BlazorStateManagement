using BlazorState;
using MediatR;

namespace BlazorState.Features.CounterUseCase;

public partial class CounterState
{
    public class IncrementCountAction : IAction
    {
        public int Amount { get; set; }
    }
    public class IncrementCountHandler : ActionHandler<IncrementCountAction>
    {
        public IncrementCountHandler(IStore aStore) : base(aStore) { }

        CounterState CounterState => Store.GetState<CounterState>();

        public override Task<Unit> Handle(IncrementCountAction aIncrementCountAction, CancellationToken aCancellationToken)
        {
            CounterState.Count = CounterState.Count + aIncrementCountAction.Amount;
            return Unit.Task;
        }
    }
}