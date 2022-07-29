using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerController : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TriggerForWall")
        {
            foreach(Transform child in other.gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        
    }
}
