using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public IDamageable _IKillable;
    public int life;
    public int maxLife;
    public float lifeRate
    {
        get
        {
            return (float)life / (float)maxLife;
        }
    }
    public bool isAlive
    {
        get
        {
            return life > 0;
        }
    }



    private void Awake()
    {
        _IKillable = GetComponent<IDamageable>();
        if (_IKillable == null) Debug.LogError("L'interface IKillable n'a pas été trouvée sur le GameObject " + gameObject.name);
        life = maxLife;
    }

    public void SetDamage(int damage)
    {
        life -= damage;

        if (!isAlive)
        {
            life = 0;
            _IKillable.OnDeath();
        }

        else _IKillable.OnDamage();


    }

}
