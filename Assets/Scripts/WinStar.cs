using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStar : MonoBehaviour
{
    public GameObject winScreen;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            winScreen.SetActive(true);
    }
}
