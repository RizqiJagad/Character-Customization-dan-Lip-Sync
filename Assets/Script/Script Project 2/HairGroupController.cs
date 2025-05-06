using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGroupController : MonoBehaviour
{
    [SerializeField] private CustomizableElement frontHair;
    [SerializeField] private CustomizableElement backHair;

    // [Header("Hair Sprite Renderer")]
    // public SpriteRenderer frontHairRenderer;
    // public SpriteRenderer backHairRenderer;

    [Header("List of Hair Colors")]
    public Color[] hairColors;

    private int currentColorIndex = 0;

    [ContextMenu("Next Hair Style")]
    public void NextHair()
    {
        int nextIndex = Mathf.Min(frontHair.SpriteIndex + 1, frontHair.TotalSprites - 1);
        frontHair.SetSpriteIndex(nextIndex);
        backHair.SetSpriteIndex(nextIndex);
    }

    [ContextMenu("Previous Hair Style")]
    public void PreviousHair()
    {
        int prevIndex = Mathf.Max(frontHair.SpriteIndex - 1, 0);
        frontHair.SetSpriteIndex(prevIndex);
        backHair.SetSpriteIndex(prevIndex);
    }

    [ContextMenu("Next Color")]
    public void NextColor()
    {
        currentColorIndex = (currentColorIndex + 1) % hairColors.Length;
        ApplyColor();
    }

    [ContextMenu("Previous Color")]
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

        // Cegah alpha 0 agar sprite tidak hilang
        if (selectedColor.a <= 0f)
        {
            selectedColor.a = 1f;
        }

        Debug.Log($"Applying Hair Color: {selectedColor}");

        if (frontHair != null) frontHair.SetColor(selectedColor);
        if (backHair != null) backHair.SetColor(selectedColor);
    }
}
