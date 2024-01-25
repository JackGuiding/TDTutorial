using UnityEngine;

public class GameContext {

    public PlayerEntity playerEntity;
    public InputEntity inputEntity;
    public FlagRepository flagRepository;
    public TowerRepository towerRepository;
    public RoleRepository roleRepository;

    public UIContext uiContext;
    public AssetsContext assetsContext;
    public TemplateContext templateContext;

    public Camera mainCamera;

    public int flagID;
    public int towerID;
    public int roleID;

    public GameContext() {
        playerEntity = new PlayerEntity();
        inputEntity = new InputEntity();
        flagRepository = new FlagRepository();
        towerRepository = new TowerRepository();
        roleRepository = new RoleRepository();

        flagID = 0;
        towerID = 0;
        roleID = 0;
    }

    public void Inject(Camera mainCamera, UIContext uiContext, AssetsContext assetsContext, TemplateContext templateContext) {
        this.mainCamera = mainCamera;
        this.uiContext = uiContext;
        this.assetsContext = assetsContext;
        this.templateContext = templateContext;
    }

}