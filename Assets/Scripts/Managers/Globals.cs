using UnityEngine;

public class Globals : MonoBehaviour
{

    public static bool DEBUG_MODE = true;

    private void Start()
    {
        if(DEBUG_MODE) Debug.Log($"DEBUG MODE IS ON!");
    }
}
