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
        Canvas canvas = gameObject.GetComponentInChildren<Canvas>(); // GetComponent 与拖拽绑定相似, GetComponents
        AssetsContext assetsContext = gameObject.GetComponentInChildren<AssetsContext>();

        // 依赖注入 Inject注入
        mainContext.Inject(canvas, assetsContext);

        // 进入 Login
        UIApp.P_Login_Open(mainContext.uiContext, () => {
            UIApp.P_Login_Close(mainContext.uiContext);
            GameBusiness.Enter(mainContext.gameContext);
        });

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

    float restDT;
    const float FIXED_INTERVAL = 0.01f;
    void Update() {

        float dt = Time.deltaTime; // 0.01 0.0001

        // PreTick
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
