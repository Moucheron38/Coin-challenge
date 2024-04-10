using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    Transform targetPoint { get; }
    void OnDamage();

    void OnDeath();


}
