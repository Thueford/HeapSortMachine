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
        Globals.SetStage(Globals.Stage.STAGE_1_1, "GameScene"); // TODO: will be intro
        //playClickSound();
    }

    public void btnExit_Click()
    {
        Debug.Log("Exit");
        //playClickSound();
        Application.Quit();
    }

    public void btnSettings_Click()
    {
        Debug.Log("Settings");
        //playClickSound();
    }
    public void btnCredits_Click()
    {
        Debug.Log("Credits");
        //playClickSound();
    }

    public void btnPause_Click()
    {
        Debug.Log("Pause");
        SceneManager.LoadScene("MainMenu"); // TODO: Pause menu
    }

    public void btnTipp_Click()
    {
        Debug.Log("Tipp");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: break;
            case Globals.Stage.STAGE_1_2: break;
            case Globals.Stage.STAGE_2_1: break;
            case Globals.Stage.STAGE_2_2: break;
            case Globals.Stage.STAGE_2_3: break;
        }
    }

    public void btnTest_Click()
    {
        Debug.Log("Test");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: LevelTests.Test_1_1(); break;
            case Globals.Stage.STAGE_1_2: LevelTests.Test_1_2(); break;
            case Globals.Stage.STAGE_2_1: LevelTests.Test_2_1(); break;
            case Globals.Stage.STAGE_2_2: LevelTests.Test_2_2(); break;
            case Globals.Stage.STAGE_2_3: LevelTests.Test_2_3(); break;
        }
    }

    public void btnAuto_Click()
    {
        Debug.Log("Auto");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: break;
            case Globals.Stage.STAGE_1_2: break;
            case Globals.Stage.STAGE_2_1: break;
            case Globals.Stage.STAGE_2_2: break;
            case Globals.Stage.STAGE_2_3: break;
        }
    }

    public void btnReset_Click()
    {
        Debug.Log("Reset");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: break;
            case Globals.Stage.STAGE_1_2: break;
            case Globals.Stage.STAGE_2_1: break;
            case Globals.Stage.STAGE_2_2: break;
            case Globals.Stage.STAGE_2_3: break;
        }
    }
    
    // not sure what tha purpose is
    public void btnMoveRight_Click()
    {
        Debug.Log("Move Right");
    }
    
    public void btnMoveLeft_Click()
    {
        Debug.Log("Move Left");
    }
}
