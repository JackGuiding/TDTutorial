public class GameContext {

    public PlayerEntity playerEntity;
    public FlagRepository flagRepository;
    public TowerRepository towerRepository;
    public RoleRepository roleRepository;

    public UIContext uiContext;
    public AssetsContext assetsContext;

    public int flagID;
    public int towerID;
    public int roleID;

    public GameContext() {
        playerEntity = new PlayerEntity();
        flagRepository = new FlagRepository();
        towerRepository = new TowerRepository();
        roleRepository = new RoleRepository();

        flagID = 0;
        towerID = 0;
        roleID = 0;
    }

    public void Inject(UIContext uiContext, AssetsContext assetsContext) {
        this.uiContext = uiContext;
        this.assetsContext = assetsContext;
    }

}