using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableGroupController : MonoBehaviour
{
     [SerializeField] private List<CustomizableElement> elements; 

    [Header("List of Shared Colors")]
    public List<Color> sharedColors;

    private int currentSpriteIndex = 0;
    private int currentColorIndex = 0;

    [ContextMenu("Next Style")]
    public void NextStyle()
    {
        currentSpriteIndex++;
        foreach (var element in elements)
        {
            if (element.TotalSprites == 0)
            {
                Debug.LogWarning($"{element.name}: TotalSprites == 0. Skipping element.");
                continue;
            }

            int nextIndex = Mathf.Min(currentSpriteIndex, element.TotalSprites - 1);
            element.SetSpriteIndex(nextIndex);
        }
    }

    [ContextMenu("Previous Style")]
    public void PreviousStyle()
    {
        currentSpriteIndex--;
        if (currentSpriteIndex < 0) currentSpriteIndex = 0;

        foreach (var element in elements)
        {
            if (element.TotalSprites == 0)
            {
                Debug.LogWarning($"{element.name}: TotalSprites == 0. Skipping element.");
                continue;
            }

            int prevIndex = Mathf.Max(currentSpriteIndex, 0);
            element.SetSpriteIndex(prevIndex);
        }
    }

    [ContextMenu("Next Color")]
    public void NextColor()
    {
        currentColorIndex = (currentColorIndex + 1) % sharedColors.Count;
        ApplyColor();
    }

    [ContextMenu("Previous Color")]
    public void PreviousColor()
    {
        currentColorIndex--;
        if (currentColorIndex < 0)
        {
            currentColorIndex = sharedColors.Count - 1;
        }
        ApplyColor();
    }

    private void ApplyColor()
    {
        if (sharedColors == null || sharedColors.Count == 0) return;

        Color selectedColor = sharedColors[currentColorIndex];

        if (selectedColor.a <= 0f)
        {
            selectedColor.a = 1f;
        }

        foreach (var element in elements)
        {
            element.SetColor(selectedColor);
        }
    }
}
