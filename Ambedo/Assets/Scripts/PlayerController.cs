using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float Speed = 6.0f;
    public float JumpSpeed = 8.0f;
    public float Gravity = 20.0f;
    public Camera Cam;
    public GameObject Cube;
    public GameObject Cube2DUp;
    public GameObject Cube2DDown;
    int Timer = 0;


    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = Cam.transform.right * Input.GetAxis("Horizontal") + Cam.transform.forward * Input.GetAxis("Vertical");
            moveDirection *= Speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = JumpSpeed;
            }
        }
        moveDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "Door" && !hit.transform.gameObject.GetComponent<DoorController>())
                {
                    hit.transform.gameObject.GetComponent<Animator>().Play("glass_door_open", 0, 0.0f);
                }
                else if (hit.transform.gameObject.tag == "Door" && hit.transform.gameObject.GetComponent<DoorController>().canOpen)
                {
                    hit.transform.gameObject.GetComponent<Animator>().Play("glass_door_open", 0, 0.0f);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "TriggerForCube")
        {
            Timer++;
            if (Timer >= 100)
            {
                Debug.Log(Timer);
                Cube2DDown.GetComponent<SpriteRenderer>().enabled = false;
                Cube2DUp.GetComponent<SpriteRenderer>().enabled = false;
                Cube.SetActive(true);
            }
            else
            {
                Debug.Log(Timer);
            }
        }
    }
}