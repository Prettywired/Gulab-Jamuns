using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Condition : MonoBehaviour
{
    [SerializeField] GameObject sprites;
    int stars = 3;
    public GameObject obj;
    [SerializeField] DestinationTrigger dest;

    void Update()
    {
        // Debug.Log("condition" + dest.GetSuccess());
        if (dest.GetSuccess())
        {
            sprites.SetActive(false);
            obj.SetActive(true);
        }
    }

}
