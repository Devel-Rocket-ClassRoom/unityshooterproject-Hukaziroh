using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float shootingTerm = 0.5f;       // 1초마다 발사
    public float shootingSpeed = 180.0f;    // 발사 속도

    private float timeCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        timeCount += Time.deltaTime;
        if(timeCount > shootingTerm)
        {
            GameObject obj = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.forward * shootingSpeed;
            }
            timeCount = 0;
        }
    }
}
