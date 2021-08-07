using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    Rigidbody m_rb = default;
    Vector3 m_inputDirection = default;
    Vector3 m_rotate = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hLeft = Input.GetAxisRaw("Horizontal");
        float vLeft = Input.GetAxisRaw("Vertical");
        m_inputDirection = new Vector3(hLeft, 0, vLeft).normalized;
        float hRight = Input.GetAxisRaw("HorizontalRight");
        float vRight = Input.GetAxisRaw("VerticalRight");
        m_rotate = new Vector3(hRight, 0, vRight).normalized;
    }

    private void FixedUpdate()
    {
        //Quaternion targetPosition = Quaternion.LookRotation(m_rotate);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetPosition, Time.deltaTime * m_rotateSpeed);
        //this.transform.up = Vector3.RotateTowards(this.transform.up, m_rotate, Time.deltaTime * m_rotateSpeed, 0);
        Vector3 targetPos = transform.position + m_rotate;
        transform.LookAt(targetPos, Vector3.up);
        
        m_rb.velocity = m_inputDirection * m_movePower;
    }
}
