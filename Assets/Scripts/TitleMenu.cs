using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TitleState
{
    Start,
    Main,
    Audio,
    Help,
    Quit
}

public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject m_startText = default;
    [SerializeField] GameObject m_mainPanel = default;
    [SerializeField] GameObject m_audioPanel = default;
    [SerializeField] GameObject m_helpPanel = default;
    [SerializeField] GameObject m_quitPanel = default;
    [SerializeField] Button m_mainButton = default;
    [SerializeField] Button m_audioButton = default;
    [SerializeField] Button m_helpButton = default;
    [SerializeField] Button m_quitButton = default;

    [SerializeField] Image[] m_playGuideImage = default;
    [Header("デバッグ用")]
    [SerializeField] TitleState m_titleState = TitleState.Start;
    bool isStarted = false;

    void Start()
    {
        OnStartPanel();
    }

    void Update()
    {
        if (!isStarted && Input.anyKeyDown)
        {
            OnMainPanel();
            isStarted = true;
        }
        if (isStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            OnStartPanel();
            isStarted = false;
        }
    }

    public void OnStartPanel()
    {
        m_titleState = TitleState.Start;
        ChangeTitleState(m_titleState);
    }

    public void OnMainPanel()
    {
        SoundManager.Instance.PlaySeByName("SF決定音1");
        m_titleState = TitleState.Main;
        ChangeTitleState(m_titleState);
        //m_mainButton.Select();
    }

    public void OnAudioPanel()
    {
        SoundManager.Instance.PlaySeByName("SF決定音1");
        m_titleState = TitleState.Audio;
        ChangeTitleState(m_titleState);
        m_audioButton.Select();
    }
    public void OnHelpPanel()
    {
        SoundManager.Instance.PlaySeByName("SF決定音1");
        m_titleState = TitleState.Help;
        ChangeTitleState(m_titleState);
        m_helpButton.Select();
    }
    public void OnQuitPanel()
    {
        SoundManager.Instance.PlaySeByName("SF決定音1");
        m_titleState = TitleState.Quit;
        ChangeTitleState(m_titleState);
        m_quitButton.Select();
    }
    void ChangeTitleState(TitleState state)
    {
        switch (state)
        {
            case TitleState.Start:
                if (m_startText) { m_startText.SetActive(true); }
                if (m_mainPanel) { m_mainPanel.SetActive(false); }
                if (m_audioPanel) { m_audioPanel.SetActive(false); }
                if (m_helpPanel) { m_helpPanel.SetActive(false); }
                if (m_quitPanel) { m_quitPanel.SetActive(false); }
                break;
            case TitleState.Main:
                if (m_startText) { m_startText.SetActive(false); }
                if (m_mainPanel) { m_mainPanel.SetActive(true); }
                if (m_audioPanel) { m_audioPanel.SetActive(false); }
                if (m_helpPanel) { m_helpPanel.SetActive(false); }
                if (m_quitPanel) { m_quitPanel.SetActive(false); }
                break;
            case TitleState.Audio:
                if (m_startText) { m_startText.SetActive(false); }
                if (m_mainPanel) { m_mainPanel.SetActive(false); }
                if (m_audioPanel) { m_audioPanel.SetActive(true); }
                if (m_helpPanel) { m_helpPanel.SetActive(false); }
                if (m_quitPanel) { m_quitPanel.SetActive(false); }
                break;
            case TitleState.Help:
                if (m_startText) { m_startText.SetActive(false); }
                if (m_mainPanel) { m_mainPanel.SetActive(false); }
                if (m_audioPanel) { m_audioPanel.SetActive(false); }
                if (m_helpPanel) { m_helpPanel.SetActive(true); }
                if (m_quitPanel) { m_quitPanel.SetActive(false); }
                break;
            case TitleState.Quit:
                if (m_startText) { m_startText.SetActive(false); }
                if (m_mainPanel) { m_mainPanel.SetActive(false); }
                if (m_audioPanel) { m_audioPanel.SetActive(false); }
                if (m_helpPanel) { m_helpPanel.SetActive(false); }
                if (m_quitPanel) { m_quitPanel.SetActive(true); }
                break;
        }
    }
}
