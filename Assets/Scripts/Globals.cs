using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Globals : MonoBehaviour
{
    public static Globals globals;

    public static Stage stage { get; private set; } = Stage.MENU;
    public static List<Bowl> bowls = new List<Bowl>();
    public static List<Hole> holes = new List<Hole>();
    public static int bowlCount = 15;
    public static Random ran = new Random();
    public static SoundHandler player;

    public GameObject[] toMoveZ;
    public Sprite[] bowlsBlank;
    public Sprite[] holeSprites;

    public Stage startStage;
    public GameObject bowlPrefab;
    public GameObject bowlHolder;
    public GameObject bowlTextPrefab;
    public GameObject checkpointHolder;

    public enum Stage
    {
        MENU, INTRO, STAGE_1, STAGE_2,
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
        //spawns bowls
        ballSpawner();
        SetStage(Stage.STAGE_1);

        //testing
        //bowls[1].move(Checkpoint.checkpoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ballSpawner()
    {
        int cnt;
        List<int> values = new List<int>(Enumerable.Range(0, bowlCount));
        values.Sort((a, b) => Random.Range(-1, 1));
        cnt = 0;

        foreach (Hole h in getHoles(Hole.LISTHOLE))
        {
            //h.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bowls.Add(Bowl.spawn(h.value, values[cnt], Bowl.setVecZ(h.transform.position, 5)));
            cnt++;
        }
    }

    public static List<Hole> getHoles(string parentName)
    {
        return holes.FindAll(h => h.transform.parent.name == parentName);
    }

    public static void SetStage(Stage s, string loadScene = null)
    {
        if(s < Stage.MENU || s > Stage.END)
        {
            loadScene = "MainMenu";
            s = Stage.MENU;
        }
        
        if (loadScene != null)
        {
            bowls.Clear();
            holes.Clear();
            SceneManager.LoadScene(loadScene);
        }

        // dunno if this will be needed sometime
        switch (stage = s)
        {
            case Stage.MENU: break;
            case Stage.INTRO: break;
            case Stage.STAGE_1: break;
            case Stage.STAGE_2: break;
            case Stage.STAGE_3: break;
            case Stage.STAGE_4:break;
            case Stage.END: break;
        }
    }
}
