using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public float jumpPower = 200f;
    public bool ground;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        moveDir = Vector3.ClampMagnitude(moveDir, 1);
        transform.Translate(moveDir * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && ground)
        {
                rb.AddForce(transform.up * jumpPower);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
}
