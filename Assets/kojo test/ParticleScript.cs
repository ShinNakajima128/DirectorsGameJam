using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private float alphaValue = 1f;
    //private ParticleShockwaveChara particleShockwaveChara;
    //　パーティクルシステム
    private ParticleSystem ps;
    //　ScaleUp用の経過時間
    private float elapsedScaleUpTime = 0f;
    //　Scaleを大きくする間隔時間
    [SerializeField]
    private float scaleUpTime = 0.03f;
    //　ScaleUpする割合
    [SerializeField]
    private float scaleUpParam = 0.1f;
    //　パーティクル削除用の経過時間
    private float elapsedDeleteTime = 0f;
    //　パーティクルを削除するまでの時間
    [SerializeField]
    private float deleteTime = 5f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        //particleShockwaveChara = GameObject.Find("NormalChara").GetComponent<ParticleShockwaveChara>();
        //ps.trigger.SetCollider(0, particleShockwaveChara.transform);
    }

    //float minAngle = 0.0f;
    //float maxAngle = 360.0f;
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 5));
        //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        //transform.eulerAngles = new Vector3(0, angle, 0);
        elapsedScaleUpTime += Time.deltaTime;
        elapsedDeleteTime += Time.deltaTime;

        if (elapsedDeleteTime >= deleteTime)
        {
            Destroy(gameObject);
        }

        if (elapsedScaleUpTime > scaleUpTime)
        {
            transform.localScale += new Vector3(scaleUpParam, scaleUpParam, scaleUpParam);
            elapsedScaleUpTime = 0f;
        }
    }

    public void OnParticleTrigger()
    {

        if (ps != null)
        {
            //　パーティクルを段々と透けさせる処理
            List<ParticleSystem.Particle> outside = new List<ParticleSystem.Particle>();

            int numOutside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Outside, outside);

            alphaValue -= (1f / deleteTime) * Time.deltaTime;

            alphaValue = (alphaValue <= 0f) ? 0f : alphaValue;

            for (int i = 0; i < numOutside; i++)
            {
                ParticleSystem.Particle p = outside[i];
                p.startColor = new Color(1f, 1f, 1f, alphaValue);
                outside[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Outside, outside);
            //　Particle型のインスタンス生成
            List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

            //　Inside、Enterのパーティクルを取得
            int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            //　データがあればキャラクターに接触した
            if (numInside != 0 || numEnter != 0)
            {
                Debug.Log("接触");
                //if (particleShockwaveChara.GetState() != ParticleShockwaveChara.State.damage)
                //{
                //    particleShockwaveChara.Damage();
                //}
            }

            //　わかりやすくキャラクターと接触したパーティクルの色を赤に変更
            for (int i = 0; i < numInside; i++)
            {
                ParticleSystem.Particle p = inside[i];
                p.startColor = new Color32(255, 0, 0, 255);
                inside[i] = p;
            }

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enter[i];
                p.startColor = new Color32(255, 0, 0, 255);
                enter[i] = p;
            }

            //　パーティクルデータの設定
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        }
    }
}
