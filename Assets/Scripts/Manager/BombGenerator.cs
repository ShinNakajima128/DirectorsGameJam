using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    [SerializeField] GameObject bomb;
    [SerializeField] GameObject efect;
    [SerializeField] int maxBombs = 50;
    [SerializeField] int startBombs = 20;

    [SerializeField] int ariaX = 50;
    [SerializeField] int ariaZ = 50;

    List<GameObject> bombs = new List<GameObject>();

    float timer = 0;
    [SerializeField] float spownTime = 5f;
    [SerializeField] float spownFast = 0.5f;
    [SerializeField] float spownMin = 2f;
    void Start()
    {
        ariaX /= 2;
        ariaZ /= 2;
        for (int i = 0; i < startBombs; i++)
        {
            Vector3 point = SpownPotison();
            BombsGenerate(point);
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.InGame)
        {
            return;
        }

        if (timer > spownTime && bombs.Count < maxBombs)
        {
            Vector3 point = SpownPotison();

            StartCoroutine(Efect(point));
            if (spownTime > spownMin)
            {
                spownTime -= spownFast;
            }
            timer = 0;
            
        }
        else
        {
            timer += Time.deltaTime;
        }

        for (int i = 0; i < bombs.Count; i++)
        {
            if (!bombs[i].activeSelf)
            {
                Destroy(bombs[i]);
                bombs.RemoveAt(i);
            }
        }
    }

    IEnumerator Efect(Vector3 point)
    {
        GameObject efectObj = Instantiate(efect, point, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(efectObj);
        bombs.Add(Instantiate(bomb, point, Quaternion.identity));
    }

    void BombsGenerate(Vector3 point)
    {
        bombs.Add(Instantiate(bomb, point, Quaternion.identity));
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
