using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverseCtrl : MonoBehaviour, IActivable
{

    [SerializeField] ConstantForce cForce;
    [SerializeField] Vector3 forceDirection;

    public void OnActivated()
    {

        Debug.Log("Activé !");

        forceDirection = forceDirection * -1;
        cForce.force = forceDirection;

    }

    void Start()
    {

        forceDirection = new Vector3(0, 10, 0);
        cForce.force = forceDirection;
    }
}
