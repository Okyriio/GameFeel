using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float flashDuration = 0.1f;  // How long the flash should last
    public Color flashColor = Color.white;  // The color to flash the enemy

    private SpriteRenderer material;  // The enemy's material
    private Color originalColor;  // The enemy's original color

    private void Start()
    {
        material = GetComponent<SpriteRenderer>();
        originalColor = material.color;
    }

    public void TakeDamage()
    {
        StartCoroutine(FlashWhite());
    }

    private IEnumerator FlashWhite()
    {
        material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        material.color = originalColor;
    }
}
