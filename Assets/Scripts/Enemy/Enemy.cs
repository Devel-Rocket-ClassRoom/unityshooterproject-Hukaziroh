using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();         
            nextFireTime = Time.time + fireRate;
        }
        

    void Shoot()
    {
            EnemyBulletPool.Instance.GetBullet(spawnPoint.position, spawnPoint.rotation);
        }
    }

}
