using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour
{
    public GameObject pop;
    private CircleHandler circleHandler;
    // Tham chiếu đến Transform của vòng tròn
    public float maxDistance;       // Bán kính của vòng tròn
    public float radius = 1f; // bán kính tìm kiếm các object gần nhất

    private Rigidbody2D rb;
    public string ob1;
    public string ob2;
    public string ob3;
    public string ob4;

    public float rayDistance = 100f; // khoảng cách của raycast
    private LayerMask layerMask;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    void FixedUpdate()
    {
        Vector2 center = CircleHandler.instance.circleCenter.position; // Lấy vị trí trung tâm của vòng tròn
        Vector2 position = transform.position;   // Lấy vị trí hiện tại của vật

        // Tính khoảng cách giữa vật và trung tâm của vòng tròn
        Vector2 offset = position - center;
        float distance = offset.magnitude;

        // Nếu khoảng cách lớn hơn bán kính của vòng tròn, tính toán lại vị trí của vật
        if (distance > maxDistance)
        {
            // Tính toán vị trí mới dựa trên vị trí hiện tại và vị trí của trung tâm vòng tròn
            Vector2 direction = offset.normalized;
            Vector2 newPosition = center + direction * maxDistance;

            // Thay đổi vị trí của vật
            rb.MovePosition(newPosition);
            rb.gravityScale = 30;

        }
        if (WinningHandler.instance.isCompleted == true)
        {
            rb.gravityScale = 30;
        }

    }

    void OnDestroy()
    {
        // Tăng điểm số khi vật bị hủy
        WinningHandler.instance.money += 10;
        Instantiate(pop, transform.position, Quaternion.identity);

        if (gameObject.name == ob1)
        {
            WinningHandler.instance.target1 -= 1;

        }
        else if (gameObject.name == ob2)
        {
            WinningHandler.instance.target2 -= 1;
        }
        else if (gameObject.name == ob3)
        {
            WinningHandler.instance.target3 -= 1;
        }
        else if (gameObject.name == ob4)
        {
            WinningHandler.instance.target4 -= 1;
        }
    }
}