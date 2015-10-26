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

        private World() { }

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

        public Location GetRandomLocation()
        {
            if (World.Instance.locations.Count < 1)
            {
                // Generate Random Location
                World.Instance.AddLocation(World.Instance.GenerateRandomLocation());
            }

            var rand = new Random();
            return World.Instance.locations[rand.Next(World.Instance.locations.Count)];
        }

        public void AddLocation(Location location)
        {
            World.Instance.locations.Add(location);
        }

        public Location GenerateRandomLocation()
        {
            Position position = new Position(0, 0);
            Location location = new Location(World.Instance, position, "Cave");
            return location;
        }

        public PlayerState LoadPlayerState(Guid guid)
        {
            Location location = World.Instance.GetRandomLocation();
            PlayerState playerstate = new PlayerState(guid, location);
            World.Instance.playerstates.Add(playerstate);

            return playerstate;
        }

    }
}