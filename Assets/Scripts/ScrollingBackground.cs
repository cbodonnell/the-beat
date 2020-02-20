using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float paralaxSpeed = 0.5f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.cameraTransform = Camera.main.transform;
        this.lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPosition  = cameraTransform.position - lastCameraPosition;
        // transform.position += deltaPosition * this.paralaxSpeed;

        body.MovePosition(new Vector2(
            transform.position.x + deltaPosition.x * this.paralaxSpeed,
            transform.position.y + deltaPosition.y * this.paralaxSpeed
        ));

        this.lastCameraPosition = cameraTransform.position;
    }
}
