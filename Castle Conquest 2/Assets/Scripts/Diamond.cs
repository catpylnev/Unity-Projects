using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] int diamondValue = 100;
    [SerializeField] AudioClip diamondPickupSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(diamondValue);
        Destroy(gameObject);
    }

}
