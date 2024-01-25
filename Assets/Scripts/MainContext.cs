using UnityEngine;

// 所有数据都存这里
public class MainContext {

    public GameContext gameContext;

    public UIContext uiContext;
    public AssetsContext assetsContext;
    public TemplateContext templateContext;

    public MainContext() {
        gameContext = new GameContext();
        uiContext = new UIContext();
        assetsContext = new AssetsContext();
        templateContext = new TemplateContext();
    }

    public void Inject(Camera mainCamera, Canvas screenCanvas, Canvas worldCanvas) {
        gameContext.Inject(mainCamera, uiContext, assetsContext, templateContext);
        uiContext.Inject(screenCanvas, worldCanvas, assetsContext, templateContext);
    }

}