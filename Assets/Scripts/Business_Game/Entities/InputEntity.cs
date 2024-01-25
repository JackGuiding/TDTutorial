using UnityEngine;

public class InputEntity {

    // public Vector2 moveDir; // ↑ ↓ ← →
    public Vector2 mouseScreenPos;
    public Vector2 mouseWorldPos;
    public bool isMouseLeftDown;

    public InputEntity() { }

    public void Reset() {
        // moveDir = Vector2.zero;
        mouseScreenPos = Vector2.zero;
        mouseWorldPos = Vector2.zero;
        isMouseLeftDown = false;
    }

}