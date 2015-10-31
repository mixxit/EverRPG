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
        private PlayerSession GetSession()
        {
            PlayerSession session = World.Instance.GetPlayerSession(new Guid(ViewState["sessionguid"].ToString()));
            if (new Guid(ViewState["sessionguid"].ToString()) == Guid.Empty)
            {
                ViewState["sessionguid"] = session.guid.ToString();
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
            lblFooter.Text = ViewState["sessionguid"].ToString();
            lblMain.Text = pagestate.GetMain();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            OnUpdate();
        }
    }
}