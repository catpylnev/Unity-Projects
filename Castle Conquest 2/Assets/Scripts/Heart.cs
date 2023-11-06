using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] AudioClip HeartPickupSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(HeartPickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToLives();
        Destroy(gameObject);
    }
}
