using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour, IActivable
{
    //[SerializeField] Transform rb;
    [SerializeField] ConstantForce cForce;
    [SerializeField] Vector3 forceDirection;

    public void OnActivated()
    {
        //Physics.gravity = new Vector3(0, -2.5f, 0);
        Debug.Log("Activé !");
        //rb.eulerAngles = new Vector3(0, 0, 180f);
        forceDirection = forceDirection * -1;
        cForce.force = forceDirection;

    }

    void Start()
    {
      
        forceDirection = new Vector3(0, -10, 0);
        cForce.force = forceDirection;
    }

    
}
