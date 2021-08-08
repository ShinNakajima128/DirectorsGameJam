using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームを管理するクラス
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("タイトル画面のシーン名")]
    [SerializeField] string m_titleScene = "Title";
    [Header("メインゲーム画面のシーン名")]
    [SerializeField] string m_mainScene = "Main";
    [Header("リザルト画面のシーン名")]
    [SerializeField] string m_reslutScene = "Result";

    [Header("デバッグ用")]
    [SerializeField] bool m_player1Win = false;
    [SerializeField] bool m_player2Win = false;
    [SerializeField] bool m_drawGame = false;

    public bool InGame { get; set; }

    public bool Player1Win { get => m_player1Win; }
    public bool Player2Win { get => m_player2Win; }
    public bool DrawGame { get => m_drawGame; }


    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            InGame = false;
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {

        }
    }

    /// <summary>
    /// 各Sceneへ遷移した時に処理を実行する
    /// </summary>
    /// <param name="nextScene"> 遷移後のScene </param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                break;
            case "Main":
                break;
            case "Result":
                break;
            default:
                break;
        }
    }

    //private void Update()
    //{
    //    if (InGame)
    //    {
    //        //if (player1.hp <= 0)
    //        //{
    //        //    m_player2Win = true;
    //        //    InGame = false;
    //        //}
    //        //else if (player2.hp <= 0)
    //        //{
    //        //    m_player1Win = true;
    //        //    InGame = false;
    //        //}
    //        //else
    //        //{
    //        //    m_draw = true;
    //        //    InGame = false;
    //        //}
    //    }
    //}

    public void GameEnd(PlayerNum player)
    {
        if (player == PlayerNum.player1)
        {
            m_player2Win = true;
        }
        else if(player == PlayerNum.player2)
        {
            m_player1Win = true;
        }
        
        if (m_player1Win && m_player2Win)
        {
            m_player1Win = false;
            m_player2Win = false;
            m_drawGame = true;
        }

        InGame = false;
    }

    public void GameDebug()
    {
        InGame = false;
    }

    public void ResetFlag()
    {
        m_player1Win = false;
        m_player2Win = false;
        m_drawGame = false;
    }
}
