using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Test 
{
    public static Dialogwrapper Load()
    {
        TextAsset json = Resources.Load<TextAsset>("mechaniker");
        return JsonUtility.FromJson<Dialogwrapper>(json.text);
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
        public Reactionwrapper reaction_from_3;
    }

    [System.Serializable]
    public class  Stagewrapper {
        public Textwrapper stage_1;
        public Textwrapper stage_2;
        public Textwrapper stage_3;
        public Textwrapper stage_4;
    }

    [System.Serializable]
    public class Reactionwrapper
    {
        public Textwrapper heap_destroy;
        public Textwrapper not_last_subtree;
        public Textwrapper change_little_one;
        public Textwrapper first_change;
        public Textwrapper reason_why_efficient;
    }

    [System.Serializable]
    public class Textwrapper {
        public string[] text;
        public string emotion;
    }
}
