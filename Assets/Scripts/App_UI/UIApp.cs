using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UIApp {

    // P Login
    public static void P_Login_Open(UIContext ctx, Action onClickStartHandle) {
        Panel_Login panel = ctx.panel_login;
        if (panel == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_Login", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();
            panel.Ctor();
            ctx.panel_login = panel;

            panel.OnStartClickHandle = onClickStartHandle;
        }
        panel.Show();
        EventSystem.current.SetSelectedGameObject(panel.startBtn.gameObject);
    }

    public static void P_Login_Close(UIContext ctx) {
        Panel_Login panel = ctx.panel_login;
        if (panel != null) {
            panel.Close();
        }
    }

    // P HeartInfo
    public static void P_HearInfo_Open(UIContext ctx, int hp) {
        Panel_HeartInfo panel = ctx.panel_heartInfo;
        if (panel == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_HeartInfo", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_HeartInfo>();
            panel.Ctor();
            ctx.panel_heartInfo = panel;
        }
        panel.Init(hp);
        panel.Show();
    }

    public static void P_HearInfo_Update(UIContext ctx, int hp) {
        Panel_HeartInfo panel = ctx.panel_heartInfo;
        if (panel != null) {
            panel.Init(hp);
        }
    }

    public static void P_HearInfo_Close(UIContext ctx) {
        Panel_HeartInfo panel = ctx.panel_heartInfo;
        if (panel != null) {
            panel.Close();
        }
    }

}