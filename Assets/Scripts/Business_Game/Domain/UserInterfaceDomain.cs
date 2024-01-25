using UnityEngine;

public static class UserInterfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;

        // Tower
        int towerLen = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
        for (int i = 0; i < towerLen; i++) {
            TowerEntity tower = towers[i];
            if (PFPhysics.IsPointInsideRectangle(input.mouseWorldPos, tower.transform.position, tower.shapeSize)) {
                Debug.Log("Tower Clicked" + tower.name);
                input.isMouseLeftDown = false;
                break;
            }
        }

    }

}