using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace EverRPG
{
    public sealed class World
    {
        private static volatile World instance;
        private static object syncRoot = new Object();
        private List<PlayerSession> playersessions = new List<PlayerSession>();
        private List<PlayerState> playerstates = new List<PlayerState>();
        private List<Location> locations  = new List<Location>();
        private List<String> locationtypes = new List<String>();

        private World()
        {
            locationtypes.Add("Cave");
            locationtypes.Add("Riverbed");
            locationtypes.Add("Plain");
            locationtypes.Add("Lakeside");
            locationtypes.Add("Forest");
            locationtypes.Add("Jungle");
            locationtypes.Add("Desert");

        }

        public static World Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new World();
                    }
                }

                return instance;
            }
        }

        internal PlayerSession GetPlayerSession(Guid sessionguid)
        {
            if (sessionguid == Guid.Empty)
            {
                sessionguid = World.Instance.GetNewPlayerSession();
            }

            return World.Instance.playersessions.Where(ps => ps.guid == sessionguid).FirstOrDefault();
        }

        public Guid GetNewPlayerSession()
        {
            Guid guid = Guid.NewGuid();

            PlayerSession session = new PlayerSession(World.Instance, guid, World.Instance.LoadPlayerState(guid));
            World.Instance.playersessions.Add(session);
            return guid;
        }

        public PlayerState GetPlayerStateFromSessionGuid(Guid sessionguid)
        {
            return World.Instance.playerstates.Where(ps => ps.GetPlayerSessionGuid() == sessionguid).FirstOrDefault();
        }

        /*
        public Location GetRandomLocation()
        {
            if (World.Instance.locations.Count < 1)
            {
                // Generate Random Location
                World.Instance.AddLocation(World.Instance.GenerateRandomLocation());
            }

        }*/

        public void AddLocation(Location location)
        {
            World.Instance.locations.Add(location);
        }

        public List<Location> GetLocations()
        {
            return World.Instance.locations;
        }

        
        public Location GetFreeLocation()
        {
            Location newlocation = null;

            // If no locations return 0,0
            if (World.Instance.GetLocations().Count == 0)
            {
                Position position = new Position(0, 0);
                newlocation = new Location(World.Instance, position, World.Instance.ChooseRandomLocationType());
                World.Instance.AddLocation(newlocation);
            } else
            {
                List<Location> tmpLocations = new List<Location>(World.Instance.GetLocations());

                foreach (Location location in tmpLocations)
                {
                    Position foundemptyposition = World.Instance.GetFreePositionNextToLocation(location);

                    if (foundemptyposition != null)
                    {
                        Position position = new Position(foundemptyposition.GetX(), foundemptyposition.GetY());
                        newlocation = new Location(World.Instance, position, World.Instance.ChooseRandomLocationType());
                        World.Instance.AddLocation(newlocation);
                        continue;
                    }
                }
            }

            return newlocation;
        }
        

        public Position GetFreePositionNextToLocation(Location fromlocation)
        {
            Position foundposition = null;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int checkx = fromlocation.GetPosition().GetX() + x;
                    int checky = fromlocation.GetPosition().GetY() + y;
                    Location location = World.Instance.GetLocations().Where(l => l.GetPosition().GetX() == checkx && l.GetPosition().GetY() == checky ).FirstOrDefault();
                    if (location == null)
                    {
                        foundposition = new Position(checkx, checky);
                    }

                    continue;
                }

                if (foundposition == null)
                {
                    continue;
                }
            }

            return foundposition;
        }

        public String ChooseRandomLocationType()
        {

            var rand = new Random();
            return World.Instance.locationtypes[rand.Next(World.Instance.locationtypes.Count)];

        }

        public Location GenerateRandomLocation()
        {
            Position position = new Position(0, 0);
            Location location = new Location(World.Instance, position, World.Instance.ChooseRandomLocationType());
            return location;
        }

        public PlayerState LoadPlayerState(Guid guid)
        {
            Location location = World.Instance.GetFreeLocation();
            PlayerState playerstate = new PlayerState(guid, location);
            World.Instance.playerstates.Add(playerstate);

            return playerstate;
        }

    }
}