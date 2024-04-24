using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour, IActivable
{

    bool isActivated = true;
    [SerializeField] GameObject animatedObject;
    [SerializeField] AudioClip doorOpeningSound;
    [SerializeField] AudioSource audioSource;
    

    public void OnActivated()
    {

        if (GameManager.instance.currentUser.score >= 30 && isActivated == true)
        {
            isActivated = false;
            GameManager.instance.currentUser.score -= 30;
            IHM.instance.UpdateIHM();
            animatedObject.GetComponent<Animator>().Play("DoorOpen");
            audioSource.PlayOneShot(doorOpeningSound);


        }
        

    }

}
