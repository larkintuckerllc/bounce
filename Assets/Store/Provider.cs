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
            MZ_POSITION_X_SET,
            MZ_POSITION_Z_SET,
            MZ_SCALE_X_SET,
            MZ_SCALE_Z_SET,
            TOUCH_X_SET,
            TOUCH_Y_SET,
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
            int nextMZPositionX = MZPositionX.Reducer(state.MZPositionX, action);
            if (nextMZPositionX != state.MZPositionX) { hasChanged = true; }
            int nextMZPositionZ = MZPositionZ.Reducer(state.MZPositionZ, action);
            if (nextMZPositionZ != state.MZPositionZ) { hasChanged = true; }
            int nextMZScaleX = MZScaleX.Reducer(state.MZScaleX, action);
            if (nextMZScaleX != state.MZScaleX) { hasChanged = true; }
            int nextMZScaleZ = MZScaleZ.Reducer(state.MZScaleZ, action);
            if (nextMZScaleZ != state.MZScaleZ) { hasChanged = true; }
            int nextTouchX = TouchX.Reducer(state.TouchX, action);
            if (nextTouchX != state.TouchX) { hasChanged = true; }
            int nextTouchY = TouchY.Reducer(state.TouchY, action);
            if (nextTouchY != state.TouchY) { hasChanged = true; }
            return hasChanged ? new State(
                nextMode,
                nextMZPositionX,
                nextMZPositionZ,
                nextMZScaleX,
                nextMZScaleZ,
                nextTouchX,
                nextTouchY
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
                MZPositionX.InitialState,
                MZPositionZ.InitialState,
                MZScaleX.InitialState,
                MZScaleZ.InitialState,
                TouchX.InitialState,
                TouchY.InitialState
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