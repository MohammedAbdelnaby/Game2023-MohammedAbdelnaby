using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1000f)]
    private float MoveSpeed = 50.0f;

    [SerializeField]
    private Animator animator;

    private Direction direction = Direction.SOUTH;

    private Rigidbody2D rigidBody;

    public Direction Direction { get => direction; set => direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateAnimations();
    }

    private void Move()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        Vector3 oldPosition = transform.position;
        rigidBody.MovePosition(oldPosition + new Vector3(X, Y, 0) * MoveSpeed * Time.deltaTime);
    }

    private void UpdateAnimations()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        if (X == 0.0f && Y == 0.0f)
        {
            animator.SetBool("Running", false);
            animator.SetInteger("Direction", (int)direction);
        }

        if (X > 0.0f)
        {
            animator.SetBool("Running", true);
            animator.SetInteger("Direction", (int)Direction.EAST);
            direction = Direction.EAST;
        }
        else if (X < 0.0f)
        {
            animator.SetBool("Running", true);
            animator.SetInteger("Direction", (int)Direction.WEST);
            direction = Direction.WEST;
        }

        if (Y > 0.0f)
        {
            animator.SetBool("Running", true);
            animator.SetInteger("Direction", (int)Direction.SOUTH);
            direction = Direction.SOUTH;
        }
        else if (Y < 0.0f)
        {
            animator.SetBool("Running", true);
            animator.SetInteger("Direction", (int)Direction.NORTH);
            direction = Direction.NORTH;
        }
    }

    public void TravelToSavedPoistion()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z")), 0.25f);
    }
}
