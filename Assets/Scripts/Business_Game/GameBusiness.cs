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
        TowerDomain.Spawn(ctx, 0, new Vector2(0, 5));

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

}