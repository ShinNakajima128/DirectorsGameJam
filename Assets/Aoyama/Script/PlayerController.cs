using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    [SerializeField] float bulletTimer = 0.5f;
    Rigidbody m_rb = default;
    Vector3 m_inputDirection = default;
    Vector3 m_rotate = default;
    [SerializeField] Shooter shooter;
    float Timer;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hLeft = Input.GetAxisRaw("Horizontal");
        float vLeft = Input.GetAxisRaw("Vertical");
        m_inputDirection = new Vector3(hLeft, 0, vLeft).normalized;
        Vector3 mousePos = Input.mousePosition;
        m_rotate = Camera.main.ScreenToWorldPoint(mousePos);
        m_rotate = new Vector3(m_rotate.x, 0, m_rotate.z);

        Timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && bulletTimer <= Timer)
        {
            Debug.Log("shot");
            shooter.shot();
            Timer = 0;
        }
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = m_rotate;
        transform.LookAt(targetPos, Vector3.up);
        
        m_rb.velocity = m_inputDirection * m_movePower;
    }
}
