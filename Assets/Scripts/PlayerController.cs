using UnityEngine;
using UnityEngine.UI;

public enum PlayerNum
{
    player1, player2 
}
public class PlayerController : MonoBehaviour
{
    bool move = false;

    [SerializeField] PlayerNum number;
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    [SerializeField] float bulletTimer = 0.5f;
    Rigidbody m_rb = default;
    Vector3 m_inputDirection = default;
    Vector3 m_rotate = default;
    [SerializeField] Shooter shooter;
    [SerializeField] int ariaX = 50;
    [SerializeField] int ariaZ = 30;
    [SerializeField] Transform playerEnemy;

    [SerializeField] Slider hp;
    [SerializeField] int maxLife = 10;
    int life = 0;

    float Timer;

    void Start()
    {
        life = maxLife;
        hp.value = (float)life / maxLife;
        ariaX /= 2;
        ariaZ /= 2;
        transform.position = SpownPotison();
        m_rb = GetComponent<Rigidbody>();
        hp.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        if (!GameManager.Instance.InGame)
        {
            m_rb.velocity = Vector3.zero;
            return;
        }
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
        if (!GameManager.Instance.InGame)
        {
            m_rb.velocity = Vector3.zero;
            return;
        }
        //Vector3 targetPos = m_rotate;
        Vector3 targetPos = m_rotate + transform.position;
        transform.LookAt(targetPos, Vector3.up);

        m_rb.velocity = m_inputDirection * m_movePower;
        hp.transform.position = transform.position + Vector3.forward;
        hp.transform.rotation = Quaternion.Euler(90, 0, 0);
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
        if (Input.GetAxis("L_R_Trigger") > 0 && bulletTimer <= Timer)
        {
            SoundManager.Instance.PlaySeByName("SF系射撃音(SE2)");
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
        if (Input.GetAxis("L_R_Trigger2") > 0 && bulletTimer <= Timer)
        {
            SoundManager.Instance.PlaySeByName("SF系射撃音(SE2)");
            shooter.shot();
            Timer = 0;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb")
        {
            if (!GameManager.Instance.InGame)
            {
                return;
            }
            life--;
            hp.value = (float)life / maxLife;
            if (life <= 0)
            {
                GameManager.Instance.GameEnd(number);
                Destroy(this.gameObject);
            }
        }
    }


    Vector3 SpownPotison()
    {
        bool cheak = true;
        Vector3 point = Vector3.zero;
        while (cheak)
        {
            int randomX = Random.Range(-ariaX + 1, ariaX);
            int randomZ = Random.Range(-ariaZ + 1, ariaZ);
            point = new Vector3(randomX, 0, randomZ);

            float distance = Vector3.Distance(point, playerEnemy.position);
            if (distance > 10)
            {
                cheak = false;
            }
        }
        return point;
    }
}
