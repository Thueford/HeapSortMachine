using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Test : MonoBehaviour
{
    public static Json_Test json_test;
    // Start is called before the first frame update 

    void Start()
    {
        TextAsset json = Resources.Load<TextAsset>("mechnaniker");
        json_test = JsonUtility.FromJson<Json_Test>(json.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static Json_Test getJson()
    {
        return Json_Test.json_test;
    } 

    [System.Serializable]
    public struct Dialogwrapper
    {
        Stagewrapper level_description;
        Stagewrapper level_complete;
        Stagewrapper random_reactionn;
        Stagewrapper random_comments;
        Stagewrapper level_hints;
        Stagewrapper random_mistake;
        Stagewrapper random_success;
    }

    [System.Serializable]
    public struct Stagewrapper {
        Textwrapper stage_0;
        Textwrapper stage_1;
        Textwrapper stage_2;
        Textwrapper stage_3;
        Textwrapper stage_4;
    }

    [System.Serializable]
    public struct Textwrapper {
        string[] text;
        string emotion;
    }
}
