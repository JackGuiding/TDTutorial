using UnityEngine;

// 所有数据都存这里
public class MainContext {

    public GameContext gameContext;

    public UIContext uiContext;
    public AssetsContext assetsContext;

    public MainContext() {
        gameContext = new GameContext();
        uiContext = new UIContext();
    }

    public void Inject(Canvas canvas, AssetsContext assetsContext) {

        this.assetsContext = assetsContext;

        gameContext.Inject(assetsContext);
        uiContext.Inject(canvas, assetsContext);
    }

}