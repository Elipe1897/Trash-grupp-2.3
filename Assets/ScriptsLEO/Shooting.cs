using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public int Ammo;
    public bool Reloading;
    public float DMG = 5;

    public GameObject Bullet;
    public GameObject FireEffect;

    public GameObject FirePoint;

    public Text AmmoText;
    public void Start()
    {
        Ammo = 30;
        AmmoText.text = Ammo.ToString() + "/30"; 
    }


    public void Update()
    {
        //Follow Mouse
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        //Reload
        if (Ammo == 0 && (Input.GetKeyDown(KeyCode.R)))
        {
            StartCoroutine(ReloadingTrue());
        }



        //Shoots
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Ammo > 0 && Reloading == false)
            {
                Ammo--;
                GameObject bullet = Instantiate(Bullet, new Vector3(FirePoint.transform.position.x, FirePoint.transform.position.y), FirePoint.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
                Debug.Log("FIRE!");
                Instantiate(FireEffect, FirePoint.transform.position, Quaternion.identity);
                Debug.Log("Effect!");
                StartCoroutine(RecoilTrue());
                Debug.Log("Recoil!");
                AmmoText.text = Ammo.ToString() + "/30";
            }

        }
    }

    public IEnumerator RecoilTrue()
    {
        transform.position += new Vector3(-20, 0) * Time.deltaTime;
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(20, 0) * Time.deltaTime;
    }
    public IEnumerator ReloadingTrue()
    {
        Ammo = 30;
        AmmoText.text = Ammo.ToString() + "/30";
        Reloading = true;
        yield return new WaitForSeconds(1f);
        Reloading = false;
    }
}