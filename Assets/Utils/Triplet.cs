namespace Com.Larkintuckerllc.Bounce
{
    public class Triplet
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Triplet(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        bool Equals(Triplet other)
        {
            return (other.X == X && other.Y == Y && other.Z == Z);
        }
    }
}