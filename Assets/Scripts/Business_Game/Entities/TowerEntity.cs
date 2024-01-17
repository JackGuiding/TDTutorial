using UnityEngine;

// 游戏设计 / 程序设计
// 塔可以攻击, 生成小怪
public class TowerEntity : MonoBehaviour {

    public int id;

    public bool isSpawner; // 是否生成器
    // 每次CD结束, 生成怪物总量: maintain / interval
    public float cd; // cooldown 冷却时间
    public float cdMax;
    public float maintain; // 维持时间
    public float maintainTimer;
    public float interval;
    public float intervalTimer;
    // public int roleTypeID;

    public Vector2[] path;

    public void Ctor() { }

    // 生成假数据
    public void InitFakeData() {
        isSpawner = true;
        cd = 1;
        cdMax = 1;
        maintain = 3;
        maintainTimer = 3.01f;
        interval = 1;
        intervalTimer = 1;

        // 0, 5
        path = new Vector2[] {
            new Vector2(2, 5),
            new Vector2(2, 3),
            new Vector2(0, 3),
            new Vector2(0, -5),
        };
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}