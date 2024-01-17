public class GameContext {

    public FlagRepository flagRepository;
    public TowerRepository towerRepository;
    public RoleRepository roleRepository;

    public AssetsContext assetsContext;

    public int flagID;
    public int towerID;
    public int roleID;

    public GameContext() {
        flagRepository = new FlagRepository();
        towerRepository = new TowerRepository();
        roleRepository = new RoleRepository();
        flagID = 0;
        towerID = 0;
        roleID = 0;
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }

}