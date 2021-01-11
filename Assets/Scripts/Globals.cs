using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Globals : MonoBehaviour
{
    public static Globals globals;
    public enum Stage
    {
        MENU, INTRO, STAGE_1_1, STAGE_1_2,
        STAGE_2_1, STAGE_2_2, STAGE_2_3, END
    }

    public static Stage stage { get; private set; } = Stage.MENU;

    public Sprite[] bowlsBlank;
    public static List<GameObject> bowls = new List<GameObject>();
    public static int bowlCount = 15;

    public GameObject bowlPrefab;
    public GameObject bowlHolder;
    public GameObject bowlTextPrefab;

    private void Awake()
    {
        if(!globals)
        {
            globals = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawns bowls
        ballSpawner();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ballSpawner()
    {
        int value_counter = 0;
        foreach (Hole hole in Hole.getHoles())
        {
            if (!hole.tree)
            {
                hole.free = false;
                Vector3 hole_pos = hole.transform.position;
                hole_pos.z = 5;
                GameObject bowl = Instantiate(bowlPrefab, hole_pos, Quaternion.identity);
                bowl.GetComponent<Bowl>().value = value_counter;
                bowl.transform.SetParent(bowlHolder.transform);
                //textSpawner(bowl);
                bowls.Add(bowl);

                value_counter++;
            }
        }
    }

    public void textSpawner(GameObject bowl)
    {
        Vector3 bowl_pos = bowl.transform.position;
        bowl_pos.z -= 1;
        GameObject txt = Instantiate(bowlTextPrefab, bowl_pos, Quaternion.identity);
        txt.transform.SetParent(bowl.transform);
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
            case Stage.STAGE_1_1: break;
            case Stage.STAGE_1_2: break;
            case Stage.STAGE_2_1: break;
            case Stage.STAGE_2_2:  break;
            case Stage.STAGE_2_3: break;
            case Stage.END: break;
        }
    }
}
