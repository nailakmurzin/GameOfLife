using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class StateManager<T>
    {
        public T[] Current = { };

        public bool IsEmplty => states.Count == 0;

        private Stack<T[]> states = new Stack<T[]>();


        /// <summary>
        /// Add new State on history and check changes
        /// </summary>
        /// <param name="newState">False if no change</param>
        /// <returns></returns>
        public bool AddState(T[] newState)
        {
            if (IsEmplty || !Current.SetEqual(newState))
            {
                states.Push(Current);
                Current = newState;
                return true;
            }
            return false;
        }

        public T[] GetPreviewState()
        {
            if (states.Count > 0)
            {
                Current = states.Pop();
            }
            return Current;
        }
    }
}
