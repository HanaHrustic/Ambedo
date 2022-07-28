using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    public GameObject GreenScreen;
    public GameObject Door;
    int Timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerForCube")
        {
            Debug.Log("trigger");
            Timer++;
            if (Timer >= 10)
            {
                Debug.Log(Timer);
                GreenScreen.gameObject.SetActive(true);
                Door.GetComponent<DoorController>().canOpen = true;
            }
            else
            {
                Debug.Log(Timer);
            }
        }
    }
}
