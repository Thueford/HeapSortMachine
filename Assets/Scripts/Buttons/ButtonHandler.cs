﻿using System;
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
    public static bool buttonsActive = true;
    public Texture2D crsr1, crsr2;
    private static Texture2D csr1, csr2;

    public static void setCursor(bool onBtn)
    {
        Texture2D t = onBtn ? csr1 : csr2;
        if (t) Cursor.SetCursor(t, Vector2.zero, CursorMode.Auto);
    }

    // Start is called before the first frame update
    void Awake()
    {
        self = this;
    }

    public void Start()
    {
        if (!csr1) csr1 = crsr1;
        if (!csr2) csr2 = crsr2;
    }

    public void btnStart_Click()
    {
        Debug.Log("Stages");
        Globals.SetStage(Globals.Stage.MENU, "StageScene"); // TODO: will be intro
        //playClickSound();
    }

    public void btnIntro_Click()
    {
        Debug.Log("Tutorial1");
        Globals.SetStage(Globals.Stage.MENU, "TutorialScene1"); // TODO: will be intro
        //playClickSound();
    }

    public void btnTree_Click()
    {
        Debug.Log("Tree");
        Globals.SetStage(Globals.Stage.STAGE_1, "GameScene");
    }
    public void btnHeap_Click()
    {
        Debug.Log("Heap");
        Globals.SetStage(Globals.Stage.STAGE_3, "GameScene");
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
        if (!buttonsActive) return; //during auto/stage change
        Debug.Log("Tipp");

        Globals.player.oneShot("click");

        //DialogueManager.setMecha(DialogueManager.self.sprExplain);
        DialogueManager.setMecha(Dialogue.json.level_hints.stage_1.emotion);
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
        if (!buttonsActive) return; //during auto/stage change
        Debug.Log("Test");
        bool b = false;

        // Globals.player.oneShot("click");

        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: b = LevelTests.Test_1(); Dialogue.Test_1(b); break;
            case Globals.Stage.STAGE_2:
                //activate autoballmovement
                if (!autoButtonUsed)
                {
                    b = LevelTests.Test_2();
                    Dialogue.Test_2(b);
                    if (b) {
                        autoButtonUsed = true;
                        BallMover.autoMoveInit( () => autoButtonUsed = false );
                        Globals.player.startRolling();
                    }
                }
                break;
            case Globals.Stage.STAGE_3: b = LevelTests.Test_3(); Dialogue.Test_3(b); break;
            case Globals.Stage.STAGE_4: {
                b = LevelTests.Test_4();
                Hole hl = Hole.getLastNonEmpty();
                Dialogue.Test_4(b, hl ? hl.index : 0);
                Debug.Log(b);
                if (b) {

                    //TODO: Automove

                    Ball.swapTwo(Globals.getHoles(Hole.TREEHOLE).Find(fh => 0 == fh.index).content, hl.content);
                    //hl.content.moveToHole(Globals.getHoles(Hole.SORTHOLE).Find(fh => hl.value == 14-fh.value));
                    BallMover.moveToSortedList(hl.content, Globals.getHoles(Hole.SORTHOLE).Find(fh => hl.index == 14 - fh.index));
                    Globals.player.startRolling();
                    //After automove
                    hl.content = null;
                    LevelTests.Test_4();
                    Reset.createHeapReset();
                }
                break;
            }
        }
        buttonsActive = !b || Globals.stage == Globals.Stage.STAGE_4;
        Globals.player.oneShot(b ? "right" : "wrong");
    }

    public void btnAuto_Click()
    {
        if (!buttonsActive) return; //during auto/stage change
        Debug.Log("Auto");
        Globals.player.oneShot("click");
        //DialogueManager.setMecha(DialogueManager.self.sprSceptic);
        DialogueManager.setMecha(Dialogue.json.emotion.sceptic);
        switch (Globals.stage)
        {
            case Globals.Stage.STAGE_1: Dialogue.Auto_1(); break;
            case Globals.Stage.STAGE_2: Dialogue.Auto_2(); break;
            case Globals.Stage.STAGE_3: Dialogue.Auto_3(); break;
            case Globals.Stage.STAGE_4: Dialogue.Auto_4(); break;
        }

        if (!autoButtonUsed)
            autoButtonUsed = BallMover.autoMoveInit(() => autoButtonUsed = false);
    }

    public void btnReset_Click()
    {
        if (!buttonsActive) return; //during auto/stage change
        Debug.Log("Reset");
        Globals.player.oneShot("click");
        if (Ball.moving.Count != 0) return;

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

    public void btnOutro_Click()
    {
        Debug.Log("Test Outro");
        Dialogue.Outro();
    }

    public void btnHeapCheck_Click(BaseEventData ev)
    {
        if (Globals.stage != Globals.Stage.STAGE_3 && Globals.stage != Globals.Stage.STAGE_4) return;
        GameObject btn = ((PointerEventData)ev).pointerEnter;
        if (btn == null) btn = Button.getLast(ev);
        Debug.Log(btn);

        Match m = Regex.Match(btn.name, "\\((\\d+)\\)$");
        int n = int.Parse(m.Groups[1].Value);

        if (n != HeapTests.currentHeap) {
            Debug.Log("That heap is currently not active");
            Dialogue.notLastSubtree();
            return;
        }

        bool res = LevelTests.Test_Heapified(n);
        btn.GetComponent<Image>().sprite = res ? sprHeapChk : sprHeapUnchk;
        if (HeapTests.currentHeap == -1) {btnTest_Click(); return;}
        Globals.player.oneShot(res ? "right" : "wrong");
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
