using UnityEngine;

// 游戏设计 / 程序设计
// 塔可以攻击, 生成小怪
// 空地也是Tower
public class TowerEntity : MonoBehaviour {

    public int id;

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

    public void Ctor() { }

    // 生成假数据
    public void InitFakeData() {

        shapeSize = new Vector2(1, 1);

        isSpawner = true;
        cd = 1;
        cdMax = 1;
        maintain = 3;
        maintainTimer = 3.01f;
        interval = 1;
        intervalTimer = 1;
        roleTypeID = 100;

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

    // MonoBehaviour 生命周期函数
    // 见官方文档
    void Awake() { }
    void Start() { }
    void Update() { }
    void FixedUpdate(){}
    void LateUpdate(){}
    void OnTriggerEnter2D(Collider2D other){}
    void OnTriggerStay2D(Collider2D other){}
    void OnTriggerExit2D(Collider2D other){}

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, shapeSize);
    }

}