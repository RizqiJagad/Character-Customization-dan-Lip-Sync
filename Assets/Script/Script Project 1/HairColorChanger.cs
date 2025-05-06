using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColorChanger : MonoBehaviour
{
    [Header("Hair Sprite Renderer")]
    public SpriteRenderer frontHairRenderer;
    public SpriteRenderer backHairRenderer;

    [Header("List of Hair Colors")]
    public Color[] hairColors;

    private int currentColorIndex = 0;

    public void NextColor()
    {
        currentColorIndex = (currentColorIndex + 1) % hairColors.Length;
        ApplyColor();
    }

    public void PreviousColor()
    {
        currentColorIndex--;
        if (currentColorIndex < 0)
        {
            currentColorIndex = hairColors.Length - 1;
        }
        ApplyColor();
    }

    private void ApplyColor()
    {
        if (hairColors == null || hairColors.Length == 0)
        {
            Debug.LogWarning("Hair Colors list is empty!");
            return;
        }

        Color selectedColor = hairColors[currentColorIndex];
        Debug.Log($"Applying Hair Color: {selectedColor}");

        if (frontHairRenderer != null)
        {
            frontHairRenderer.color = selectedColor;
        }

        if (backHairRenderer != null)
        {
            backHairRenderer.color = selectedColor;
        }
    }
}
