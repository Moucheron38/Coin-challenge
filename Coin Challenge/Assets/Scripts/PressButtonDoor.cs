using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonDoor : MonoBehaviour
{

    [SerializeField] GameObject instruction;
    [SerializeField] GameObject animatedObject;
    [SerializeField] GameObject thisButton;
    [SerializeField] GameObject gg;
    bool action = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            instruction.SetActive(true);
            action = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instruction.SetActive(false);
        action = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (action == true)
            {
                instruction.SetActive(false);
                animatedObject.GetComponent<Animator>().Play("DoorOpen");
                thisButton.SetActive(false);
                action = false;
                gg.SetActive(true);

            }
        }
    }
}
