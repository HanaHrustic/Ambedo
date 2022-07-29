using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    public GameObject GreenScreen;
    public GameObject Door;
    int Timer = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "TriggerForCube")
        {
            Timer++;
            if (Timer >= 10)
            {
                GreenScreen.gameObject.SetActive(true);
                Door.GetComponent<DoorController>().canOpen = true;
            }
        }
    }
}
