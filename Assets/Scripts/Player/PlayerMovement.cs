using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 6f;
    Vector3 movement;
    Rigidbody body;
    Animator anim;
    int floorMask;

    float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h,v);
    }

    void Move(float h , float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        body.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            body.MoveRotation(newRotation);

        }

    }

    void Animating(float h , float v)
    {
        bool walking = h != 0 || v != 0;
        anim.SetBool("IsWalking", walking);
        print(walking);
    }
}
