namespace Com.Larkintuckerllc.Bounce
{
    public class Placement : Singleton<Placement>
    {
        public static Triplet InitialState = new Triplet(0, 0, 0);

        public static Triplet Reducer(Triplet state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.PLACEMENT_SET:
                    return action.PayloadTriplet;
                default:
                    return state;
            }
        }

        public static Triplet PlacementGet(State state)
        {
            return state.Placement;
        }

        protected Placement() { }

        public Action PlacementSet(Triplet placement)
        {
            return new Action(Provider.Actions.PLACEMENT_SET, placement);
        }
    }
}
