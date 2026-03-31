using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cannonPoint;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {           
            BulletPool.Instance.GetBullet(spawnPoint.position, BulletPool.Instance.bulletPrefab.gameObject.transform.rotation);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(0.2f, 0, 0);
        }

      
        float limitX = Mathf.Clamp(transform.position.x, -15f, 15f);
     
        transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
    }

   


}
