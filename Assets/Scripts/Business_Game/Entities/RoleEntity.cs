using UnityEngine;

public class RoleEntity : MonoBehaviour {

    public int id;

    public float moveSpeed;

    public Vector2[] path;
    public int pathIndex; // 0

    public void Ctor() { }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Move(Vector2 dir, float fixdt) {
        Vector2 pos = transform.position;
        pos += dir * moveSpeed * fixdt;
        transform.position = pos;
    }

}