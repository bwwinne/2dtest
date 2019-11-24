using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootBullets : NetworkBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
        }
        if (this.isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("shoot");
            this.CmdShoot();
        }
    }

    [Command]
    void CmdShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 1.0f);
    }
}