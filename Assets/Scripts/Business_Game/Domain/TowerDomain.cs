using UnityEngine;

public static class TowerDomain {

    public static TowerEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Tower", out GameObject prefab);
        TowerEntity entity = GameObject.Instantiate(prefab).GetComponent<TowerEntity>();
        entity.Ctor();
        entity.SetPos(pos);
        entity.id = ctx.towerID++;

        // 生成假数据 测试用 TM
        entity.InitFakeData();

        ctx.towerRepository.Add(entity);
        return entity;
    }

    public static void TrySpawnRoles(GameContext ctx, TowerEntity tower, float fixdt) {
        // 单个塔生成怪物
        if (!tower.isSpawner) {
            return;
        }

        tower.cd -= fixdt; // 0.2 0.3
        if (tower.cd > 0) {
            return;
        }

        tower.intervalTimer -= fixdt;
        if (tower.intervalTimer <= 0) {
            tower.intervalTimer = tower.interval;
            RoleEntity role = RoleDomain.Spawn(ctx, tower.roleTypeID, tower.transform.position);
            role.path = tower.path;
        }

        tower.maintainTimer -= fixdt;
        if (tower.maintainTimer <= 0) {
            tower.maintainTimer = tower.maintain;
            tower.cd = tower.cdMax;
        }

    }

}