using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        Debug.Log("EnterGame");

        // 0. Player
        ctx.playerEntity.hp = 5;
        ctx.playerEntity.hpMax = 5;

        // 1. 生成我方基地 Entity Flag
        FlagDomain.Spawn(ctx, 0, new Vector2(0, -5));

        // 2. 生成刷怪点 Entity Tower
        TowerDomain.Spawn(ctx, 1000, new Vector2(0, 5));

        // 生成空地
        TowerDomain.Spawn(ctx, 100, new Vector2(-1, 0));

        // 3. 打开 UI
        UIApp.P_HearInfo_Open(ctx.uiContext, ctx.playerEntity.hp);

    }

    // 每帧一次
    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;

        // 鼠标屏幕空间
        input.mouseScreenPos = Input.mousePosition;

        // 鼠标世界空间
        Camera mainCamera = ctx.mainCamera;
        input.mouseWorldPos = mainCamera.ScreenToWorldPoint(input.mouseScreenPos);
        // mainCamera.WorldToScreenPoint(Vector3.zero);

        // 0 左键点击, 1 右键点击, 2 中键点击
        if (Input.GetMouseButtonDown(0)) {
            input.isMouseLeftDown = true;
        }

        // 处理用户输入
        UserInterfaceDomain.PreTick(ctx, dt);

        // for Flag

        // for Role

    }

    // 可能一帧有多次
    public static void FixedTick(GameContext ctx, float fixdt) {

        // for Tower
        int towerLen = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
        for (int i = 0; i < towerLen; i += 1) {
            TowerEntity tower = towers[i];
            TowerDomain.TrySpawnRoles(ctx, tower, fixdt);
        }

        // for role
        int roleLen = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
        for (int i = 0; i < roleLen; i += 1) {
            RoleEntity role = roles[i];
            RoleDomain.MoveByPath(ctx, role, fixdt);
            RoleDomain.OverlapFlag(ctx, role);
        }

    }

    // 每帧一次
    public static void LateTick(GameContext ctx, float dt) {
        UIApp.P_HearInfo_Update(ctx.uiContext, ctx.playerEntity.hp);

        ctx.inputEntity.Reset();
    }

    public static void Exit(GameContext ctx) {
        // 1. 清理所有 Entity
    }

    // 事件反馈
    public static void BuildManifest_OnBuild(GameContext ctx, int clickedTowerEntityID, int clickedTowerTypeID) {
        // clickedTowerEntityID 表示: 基于谁, 造在哪里
        // clickedTowerTypeID 表示造什么
        bool has = ctx.towerRepository.TryGet(clickedTowerEntityID, out TowerEntity clickedTowerEntity);
        if (!has) {
            Debug.LogError($"BuildManifest_OnBuild, no such tower entityID: {clickedTowerEntityID}");
            return;
        }

        Vector3 clickPos = clickedTowerEntity.transform.position;

        // 销毁旧塔, 生成新塔
        TowerDomain.Unspawn(ctx, clickedTowerEntity);
        TowerDomain.Spawn(ctx, clickedTowerTypeID, clickPos);

        // 关闭旧的 UI, 旧的UI Element 存有旧的 ClickTowerEntityID
        UIApp.P_BuildManifest_Close(ctx.uiContext);
        // UIApp.P_BuildManifest_Open(ctx.uiContext, clickPos);
        // Debug.Log($"BuildManifest_OnBuild, clickedTowerEntityID: {clickedTowerEntityID}, clickedTowerTypeID: {clickedTowerTypeID}");
    }

}