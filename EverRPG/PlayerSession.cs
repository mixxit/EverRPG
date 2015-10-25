using System;

namespace EverRPG
{
    public class PlayerSession
    {
        public Guid guid;

        public PlayerSession(Guid guid)
        {
            this.guid = guid;
        }

        public PageState GetPageState()
        {
            PageState state = new PageState();

            return state;
        }
    }
}