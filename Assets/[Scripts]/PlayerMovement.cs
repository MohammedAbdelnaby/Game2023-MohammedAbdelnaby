using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1000f)]
    private float MoveSpeed = 50.0f;

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        Vector3 oldPosition = transform.position;
        rigidBody.MovePosition(oldPosition + new Vector3(X, Y, 0) * MoveSpeed * Time.deltaTime);
    }
}
