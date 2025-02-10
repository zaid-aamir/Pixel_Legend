using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private int Apples = 0;

    [SerializeField] private Text applesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            Apples++;
            Debug.Log("Apples: " + Apples);
            applesText.text = "Apples: " + Apples;
        }
    }
}
