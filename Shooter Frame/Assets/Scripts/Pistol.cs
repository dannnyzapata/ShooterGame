using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;

    //DamageEnemy
    [SerializeField]
    float damageEnemy = 10f;

    [SerializeField]
    Transform ShootPoint;

    [SerializeField]
    int currentAmmo;
    //Muzzle
    public ParticleSystem muzzleFlash;
    public ParticleSystem saveRay;
    //disparo Sonido
    AudioSource gunAS;
    public AudioClip shootAC;

    //UI
    public Text ammocount; 

    //Rate of Fire
    [SerializeField]
    float rateOfFire;
    float nextFire = 0;

    [SerializeField]
    float weaponRange;

    private void Start()
    {
        muzzleFlash.Stop();
        gunAS = GetComponent<AudioSource>();
        saveRay.Stop();



    }

    private void Update()
    {
        ammocount.text = currentAmmo.ToString();
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }

        if (Input.GetButton("Fire2"))
        {
            Save();
        }
    }

    void Shoot()
    {

        if (Time.time > nextFire)
        {
            currentAmmo--;
            gunAS.PlayOneShot(shootAC);
            nextFire = Time.time + rateOfFire;
            StartCoroutine(WeaponEffects());

            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit))
            {
                if (hit.transform.tag == "Enemy")
                {
                    //Debug.Log("Hit Enemy");

                    EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                    enemyHealthScript.DeductHealth(damageEnemy);
                }

                else
                {
                    Debug.Log("Hit Something Else");
                }
            }

        }

        

    }

    void Save()
    {

        if (Time.time > nextFire)
        {
            
            gunAS.PlayOneShot(shootAC);
            nextFire = Time.time + rateOfFire;
            StartCoroutine(SaveEffect());

            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit))
            {
                if (hit.transform.tag == "Civilian")
                {
                    //Debug.Log("Hit Enemy");

                    CivScript SaveCiv = hit.transform.GetComponent<CivScript>();
                    SaveCiv.SaveCiv(damageEnemy);
                }

                else
                {
                    Debug.Log("Hit Something Else");
                }
            }

        }



    }

    IEnumerator WeaponEffects()
    {
        muzzleFlash.Play();
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();

    }

    IEnumerator SaveEffect()
    {
        saveRay.Play();
        yield return new WaitForEndOfFrame();
        saveRay.Stop();

    }


}
