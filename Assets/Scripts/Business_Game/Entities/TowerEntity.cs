using UnityEngine;

// 游戏设计 / 程序设计
// 塔可以攻击, 生成小怪
// 空地也是Tower
public class TowerEntity : MonoBehaviour {

    public int id;
    public int typeID;

    public int price;

    // ==== 形状 ====
    // 矩形
    public Vector2 shapeSize;

    // ==== 生成器 ====
    public bool isSpawner; // 是否生成器
    // 每次CD结束, 生成怪物总量: maintain / interval
    public float cd; // cooldown 冷却时间
    public float cdMax;
    public float maintain; // 维持时间
    public float maintainTimer;
    public float interval;
    public float intervalTimer;
    public int roleTypeID;

    public Vector2[] path;

    // ==== 渲染 ====
    [SerializeField] SpriteRenderer sr;

    public void Ctor() { }

    public void TearDown() {
        Destroy(gameObject);
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void SetSprite(Sprite sprite) {
        sr.sprite = sprite;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, shapeSize);
    }

}