using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    [SerializeField] Text m_countText = default;
    [SerializeField] Text m_finishText = default;
    [SerializeField] GameObject m_finishPanel = default;

    bool isFinished = true;
    string player1Name = "<color=#FF8B72>1P</color>";
    string player2Name = "<color=#72D9FF>2P</color>";
    string drawText = "<color=#78FB9C>引き分け</color>";

    void Start()
    {
        StartCoroutine(CountDown());
    }

    void Update()
    {
        if (!GameManager.Instance.InGame && !isFinished)
        {
            //SoundManager.Instance.PlaySeByName("");

            m_finishText.enabled = true;
            if (GameManager.Instance.Player1Win) { m_finishText.text = $"{player1Name}の勝利！"; }
            if (GameManager.Instance.Player2Win) { m_finishText.text = $"{player2Name}の勝利！"; }
            if (GameManager.Instance.DrawGame) { m_finishText.text = drawText; }

            StartCoroutine(FinishPanel());

            isFinished = true;
            return;
        }
    }

    public void Retry()
    {
        //SoundManager.Instance.PlaySeByName("");

        GameManager.Instance.InGame = false;
        GameManager.Instance.ResetFlag();
        LoadSceneManager.Instance.Restart();
    }

    public void ReturnTitle()
    {
        //SoundManager.Instance.PlaySeByName("");

        GameManager.Instance.ResetFlag();
        LoadSceneManager.Instance.LoadTitleScene();
    }

    public void DebugGame()
    {
        GameManager.Instance.GameDebug();
    }

    IEnumerator CountDown()
    {
        m_finishText.text = "";
        m_finishText.enabled = false;
        m_finishPanel.SetActive(false);

        SoundManager.Instance.PlaySeByName("ボタン音25");
        m_countText.text = "5";
        yield return new WaitForSeconds(1.0f);

        SoundManager.Instance.PlaySeByName("ボタン音25");
        m_countText.text = "4";
        yield return new WaitForSeconds(1.0f);

        SoundManager.Instance.PlaySeByName("ボタン音25");
        m_countText.text = "3";
        yield return new WaitForSeconds(1.0f);

        SoundManager.Instance.PlaySeByName("ボタン音25");
        m_countText.text = "2";
        yield return new WaitForSeconds(1.0f);

        SoundManager.Instance.PlaySeByName("ボタン音25");
        m_countText.text = "1";
        yield return new WaitForSeconds(1.0f);

        SoundManager.Instance.PlaySeByName("Cyber02-1");
        GameManager.Instance.InGame = true;
        isFinished = false;
        m_countText.text = "START!";

        yield return new WaitForSeconds(1.0f);
        m_countText.text = "";
    }

    IEnumerator FinishPanel()
    {
        yield return new WaitForSeconds(2.0f);

        m_finishPanel.SetActive(true);
    }
}
