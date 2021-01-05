using UnityEngine;
using UnityEngine.Assertions;

public class Globals : MonoBehaviour
{
    public Sprite[] bowlsNumbered;
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
}
