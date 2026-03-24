using System;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    // private, protected
    public Transform cannonPoint;
    public GameObject  projectile;
    public Transform spawnPoint;
    public float jumpSpeed = 5.5f;
    public bool isJump = true;
    //private GameObject p1;
    //protected GameObject p2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update는 매 프레임마다 한번씩 호출된다.
    void Update()
    {
        // 만약에 마우스 왼쪽 버튼을 누르면
        if(Input.GetMouseButtonDown(0) == true)
        {
            // 1. 쏴! Shoot!
            // 2. 마우스 왼쪽버튼: 중력적용 발사, 오른쪽 버튼: 중력없이 발사
            // 3. 목표물에 포탄이 맞았을 때 제대로 부서지는가?
            // 4. 발사 속도를 변수로 만들어서 에디터에서 변경할 것
            // 5. 대포의 방향을 위아래로 조절해서 발사하기
            // 6. 블럭 프리팹 만들고 FOR 문을 이용해서 가로 50X20 벽을 만들자
            //    GameObject.Transform.position = new Vector3(x,y,z);
            GameObject obj = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            
            if(rb != null)
            {
                rb.linearVelocity = spawnPoint.up * 180.0f;
            }
        }

        // 대포 자체를 왼쪽 오른쪽 이동하기
        // 1. 만약에 'A'키를 누르면 대포가 왼쪽으로 이동
        // 2. 만약에 'D'키를 누르면 대포가 오른쪽으로 이동
        // 3. 만약에 'W'키를 누르면 대포가 전진
        // 4. 만약에 'S'키를 누르면 대포가 후진
        // 만약에 transform 을 사용하면 현재 스크립트가 붙어있는 오브젝트가 변경된다.
        // transform.position = new Vector3(transform.position.x, transform.position.y, z만 변경)

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-0.5f, 0, 0);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);         
        }
        
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(0.5f, 0, 0);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.Translate(0, 0, 0.5f);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Translate(0, 0, -0.5f);
        }

        if (Input.GetKey(KeyCode.R) == true)
        {
            cannonPoint.Rotate(Vector3.right * -1.0f);
        }

        if (Input.GetKey(KeyCode.F) == true)
        {
            cannonPoint.Rotate(Vector3.right * 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            
            if (rb)
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                isJump = false;
            }         
        }


        float h = Input.GetAxis("Mouse X");
        //float v = Input.GetAxis("Mouse Y");

        //cannonPoint.Rotate(Vector3.right * -v * 4.0f);
        transform.Rotate(Vector3.up * h * 2.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            isJump = true; 
        }
    }
   
}
