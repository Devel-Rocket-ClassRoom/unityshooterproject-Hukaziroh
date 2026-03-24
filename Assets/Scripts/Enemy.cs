using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public float patrolSpeed = 2.0f;

    private Transform targetPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 2개의 패트롤 지점의 높이 (Y좌표)를 캐릭터와 강제로 동일하게 만든다
        Vector3 pos = patrolPoint1.position;
        pos.y = transform.position.y;
        patrolPoint1.position = pos;

        pos = patrolPoint2.position;
        pos.y = transform.position.y;
        patrolPoint2.position = pos;

        targetPoint = patrolPoint1;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol(); // 1초에 60번 호출 (60프레임 속도)  1프레임 1/60초
    }

    void life()
    {
        if (health < 0)
            Destroy(this);
    }
    void Patrol()
    {
        // 현재 위치에서 목표 지점까지 이동
        transform.position = Vector3.MoveTowards(transform.position,
            targetPoint.position, patrolSpeed * Time.deltaTime);

        // 목표 지점에 거의 도달하면 반대 지점으로 목표 변경
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            if (targetPoint == patrolPoint1)
                targetPoint = patrolPoint2;
            else
                targetPoint = patrolPoint1;
        }
    }

}
