using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySkinColorChanger : MonoBehaviour
{
    [Header("Sprite Renderer untuk bagian kulit")]
    public List<SpriteRenderer> skinRenderers; 

    [Header("Warna yang tersedia untuk kulit")]
    public List<Color> skinColors;

    private int currentColorIndex = 0;

    void Start()
    {
        if (skinColors == null || skinColors.Count == 0)
        {
            Debug.LogWarning("Belum ada warna di list skinColors.");
            return;
        }

        if (skinRenderers == null || skinRenderers.Count == 0)
        {
            Debug.LogWarning("Belum ada SpriteRenderer di list skinRenderers.");
            return;
        }

        ApplyColor();
    }

    public void NextColor()
    {
        if (skinColors.Count == 0) return;

        currentColorIndex = (currentColorIndex + 1) % skinColors.Count;
        ApplyColor();
    }

    public void PreviousColor()
    {
        if (skinColors.Count == 0) return;

        currentColorIndex = (currentColorIndex - 1 + skinColors.Count) % skinColors.Count;
        ApplyColor();
    }

    private void ApplyColor()
    {
        Color selectedColor = skinColors[currentColorIndex];
        selectedColor.a = 1f;

        Debug.Log("Applying Skin Color: " + selectedColor);

        foreach (SpriteRenderer renderer in skinRenderers)
        {
            if (renderer != null)
            {
                renderer.color = selectedColor;
            }
            else
            {
                Debug.LogWarning("Ada SpriteRenderer yang null di skinRenderers.");
            }
        }
    }
}