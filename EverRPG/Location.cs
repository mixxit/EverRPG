namespace EverRPG
{
    public class Location
    {
        private World world;
        private string name;
        private Position position;

        public Location(World world, Position position, string name)
        {
            this.world = world;
            this.position = position;
            this.name = name;
            
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPosition(Position position)
        {
            this.position = position;
        }

        public Position GetPosition()
        {
            return this.position;
        }

        
    }
}