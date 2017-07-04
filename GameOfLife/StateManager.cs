using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class StateManager<T>
    {
        private T[] BeginState { get; }

        public T[] CurrentState { get; private set; }

        private Stack<T[]> states = new Stack<T[]>();

        public StateManager(T[] beginState)
        {
            BeginState = beginState;
            CurrentState = beginState.ToArray();
        }

        public bool AddState(T[] newState)
        {
            var isChanged = newState.Except(CurrentState).Any();
            if (isChanged)
            {
                states.Push(CurrentState);
                CurrentState = newState.ToArray();
            }
            return isChanged;
        }

        public T[] GetPreviewState()
        {
            if (states.Count > 0)
            {
                CurrentState = states.Pop();
                return CurrentState;
            }
            return null;
        }
    }
}
