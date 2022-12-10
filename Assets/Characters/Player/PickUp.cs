using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 Direction { get; set; }
    public GameObject itemHolding;

    void Update()
    {
        // pick up or drop item
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }

        }
    }

    // return item that the player is holding
    public string GetItemHoldingDialog() {
        return itemHolding.GetComponent<Sign>().dialog;
    }

    public void DestroyItem() {
        Destroy(gameObject);
    }

    // Use: StartCoroutine(ThrowItem(itemHolding));
    // to start coroutine
    // todo: not working
    // IEnumerator ThrowItem(GameObject item)
    // {
    //     Vector3 startPoint = item.transform.position;
    //     Vector3 endPoint = transform.position + Direction * 2;
    //     item.transform.parent = null;
    //     for (int i = 0; i < 25; i++)
    //     {
    //         item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
    //         yield return null;
    //     }
    //     if (item.GetComponent<Rigidbody2D>())
    //         item.GetComponent<Rigidbody2D>().simulated = true;
    // }
}
