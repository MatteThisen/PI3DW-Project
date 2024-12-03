using UnityEngine;
using System.Collections;
using UnityEngine.VFX;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public bool toggleMouse = true;
    public Camera fpsCam;
    public float fireRateInSeconds = 0.1f;
    public bool shootingOnCooldown = false;
    public List<VisualEffect> muzzleFlashVFX = new List<VisualEffect>();
    public List<GameObject> muzzleLights = new List<GameObject>();
    public IEnumerator Shoot()
    {
        if (shootingOnCooldown)
        {
            yield break;
        }
        shootingOnCooldown = true;
        RaycastHit hit;
        foreach (VisualEffect vfx in muzzleFlashVFX)
        {
            vfx.Play();
        }
        foreach (GameObject light in muzzleLights)
        {
            light.SetActive(true);
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            AIEnemy enemyHealth = hit.transform.GetComponent<AIEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Enemy Health: " + enemyHealth.health);
            }

        }
        yield return new WaitForSeconds(fireRateInSeconds);
        shootingOnCooldown = false;
        foreach (VisualEffect vfx in muzzleFlashVFX)
        {
            vfx.Stop();
        }
        foreach (GameObject light in muzzleLights)
        {
            light.SetActive(false);
        }
    }

    void Start()
    {
        if(toggleMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }
    }
}