using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        RoleEntity prefab = ctx.assetsContext.roleEntity;
        RoleEntity entity = GameObject.Instantiate(prefab);
        entity.Ctor();
        entity.SetPos(pos);
        entity.id = ctx.roleID++;

        entity.moveSpeed = 4.5f;

        ctx.roleRepository.Add(entity);
        return entity;
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

}