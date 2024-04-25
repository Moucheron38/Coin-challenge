using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerSystem : MonoBehaviour, IDamageable
{
    [SerializeField] LifeSystem lifeSystem;
    [SerializeField] Gradient lifeGradient;
    [SerializeField] Transform damagePoint;
    [SerializeField] GameObject playerGO;
    [SerializeField] TextMeshProUGUI textLife;
    [SerializeField] Image lifeBar;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioSource audiosource;
    public Transform targetPoint { get { return damagePoint; } }

    private void Start()
    {
        UpdatePlayerLifeVisual();
    }

    public void OnDamage()
    {
       // IHM.instance.UpdateLife(lifeSystem);
        UpdatePlayerLifeVisual();
        audiosource.PlayOneShot(damageSound);
        
    }

    public void OnDeath()
    {
       // IHM.instance.UpdateLife(lifeSystem);
        

        //Implémenter le restart et le freeze du jeu

        GameManager.instance.EndGame();

    }

    public void UpdatePlayerLifeVisual()
    {
        lifeBar.fillAmount = lifeSystem.lifeRate;
        lifeBar.color = lifeGradient.Evaluate(lifeSystem.lifeRate);
        //textLife.text = lifeSystem.life.ToString();
        //textLife.color = lifeGradient.Evaluate(lifeSystem.lifeRate);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            LifeSystem lifeSystem = playerGO.gameObject.GetComponent<LifeSystem>();
            lifeSystem.SetDamage(1);
        }
    }


}
