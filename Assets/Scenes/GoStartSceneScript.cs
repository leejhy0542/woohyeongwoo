using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoStartSceneScript : MonoBehaviour
{
    public Button QuitBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        QuitBtn.onClick.AddListener(GoStart);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
