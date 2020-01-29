using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class PlayerControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float maxPosX, maxPosY, velocity, shootCD, shoot_speed;
    private float posX, posY;
    private EZObjectPool bulletsPool;
    private float lastTimeShoot;


    void Start()
    {
        Inicialice();
    }

    void Inicialice()
    {
        bulletsPool = EZObjectPool.CreateObjectPool(bulletPrefab, "Player Bullets", 10, true, true, false);
    }

    void Update()
    {
        Control();
    }

    void Control()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > lastTimeShoot + shootCD) Shoot();
        Movement();
    }

    void Movement()
    {
        float inputX = posX + Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
        float inputY = posY + Input.GetAxis("Vertical") * Time.deltaTime * velocity;
        posX = Mathf.Clamp(inputX, -maxPosX, maxPosX);
        posY = Mathf.Clamp(inputY, -maxPosY, maxPosY);
        transform.position = new Vector3(posX, posY, 0);
        transform.rotation = Quaternion.Lerp
        (
            transform.rotation,
            Quaternion.Euler(-Input.GetAxis("Vertical") * maxPosY / 2, 0, -Input.GetAxis("Horizontal") * maxPosX / 2),
            Time.deltaTime * velocity / 2
        );
    }

    void Shoot()
    {
        if (bulletsPool.TryGetNextObject(transform.position + Vector3.down * 1.5f, transform.rotation, out GameObject shootGO))
        {
            shootGO.GetComponent<Rigidbody>().velocity = transform.forward * shoot_speed;
            lastTimeShoot = Time.time;
        }
    }

}
