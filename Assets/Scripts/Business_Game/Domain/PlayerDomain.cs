using UnityEngine;

public static class PlayerDomain {

    public static void Hurt(GameContext ctx, PlayerEntity player, int hurt) {
        player.hp -= hurt;
        if (player.hp <= 0) {
            player.hp = 0;
            Debug.Log("Game Over");
        }
    }

}