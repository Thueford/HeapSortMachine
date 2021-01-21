using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public static ButtonHandler self;
    public Sprite sprHolderUp, sprHolderDown, sprHeapChk, sprHeapUnchk;
    public static bool autoButtonUsed = false;

    // Start is called before the first frame update
    void Awake()
    {
        self = this;
    }

    public void btnStart_Click()
    {
        Debug.Log("Tutorial1");
        Globals.SetStage(Globals.Stage.MENU, "TutorialScene1"); // TODO: will be intro
        //playClickSound();
    }

    public void btnNext1_Click()
    {
        Debug.Log("Tutorial2");
        Globals.SetStage(Globals.Stage.MENU, "TutorialScene2"); // TODO: will be intro
        //playClickSound();
    }

    public void btnNext2_Click()
    {
        Debug.Log("Tutorial3");
        Globals.SetStage(Globals.Stage.MENU, "TutorialScene3"); // TODO: will be intro
        //playClickSound();
    }

    public void btnNext3_Click()
    {
        Debug.Log("Start");
        Globals.SetStage(Globals.Stage.STAGE_1, "GameScene"); // TODO: will be intro
        //playClickSound();
    }

    public void btnExit_Click()
    {
        Debug.Log("Exit");
        // Globals.player.oneShot("click");
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

        Globals.player.oneShot("click");

        DialogueManager.setMecha(DialogueManager.self.sprExplain);
        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: Dialogue.Hilfe_1(); break;
            case Globals.Stage.STAGE_2: Dialogue.Hilfe_2(); break;
            case Globals.Stage.STAGE_3: Dialogue.Hilfe_3(); break;
            case Globals.Stage.STAGE_4: Dialogue.Hilfe_4(); break;
        }
    }
    public void btnTest_Click()
    {
        Debug.Log("Test");
        bool b = false;

        // Globals.player.oneShot("click");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: b = LevelTests.Test_1(); Dialogue.Test_1(b); break;
            case Globals.Stage.STAGE_2:
                //activate autobowlmovement
                if (!autoButtonUsed)
                {
                    b = LevelTests.Test_2();
                    Dialogue.Test_2(b);
                    if (b) {
                        autoButtonUsed = true;
                        BowlMover.autoMoveStart(() => {
                            StartCoroutine(Reset_Anim_Stage3());
                            autoButtonUsed = false;
                        });
                    }
                }
                break;
            case Globals.Stage.STAGE_3: b = LevelTests.Test_3(); Dialogue.Test_3(b); break;
            case Globals.Stage.STAGE_4: b = LevelTests.Test_4(); Dialogue.Test_4(b); break;
        }
        Globals.player.oneShot(b ? "right" : "wrong");
    }

    private static IEnumerator Reset_Anim_Stage3()
    {
        yield return new WaitForSeconds(1.5f);
        Reset.ResetBallsTo(Hole.LISTHOLE);
    }

    public void btnAuto_Click()
    {
        Debug.Log("Auto");

        Globals.player.oneShot("click");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: Dialogue.Auto_1(); break;
            case Globals.Stage.STAGE_2: Dialogue.Auto_2(); break;
            case Globals.Stage.STAGE_3: Dialogue.Auto_3(); break;
            case Globals.Stage.STAGE_4: Dialogue.Auto_4(); break;
        }

        if (!autoButtonUsed)
        {
            autoButtonUsed = true;
            BowlMover.autoMoveStart(null);
        }
    }

    public void btnReset_Click()
    {
        Debug.Log("Reset");

        Globals.player.oneShot("click");

        if (Bowl.moving.Count != 0) return;

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: Reset.Reset_1(); break;
            case Globals.Stage.STAGE_2: Reset.Reset_2(); break;
            case Globals.Stage.STAGE_3: Reset.Reset_3(); break;
            case Globals.Stage.STAGE_4: Reset.Reset_4(); break;
        }

        //activate auto button again
        autoButtonUsed = false;
    }

    public void btnHeapCheck_Click(BaseEventData ev)
    {
        if (Globals.stage != Globals.Stage.STAGE_3 && Globals.stage != Globals.Stage.STAGE_4) return;

        GameObject btn = ((PointerEventData)ev).pointerEnter;

        Match m = Regex.Match(btn.name, "\\((\\d+)\\)$");
        int n = int.Parse(m.Groups[1].Value);
        bool res = LevelTests.Test_3_Heapified(n);

        btn.GetComponent<Image>().sprite = res ? sprHeapChk : sprHeapUnchk;
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
