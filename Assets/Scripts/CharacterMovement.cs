using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public int jumpAmount = 2;
    public float speed = 12f;
    public float jumpPower = 400f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += move;

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpAmount > 0)
            {
                jump();
            }
        }
    }

    void jump()
    {
        rb.AddForce(Vector3.up * jumpPower);
        jumpAmount--;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            jumpAmount = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("extraJump"))
        {
            jumpAmount++;
        }
    }
}
