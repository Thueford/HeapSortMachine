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

    public Sprite[] bowlsBlank;

    public Stage startStage;
    public GameObject bowlPrefab;
    public GameObject bowlHolder;
    public GameObject bowlTextPrefab;

    public enum Stage
    {
        MENU, INTRO, STAGE_1_1, STAGE_1_2,
        STAGE_2_1, STAGE_2_2, STAGE_2_3, END
    }

    private void Awake()
    {
        stage = startStage;
        if (!globals) globals = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawns bowls
        if (stage == Stage.STAGE_1_1) ballSpawner();
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

        foreach (Hole hole in holes)
        {
            if (!hole.tree)
            {
                hole.free = false;
                hole.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Vector3 hole_pos = hole.transform.position;
                hole_pos.z = 5;
                Bowl bowl = Bowl.spawn(hole.getHoleValue(), values[cnt], hole_pos);
                bowls.Add(bowl);
                cnt++;
                
            }
        }
        
    }

    public static GameObject TryGetObjWithTag(string tag)
    {
        GameObject o = GameObject.FindGameObjectWithTag(tag);
        if (o == null) throw new AssertionException("o == null", "Object with tag '" + tag + "' not found.");
        return o;
    }

    public static void SetStage(Stage s, string loadScene = null)
    {
        if(s < Stage.MENU || s > Stage.END)
        {
            loadScene = "MainMenu";
            s = Stage.MENU;
        }

        if (loadScene != null) SceneManager.LoadScene(loadScene);

        // dunno if this will be needed sometime
        switch (stage = s)
        {
            case Stage.MENU: break;
            case Stage.INTRO: break;
            case Stage.STAGE_1_1:
                if(loadScene != null) {
                    bowls.Clear();
                    holes.Clear();
                }
                break;
            case Stage.STAGE_1_2: break;
            case Stage.STAGE_2_1: break;
            case Stage.STAGE_2_2: break;
            case Stage.STAGE_2_3: break;
            case Stage.END: break;
        }
    }
}
