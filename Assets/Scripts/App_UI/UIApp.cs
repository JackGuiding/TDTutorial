using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UIApp {

    // P Login
    public static void P_Login_Open(UIContext ctx) {
        Panel_Login panel = ctx.panel_login;
        if (panel == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_Login", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Login>();
            panel.Ctor();
            ctx.panel_login = panel;

            panel.OnStartClickHandle = () => {
                ctx.events.Login_OnClickStart();
            };
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
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_HeartInfo>();
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

    // P BuildManifest
    public static void P_BuildManifest_Open(UIContext ctx, Vector3 worldPos) {
        Panel_BuildManifest panel = ctx.panel_buildManifest;
        if (panel == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_BuildManifest", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.worldCanvas.transform).GetComponent<Panel_BuildManifest>();
            panel.Ctor();
            ctx.panel_buildManifest = panel;

            panel.OnBuildHandle = (int clickedTowerEntityID, int clickedTowerTypeID) => {
                ctx.events.BuildManifest_OnBuild(clickedTowerEntityID, clickedTowerTypeID);
            };
        }
        panel.Init(worldPos);
    }

    public static void P_BuildManifest_AddOption(UIContext ctx, int clickedTowerEntityID, int clickedTowerTypeID) {
        Panel_BuildManifest panel = ctx.panel_buildManifest;
        if (panel != null) {
            // Template
            bool has = ctx.templateContext.towers.TryGetValue(clickedTowerTypeID, out TowerTM tm);
            panel.AddOption(clickedTowerEntityID, clickedTowerTypeID, tm.price, tm.sprite);
        }
    }

    public static void P_BuildManifest_Close(UIContext ctx) {
        Panel_BuildManifest panel = ctx.panel_buildManifest;
        if (panel != null) {
            panel.TearDown();
            ctx.panel_buildManifest = null;
        }
    }

}