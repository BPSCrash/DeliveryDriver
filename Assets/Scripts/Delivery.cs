using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] public float destroyDelay = 0.1f;
    [SerializeField] public Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Package Picked Up"); hasPackage = true;
                Destroy(collision.gameObject, destroyDelay);
                spriteRenderer.color = hasPackageColor;
            }
            else
            {
                Debug.Log("You must deliver the package");
            }
        }

        if (collision.tag == "Customer")
        {
            if (!hasPackage)
            {
                Debug.Log("You do not have a package to deliver");

            }
            else
            {
                Debug.Log("Package devlivered"); hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}
