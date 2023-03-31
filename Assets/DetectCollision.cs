using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // variables
    private bool hasPackage = false;


    SpriteRenderer spriteRenderer;
    [SerializeField] Color hasPackageColor;
    [SerializeField] Color doesNotHavePackageColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Wow collision with" + collision.gameObject.name);

    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //Debug.Log("Guh trigger" + trigger.gameObject.name);

        if(trigger.gameObject.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Wow, a package!");
            spriteRenderer.color = hasPackageColor;
            Destroy(trigger.gameObject, 0.5f);
        }
        if(trigger.gameObject.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = doesNotHavePackageColor;
            Debug.Log("Delivered Package.");



        }
    }
}
