using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        // 怪物配置: Template Model (RoleTM)
        bool has = ctx.templateContext.roles.TryGetValue(typeID, out RoleTM tm);
        if (!has) {
            Debug.LogError("找不到RoleTM: " + typeID);
        }

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Role", out GameObject prefab);
        RoleEntity entity = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
        entity.Ctor();
        entity.SetPos(pos);
        entity.id = ctx.roleID++;

        entity.moveSpeed = tm.moveSpeed;
        entity.Init(tm.spr);

        Debug.Log("生成Role: " + typeID);

        ctx.roleRepository.Add(entity);
        return entity;
    }

    public static void Unspawn(GameContext ctx, RoleEntity role) {
        ctx.roleRepository.Remove(role);
        role.TearDown();
    }

    public static void MoveByPath(GameContext ctx, RoleEntity role, float fixdt) {

        // 无路径
        if (role.path == null) {
            return;
        }

        // 到达终点
        if (role.pathIndex >= role.path.Length) {
            return;
        }

        // (0, 5)
        // (3, 5)
        // 当前要走到的点
        Vector2 target = role.path[role.pathIndex];

        Vector2 dir = target - (Vector2)role.transform.position;
        if (dir.sqrMagnitude <= 0.01f) {
            role.pathIndex += 1;
        } else {
            dir.Normalize();
            role.Move(dir, fixdt);
        }

    }

    public static void OverlapFlag(GameContext ctx, RoleEntity role) {
        // 找到所有Flag, 并且与Role碰撞
        FlagEntity target = ctx.flagRepository.Find((FlagEntity flag) => {
            float disSqr = Vector2.SqrMagnitude((Vector2)role.transform.position - (Vector2)flag.transform.position);
            if (disSqr < 0.1f) {
                return true;
            } else {
                return false;
            }
        });

        if (target != null) {
            Unspawn(ctx, role);
            PlayerDomain.Hurt(ctx, ctx.playerEntity, 1);
        }
    }

}