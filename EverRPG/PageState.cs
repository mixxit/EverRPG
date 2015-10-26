using System;
using System.Web.UI.WebControls;

namespace EverRPG
{
    public class PageState
    {
        PlayerSession playersession;

        public PageState(PlayerSession playersession)
        {
            this.playersession = playersession;
        }

        internal String GetHeader()
        {
            return "Alpha";
        }

        internal String GetFooter()
        {
            return "";
        }

        internal String GetMain()
        {
            String frametext = "";

            frametext = "You are in " + playersession.GetPlayerState().GetLocation().GetName();

            return frametext;
        }
    }
}