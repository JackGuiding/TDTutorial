using UnityEngine;

public class UIContext {

    public Panel_Login panel_login;

    public Canvas canvas;

    public AssetsContext assetsContext;

    public UIContext() { }

    public void Inject(Canvas canvas, AssetsContext assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
    }

}