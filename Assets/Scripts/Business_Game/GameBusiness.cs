using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        Debug.Log("EnterGame");

        // 1. 生成我方基地 Entity Flag
        FlagDomain.Spawn(ctx, 0, new Vector2(0, -5));

        // 2. 生成刷怪点 Entity Tower
        TowerDomain.Spawn(ctx, 0, new Vector2(0, 5));

    }

    // 每帧一次
    public static void PreTick(GameContext ctx, float dt) {

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
        }

    }

    // 每帧一次
    public static void LateTick(GameContext ctx, float dt) {

    }

    public static void Exit(GameContext ctx) {
        // 1. 清理所有 Entity
    }

}