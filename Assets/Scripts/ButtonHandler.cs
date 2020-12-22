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
        //playClickSound();
        //start game
        SceneManager.LoadScene("GameScene");
    }

    public void btnExit_Click()
    {
        //playClickSound();
        //open skilltree
        Application.Quit();
    }

    public void btnPause_Click()
    {
    }

    public void btnTipp_Click()
    {
    }

    public void btnTest_Click()
    {
    }
    public void btnAuto_Click()
    {
    }
}
