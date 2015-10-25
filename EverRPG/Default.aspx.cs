using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EverRPG
{
    public partial class Default : System.Web.UI.Page
    {
        private Guid sessionguid;

        private PlayerSession GetSession()
        {
            PlayerSession session = World.Instance.GetPlayerSession(sessionguid);
            if (sessionguid == Guid.Empty)
            {
                sessionguid = session.guid;
            }
            return session;
        }

        private void OnUpdate()
        {
            UpdatePage(GetSession().GetPageState());
        }

        private void UpdatePage(PageState pagestate)
        {
            lblHeader.Text = pagestate.GetHeader();
            lblFooter.Text = pagestate.GetFooter();
            lblMain.Text = pagestate.GetMain();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            OnUpdate();
        }
    }
}