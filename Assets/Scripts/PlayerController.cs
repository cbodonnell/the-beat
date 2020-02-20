using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    [Range(0.0f, 20.0f)]
    private float speed = 10.0f;

    private void Start() {
        this.body = GetComponent<Rigidbody2D>();
    }
 
   private void Update() {
        float upInput = Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;
        float downInput = Input.GetKey(KeyCode.S) ? -1.0f : 0.0f;
        float leftInput = Input.GetKey(KeyCode.A) ? -1.0f : 0.0f;
        float rightInput = Input.GetKey(KeyCode.D) ? 1.0f : 0.0f;
        bool isMoving = this.isMoving(upInput, downInput, leftInput, rightInput);
        if (isMoving) {
            Vector2 direction = new Vector2(
                leftInput + rightInput,
                upInput + downInput
            );
            // transform.position += direction * speed * Time.deltaTime;
            body.MovePosition(new Vector2(
                transform.position.x + direction.x * this.speed * Time.deltaTime,
                transform.position.y + direction.y * this.speed * Time.deltaTime
            ));
        }
    }

    private bool isMoving(float upInput, float downInput, float leftInput, float rightInput) {
        return (upInput != 0.0f || downInput != 0.0f || leftInput != 0.0f || rightInput != 0.0f);
    }
}
