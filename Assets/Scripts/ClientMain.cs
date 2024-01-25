using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {

    MainContext mainContext;

    void Start() {

        // SetFPS
        Application.targetFrameRate = 120;

        // 实例化(创建)
        mainContext = new MainContext();
        Canvas screenCanvas = gameObject.transform.Find("ScreenCanvas").GetComponent<Canvas>(); // GetComponent 与拖拽绑定相似, GetComponents
        Canvas worldCanvas = gameObject.transform.Find("WorldCanvas").GetComponent<Canvas>();
        Camera mainCamera = gameObject.GetComponentInChildren<Camera>();
        // 确保不为空
        Debug.Assert(screenCanvas != null);
        Debug.Assert(worldCanvas != null);

        // 依赖注入 Inject注入
        mainContext.Inject(mainCamera, screenCanvas, worldCanvas);

        // Binding Events
        BindingEvents(mainContext);

        // Init
        AssetsInfra.Load(mainContext.assetsContext);
        TemplateInfra.Load(mainContext.templateContext);

        // 进入 Login
        UIApp.P_Login_Open(mainContext.uiContext);

        // 简化
        // Transform tf = this.gameObject.GetComponent<Transform>(); // 自带的 this.transform
        // Debug.Log(transform.position.x);

        // GameObject.Instantiate
        // .prefab

        // Log 的用法
        // Debug.Log("ClientMain.Start()");
        // Debug.LogWarning("Warn");
        // Debug.LogError("err");

    }

    void BindingEvents(MainContext ctx) {

        UIEvents uiEvents = ctx.uiContext.events;

        uiEvents.Login_OnClickStartHandle = () => {
            UIApp.P_Login_Close(mainContext.uiContext);
            GameBusiness.Enter(mainContext.gameContext);
        };

        uiEvents.BuildManifest_OnBuildHandle = (int clickedTowerEntityID, int clickedTowerTypeID) => {
            GameBusiness.BuildManifest_OnBuild(mainContext.gameContext, clickedTowerEntityID, clickedTowerTypeID);
        };

    }

    float restDT;
    const float FIXED_INTERVAL = 0.01f;
    void Update() {

        float dt = Time.deltaTime; // 0.01 0.0001

        // PreTick: Input
        // 0.01 + 0.02 = 0.0300000004
        GameBusiness.PreTick(mainContext.gameContext, dt);

        // FixedTick
        restDT += dt;
        if (restDT <= FIXED_INTERVAL) {
            GameBusiness.FixedTick(mainContext.gameContext, restDT);
            restDT = 0;
        } else {
            while (restDT >= FIXED_INTERVAL) {
                GameBusiness.FixedTick(mainContext.gameContext, FIXED_INTERVAL);
                restDT -= FIXED_INTERVAL;
            }
        }

        // LateTick
        GameBusiness.LateTick(mainContext.gameContext, dt);

    }

}
