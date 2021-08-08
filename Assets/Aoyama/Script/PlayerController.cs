using UnityEngine;

public enum PlayerNum
{
    player1, player2 
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerNum number;
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    [SerializeField] float bulletTimer = 0.5f;
    Rigidbody m_rb = default;
    Vector3 m_inputDirection = default;
    Vector3 m_rotate = default;
    [SerializeField] Shooter shooter;
    [SerializeField] int life = 10;
    [SerializeField] GameManager gameManager;
    float Timer;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (number)
        {
            case PlayerNum.player1:
                Player1();
                break;
            case PlayerNum.player2:
                Player2();
                break;
            default:
                break;
        }

        //float hLeft = Input.GetAxisRaw("Horizontal");
        //float vLeft = Input.GetAxisRaw("Vertical");
        //m_inputDirection = new Vector3(hLeft, 0, vLeft).normalized;
        //Vector3 mousePos = Input.mousePosition;
        //m_rotate = Camera.main.ScreenToWorldPoint(mousePos);
        //m_rotate = new Vector3(m_rotate.x, 0, m_rotate.z);

        //Timer += Time.deltaTime;
        //if (Input.GetButton("Fire1") && bulletTimer <= Timer)
        //{
        //    Debug.Log("shot");
        //    shooter.shot();
        //    Timer = 0;
        //}
    }
    private void FixedUpdate()
    {
        //Vector3 targetPos = m_rotate;
        Vector3 targetPos = m_rotate + transform.position;
        transform.LookAt(targetPos, Vector3.up);
        
        m_rb.velocity = m_inputDirection * m_movePower;
    }


    void Player1()
    {
        float hLeft = Input.GetAxisRaw("Horizontal2");
        float vLeft = Input.GetAxisRaw("Vertical2");
        m_inputDirection = new Vector3(hLeft, 0, vLeft).normalized;
        float hRight = Input.GetAxisRaw("Horizontal2Right");
        float vRight = Input.GetAxisRaw("Vertical2Right");
        m_rotate = new Vector3(hRight, 0, vRight).normalized;

        Timer += Time.deltaTime;
        if (Input.GetAxis("L_R_Trigger2") > 0 && bulletTimer <= Timer)
        {
            Debug.Log("shot");
            shooter.shot();
            Timer = 0;
        }
    }
    void Player2()
    {
        float hLeft = Input.GetAxisRaw("HL");
        float vLeft = Input.GetAxisRaw("VL");
        m_inputDirection = new Vector3(hLeft, 0, vLeft).normalized;
        float hRight = Input.GetAxisRaw("HR");
        float vRight = Input.GetAxisRaw("VR");
        m_rotate = new Vector3(hRight, 0, vRight).normalized;

        Timer += Time.deltaTime;
        if (Input.GetAxis("L_R_Trigger") > 0 && bulletTimer <= Timer)
        {
            Debug.Log("shot");
            shooter.shot();
            Timer = 0;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet" || collision.collider.tag == "Bomb")
        {
            life--;
            if (life <= 0)
            {
                switch (number)
                {
                    case PlayerNum.player1:
                        //gameManager.Player2Win = true;
                        break;
                    case PlayerNum.player2:
                        //gameManager.Player1Win = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
