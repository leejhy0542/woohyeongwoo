using JetBrains.Annotations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScenceScript : MonoBehaviour
{
    public Button StartBtn;
    public Button HowToBtn;
    public Button SettingsBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartBtn = GameObject.Find("StartBtn").GetComponent<Button>();
        HowToBtn = GameObject.Find("HowToBtn").GetComponent<Button>();
        SettingsBtn = GameObject.Find("SettingsBtn").GetComponent<Button>();
        StartBtn.onClick.AddListener(StartGame);
        HowToBtn.onClick.AddListener(HowToPlay);
        SettingsBtn.onClick.AddListener(Settings);
    }

    // Update is called once per frame
    void Update()
    {
        // if (StartBtn.onClick != null)
        // {
        //     SceneManager.LoadScene("StageScene");
        //     StartBtn.onClick = null; // Prevent multiple clicks
        // }
        // if (HowToBtn.onClick != null)
        // {
        //     SceneManager.LoadScene("HowToScene");
        //     HowToBtn.onClick = null; // Prevent multiple clicks
        // }
        // if (SettingsBtn.onClick != null)
        // {
        //     SceneManager.LoadScene("SettingsScene");
        //     SettingsBtn.onClick = null; // Prevent multiple clicks
        // }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
