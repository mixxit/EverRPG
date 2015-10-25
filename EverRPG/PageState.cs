using System;
using System.Web.UI.WebControls;

namespace EverRPG
{
    public class PageState
    {
        internal String GetHeader()
        {
            return "EverRPG";
        }

        internal String GetFooter()
        {
            return "";
        }

        internal String GetMain()
        {
            return "You are in a room";
        }
    }
}