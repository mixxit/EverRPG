namespace EverRPG
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private int x;
        private int y;

        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetX()
        {
            return this.x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public int GetY()
        {
            return this.y;
        }
    }
}