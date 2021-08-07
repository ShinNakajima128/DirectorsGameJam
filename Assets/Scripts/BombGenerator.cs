using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    [SerializeField] GameObject bomb;
    [SerializeField] int maxBombs = 50;
    [SerializeField] int startBombs = 20;

    [SerializeField] int ariaX = 50;
    [SerializeField] int ariaY = 50;

    List<GameObject> bombs = new List<GameObject>();

    float timer = 0;
    [SerializeField] float spownTime = 0.5f;
    public float SpownTime { get => spownTime; set {spownTime = value; } }
    void Start()
    {
        for (int i = 0; i < startBombs; i++)
        {
            BombsGenerate();
        }
    }

    private void FixedUpdate()
    {
        if (timer > spownTime)
        {
            if (bombs.Count < maxBombs)
            {
                BombsGenerate();
                timer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void BombsGenerate()
    {
        Vector3 point = SpownPotison();
        // 同じ場所、playerの近くにスポーンしないようにする
        bombs.Add(Instantiate(bomb, point, Quaternion.identity));
    }

    Vector3 SpownPotison()
    {
        bool cheak = true;
        Vector3 point = Vector3.zero;
        while (cheak)
        {
            int randomX = Random.Range(0, ariaX);
            int randomZ = Random.Range(0, ariaY);
            point = new Vector3(randomX, 0, randomZ);

            float distance = Vector3.Distance(point, player1.position);
            float distance2 = Vector3.Distance(point, player2.position);

            if (distance > 2 && distance2 > 2)
            {
                cheak = false;
            }
            foreach (var item in bombs)
            {
                distance = Vector3.Distance(point, item.transform.position);
                if (distance < 1)
                {
                    cheak = true;
                }
            }
        }

        return point;
    }
}
