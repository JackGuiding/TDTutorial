using System;
using UnityEngine;

public static class UIApp {

    public static void P_Login_Open(UIContext ctx, Action onClickStartHandle) {
        Panel_Login panel = ctx.panel_login;
        if (panel == null) {
            panel = GameObject.Instantiate(ctx.assetsContext.panel_login, ctx.canvas.transform);
            panel.Ctor();
            ctx.panel_login = panel;

            panel.OnStartClickHandle = onClickStartHandle;
        }
        panel.Show();
    }

    public static void P_Login_Close(UIContext ctx) {
        Panel_Login panel = ctx.panel_login;
        if (panel != null) {
            panel.Close();
        }
    }

}