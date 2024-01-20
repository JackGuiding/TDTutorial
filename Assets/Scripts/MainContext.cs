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

    public void Inject(Canvas canvas) {
        gameContext.Inject(uiContext, assetsContext, templateContext);
        uiContext.Inject(canvas, assetsContext);
    }

}