using System;
using UnityEngine;

public class UIEvents {

    // Login
    public Action Login_OnClickStartHandle;
    public void Login_OnClickStart() {
        Login_OnClickStartHandle.Invoke();
    }

    // BuildManifest
    public Action<int, int> BuildManifest_OnBuildHandle;
    public void BuildManifest_OnBuild(int clickedTowerEntityID, int clickedTowerTypeID) {
        BuildManifest_OnBuildHandle.Invoke(clickedTowerEntityID, clickedTowerTypeID);
    }

    public UIEvents() {}

}