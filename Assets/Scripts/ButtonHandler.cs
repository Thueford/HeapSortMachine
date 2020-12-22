using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnStart_Click()
    {
        Debug.Log("Start");
        //playClickSound();
        //start game
        SceneManager.LoadScene("GameScene");
    }

    public void btnExit_Click()
    {
        Debug.Log("Exit");
        //playClickSound();
        //open skilltree
        Application.Quit();
    }

    public void btnPause_Click()
    {
        Debug.Log("Pause");
        SceneManager.LoadScene("MainMenu");
    }

    public void btnTipp_Click()
    {
        Debug.Log("Tipp");
    }

    public void btnTest_Click()
    {
        Debug.Log("Test");
    }

    public void btnAuto_Click()
    {
        Debug.Log("Auto");
    }
}
