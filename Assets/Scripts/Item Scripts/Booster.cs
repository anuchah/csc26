using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public GameObject effect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            if (other.CompareTag("Player"))
            {
                Bird bird = other.GetComponent<Bird>();
                AudioManager.Instance.PlaySound(TagManager.COLLECT_ITEMS);
                if (bird != null)
                {
                    bird.ActivateSpeedBoost();
                    Instantiate(effect, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }
}
