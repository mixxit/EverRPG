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
                sessionguid = GetNewPlayerSession();
            }

            return playersessions.Where(ps => ps.guid == sessionguid).FirstOrDefault();
        }

        public Guid GetNewPlayerSession()
        {
            Guid guid = Guid.NewGuid();
            PlayerSession session = new PlayerSession(guid);
            playersessions.Add(session);
            return guid;
        }

    }
}