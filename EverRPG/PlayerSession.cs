using System;

namespace EverRPG
{
    public class PlayerSession
    {
        public Guid guid;
        private World world;
        private PlayerState playerstate;

        public PlayerSession(World world, Guid guid, PlayerState playerstate)
        {
            this.world = world;
            this.guid = guid;
            this.playerstate = playerstate;
        }

        public PlayerState GetPlayerState()
        {
            return this.playerstate;
        }

        public PageState GetPageState()
        {
            PageState state = new PageState(this);
            return state;
        }
    }
}