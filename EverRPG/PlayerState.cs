using System;

namespace EverRPG
{
    public class PlayerState
    {
        Location location;
        private Guid playersessionguid;

        public PlayerState(Guid guid, Location location)
        {
            this.playersessionguid = guid;
            this.location = location;
        }

        public Guid GetPlayerSessionGuid()
        {
            return this.playersessionguid;
        }


        public Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Location location)
        {
            this.location = location;
        }
    }
}