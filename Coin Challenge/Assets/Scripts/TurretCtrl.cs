using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    private IDamageable player;
    [SerializeField] Transform headParent;
    [SerializeField] Transform meshParent;
    private Coroutine curCorout;
    [SerializeField] Transform rayCastStartPoint;
    RaycastHit hitInfo;
    [SerializeField] float minHeight, maxHeight;
    //[SerializeField] GameObject debugGO;
    [SerializeField] Collider triggerCollider;
    [SerializeField] float timer;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;
    [SerializeField] float vitesse;
    private bool playerOnSight;
    [SerializeField] float shootDelay = 1;
    public float noPlayerDelay = 0;
    [SerializeField] LayerMask raycastMask;

    private void Start()
    {
        meshParent.localPosition = new Vector3(0, minHeight, 0);
        hitInfo = new RaycastHit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (curCorout != null) return;

        player = other.gameObject.GetComponent<IDamageable>();
        curCorout = StartCoroutine(TurretCorout());


    }

    IEnumerator TurretCorout()
    {
        Coroutine shootCorout = null;
        triggerCollider.enabled = false;
        yield return StartCoroutine(AwakeCorout(true));
        noPlayerDelay = 0;
        
        


        while (player != null && noPlayerDelay < 5)
        {
            playerOnSight = PlayerOnSight();
            if (!playerOnSight)
            {
                noPlayerDelay += Time.deltaTime;
                
                if (shootCorout != null && noPlayerDelay > 0.8f)
                {
                    StopCoroutine(shootCorout);
                    shootCorout = null;

                }

            }

            else 
            {
                noPlayerDelay = 0;

                if (shootCorout == null)
                    shootCorout = StartCoroutine(ShootCorout());


            }

            headParent.LookAt(player.targetPoint);



            yield return null;
        }
        yield return StartCoroutine(AwakeCorout(false));
        curCorout = null;
        triggerCollider.enabled = true;
    }

    IEnumerator AwakeCorout(bool goUp)
    {
        Vector3 startPos = new Vector3(0, goUp ? minHeight : maxHeight, 0);
        Vector3 targetPos = new Vector3(0, goUp ? maxHeight : minHeight, 0);

        if (goUp) headParent.transform.rotation = Quaternion.identity;

        float t = 0;

        while (t < 1.1f)
        {
            t += Time.deltaTime * 0.5f;
            meshParent.localPosition = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }


        meshParent.localPosition = targetPos;
    }

    private bool PlayerOnSight()
    {

        Physics.Raycast(rayCastStartPoint.position, headParent.forward, out hitInfo, 50, raycastMask);

        Debug.DrawRay(rayCastStartPoint.position, headParent.forward * 50);

        if (hitInfo.collider == null) return false;

        //debugGO.transform.position = hitInfo.point;

        return hitInfo.collider.CompareTag("Player");
    }

    private void Shoot()
    {

        GameObject bulletGO = Instantiate(bullet, canon.transform.position, canon.transform.rotation) as GameObject;
        Rigidbody rb = bulletGO.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.up * vitesse);
        Destroy(bulletGO, 5f);
    }

    IEnumerator ShootCorout()
    {
        float t = 0;

        while (t < 4)
        {
            t += Time.deltaTime;
            yield return null;
        }

        while (true)
        {

            Shoot();

            t = 0;

            while (t < shootDelay)
            {
                t += Time.deltaTime;
                yield return null;
            }

            yield return null;
        }
    }
}
