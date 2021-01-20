using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Test 
{
    public static Dialogwrapper json_test;
    // Start is called before the first frame update 

    public static void Start()
    {
        TextAsset json = Resources.Load<TextAsset>("mechaniker");
        json_test = JsonUtility.FromJson<Dialogwrapper>(json.text);
        Debug.Log(json.text);
        Debug.Log(json_test);
    }

    [System.Serializable]
    public class Dialogwrapper
    {
        public Stagewrapper level_description;
        public Stagewrapper level_complete;
        public Stagewrapper random_reactionn;
        public Stagewrapper random_comments;
        public Stagewrapper level_hints;
        public Textwrapper random_mistake;
        public Textwrapper random_success;
    }

    [System.Serializable]
    public class  Stagewrapper {
        public Textwrapper stage_1;
        public Textwrapper stage_2;
        public Textwrapper stage_3;
        public Textwrapper stage_4;
    }

    [System.Serializable]
    public class Textwrapper {
        public string[] text;
        public string emotion;
    }
}
