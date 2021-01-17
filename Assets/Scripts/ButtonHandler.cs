using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
   
    public static ButtonHandler self;
    public Sprite sprHolderUp, sprHolderDown;
    public Dialogue dialogue;
  
   

    // Start is called before the first frame update
    void Awake()
    {
        self = this;
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
        Globals.SetStage(Globals.Stage.MENU, "CreditScene");
        //playClickSound();
    }

    public void btnPause_Click()
    {
        Debug.Log("Pause");
        Globals.SetStage(Globals.Stage.MENU, "MainMenu"); // TODO: Pause menu
    }

    public void btnMain_Click()
    {
        Debug.Log("Main");
        Globals.SetStage(Globals.Stage.MENU, "MainMenu"); // TODO: Pause menu
    }

    public void btnTipp_Click()
    {
        Debug.Log("Tipp");
       
        
        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: Dialogue.Hilfe1_1(); break;
            case Globals.Stage.STAGE_1_2: Dialogue.Hilfe1_2(); break;
            case Globals.Stage.STAGE_2_1: Dialogue.Hilfe2_1(); break;
            case Globals.Stage.STAGE_2_2: Dialogue.Hilfe2_2(); break;
            case Globals.Stage.STAGE_2_3: Dialogue.Hilfe2_3(); break;
        }
    }
    public void btnTest_Click()
    {
        Debug.Log("Test");
        bool b;
        Dialogue.Test_1_1(true);
        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1:
                b = LevelTests.Test_1_1(); Dialogue.Test_1_1(b); break;
            case Globals.Stage.STAGE_1_2:
                b = LevelTests.Test_1_2(); Dialogue.Test_1_2(b); break;
            case Globals.Stage.STAGE_2_1:
                b = LevelTests.Test_2_1(); Dialogue.Test_2_1(b); break;
            case Globals.Stage.STAGE_2_2:
                b = LevelTests.Test_2_2(); Dialogue.Test_2_2(b); break;
            case Globals.Stage.STAGE_2_3:
                b = LevelTests.Test_2_3(); Dialogue.Test_2_3(b); break;
        }
    }

    public void btnAuto_Click()
    {
        Debug.Log("Auto");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1_1: Dialogue.Auto_1_1(); break;
            case Globals.Stage.STAGE_1_2: Dialogue.Auto_1_2(); break;
            case Globals.Stage.STAGE_2_1: Dialogue.Auto_2_1(); break;
            case Globals.Stage.STAGE_2_2: Dialogue.Auto_2_2(); break;
            case Globals.Stage.STAGE_2_3: Dialogue.Auto_2_3(); break;
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

    public void OnMouseEnter(BaseEventData ev)
    {
        throw new System.Exception("UR A FAILURE");
    }

    public void OnMouseExit(BaseEventData ev)
    {
        throw new System.Exception("UR A FAILURE");
    }
}
