using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); //hasPackageColor은 구조체이다 구조체의 자료형이 Color32이다
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] float destroyDelay = 0.1f;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌감지");
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "TrigerPoint" && !hasPackage)
        {
            Debug.Log("배달물 수화");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == "TrigerPoint" && hasPackage)
        {
            Debug.Log("이미 수화물 1개를 들고있습니다");
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("사과배달 1개완료");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
