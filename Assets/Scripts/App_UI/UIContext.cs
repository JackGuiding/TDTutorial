using UnityEngine;

public class UIContext {

    public Panel_Login panel_login;
    public Panel_HeartInfo panel_heartInfo;
    public Panel_BuildManifest panel_buildManifest;

    public UIEvents events;

    public Canvas screenCanvas; // Screen Canvas
    public Canvas worldCanvas; // World Canvas

    public AssetsContext assetsContext;
    public TemplateContext templateContext;

    public UIContext() {
        events = new UIEvents();
    }

    public void Inject(Canvas screenCanvas, Canvas worldCanvas, AssetsContext assetsContext, TemplateContext templateContext) {
        this.screenCanvas = screenCanvas;
        this.worldCanvas = worldCanvas;
        this.assetsContext = assetsContext;
        this.templateContext = templateContext;
    }

}