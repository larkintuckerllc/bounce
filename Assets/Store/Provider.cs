using System;
using UnityEngine;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public static class Provider
    {
        // UPDATE FOR EACH DUCK
        public enum Actions
        {
            __INIT,
            MODE_SET,
            PLACEMENT_VALID_SET,
            THUNK,
        }

        private static State state;

        public static State GetState()
        {
            return state;
        }

        public static State Reducer(State state, Action action)
        {
            // UPDATE FOR EACH DUCK
            bool hasChanged = false;
            Mode.ModeEnum nextMode = Mode.Reducer(state.Mode, action);
            if (nextMode != state.Mode) { hasChanged = true; }
            bool nextPlacementValid = PlacementValid.Reducer(state.PlacementValid, action);
            if (nextPlacementValid!= state.PlacementValid) { hasChanged = true; }
            return hasChanged ? new State(
                nextMode,
                nextPlacementValid
            ) : state;
        }

        public static Action Logger(Action action)
        {
            Debug.Log(action.Type);
            return action;
        }

        public static Boolean FilterThunk(Action action)
        {
            return action.Type != Actions.THUNK;
        }

        public static State ExtractState(State state)
        {
            Provider.state = state;
            return state;
        }

        static ISubject<Action> StoreDispatch;

        public static void Dispatch(Action action)
        {
            StoreDispatch.OnNext(action);
        }

        public static BehaviorSubject<State> Store { get; private set; }

        public static void Initialize()
        {
            StoreDispatch = new Subject<Action>();

            // UPDATE FOR EACH DUCK
            State initialState = new State(
                Mode.InitialState,
                PlacementValid.InitialState
            );

            Store = new BehaviorSubject<State>(initialState);
            StoreDispatch
                .Where<Action>(FilterThunk)
                .Select(Logger)
                .Scan(initialState, Reducer)
                .Select(ExtractState)
                .Subscribe(Store);
            Dispatch(new Action(Actions.__INIT));
        }
    }
}