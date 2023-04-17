using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // prefab da bala
    public float fireRate = 0.5f; // taxa de disparo em segundos
    private float nextFireTime = 0f; // momento em que a arma pode disparar novamente

    void Update()
    {
        if (Time.time >= nextFireTime) // verifica se a arma pode disparar novamente
        {
            nextFireTime = Time.time + fireRate; // define o próximo momento em que a arma pode disparar
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // cria uma nova bala
        }
    }
}