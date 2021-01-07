using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public enum Stage
    {
        MENU, INTRO, STAGE_1_1, STAGE_1_2,
        STAGE_2_1, STAGE_2_2, STAGE_2_3, END
    }

    public static Stage stage { get; private set; } = Stage.MENU;

    public Sprite[] bowlsBlank;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
