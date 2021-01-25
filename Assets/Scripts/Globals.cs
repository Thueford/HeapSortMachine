using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;

public class Globals : MonoBehaviour
{
    public static Globals globals;

    public static Stage stage { get; private set; } = Stage.MENU;
    public static List<Ball> balls = new List<Ball>();
    public static List<Hole> holes = new List<Hole>();
    public static List<Joint> joints = new List<Joint>();
    public static int ballCount = 15;
    public static UnityEngine.Random ran = new UnityEngine.Random();
    public static SoundHandler player;
    private static bool stageTransition = false;

    public Button[] heapChkBtns;
    public GameObject[] toMoveZ;
    public Sprite[] ballsBlank;
    public Sprite[] holeSprites;
    public Sprite[] jointSprites;

    public Stage startStage;
    public Stage rdonlyStage;
    public GameObject ballPrefab;
    public GameObject ballHolder;
    public GameObject ballTextPrefab;
    public GameObject checkpointHolder;

    public enum Stage
    {
        NONE, MENU, INTRO, STAGE_1, STAGE_2,
        STAGE_3, STAGE_4, END
    }

    private void Awake()
    {
        Debug.Log("Awake");
        stage = startStage;
        if (!globals) globals = this;
        player = gameObject.GetComponent<SoundHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawns balls
        ballSpawner();
        balls.Sort((a, b) => a.index < b.index ? -1 : 1);
        holes.Sort((a, b) => a.value < b.value ? -1 : 1);
        // SetStage(Stage.STAGE_1);
        SetStage(stage);

        //testing
        //balls[1].move(Checkpoint.checkpoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (stageTransition && Ball.moving.Count == 0) {
            stageTransition = false;
            ButtonHandler.buttonsActive = true;
            switch (stage)
            {
                case Stage.MENU: break;
                case Stage.INTRO: break;
                case Stage.STAGE_1: Reset.ResetBallsTo(Hole.LISTHOLE); break;
                case Stage.STAGE_2: Reset.ResetBallsTo(Hole.LISTHOLE); Ball.staticDnDEnable = false; break;
                case Stage.STAGE_3: Reset.ResetBallsTo(Hole.TREEHOLE); Ball.staticDnDEnable = false; Ball.masterSwap = true; break;
                case Stage.STAGE_4: Reset.ResetBallsHeapifiedTo(Hole.TREEHOLE); Ball.staticDnDEnable = false; Ball.masterSwap = true; break;
                case Stage.END: break;
            }
        }
    }

    public void ballSpawner()
    {
        int cnt = 0;
        List<int> values = new List<int>(Enumerable.Range(0, ballCount));
        // values.Sort((a, b) => Random.Range(-1, 1));

        //Source: https://stackoverflow.com/questions/273313/randomize-a-listt
        //truly random order of balls

        var provider = new RNGCryptoServiceProvider();
        int n = values.Count;
        while (n > 1)
        {
            var box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            var k = (box[0] % n);
            n--;
            var value = values[k];
            values[k] = values[n];
            values[n] = value;
        }

        foreach (Hole h in getHoles(Hole.LISTHOLE))
        {
            //h.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            balls.Add(Ball.spawn(h.value, values[cnt], h.transform.position));
            cnt++;
        }
    }

    public static List<Hole> getHoles(string parentName)
    {
        return holes.FindAll(h => h.isType(parentName));
    }

    public static void SetStage(Stage s, string loadScene = null)
    {
        if(s < Stage.MENU || s > Stage.END)
        {
            loadScene = "MainMenu";
            s = Stage.MENU;
        }

        Debug.Log("SetStage: " + s);
        if (loadScene != null)
        {
            balls.Clear();
            holes.Clear();
            SceneManager.LoadScene(loadScene);
            Debug.Log("SetStage " + s + " Afterload");
        }
        globals.rdonlyStage = stage = s;
        stageTransition = true;
    }
}
