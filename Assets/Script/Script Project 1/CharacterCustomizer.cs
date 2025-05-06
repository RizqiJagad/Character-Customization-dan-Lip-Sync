using UnityEngine;
using UnityEngine.U2D.Animation; 

public class CharacterCustomizer : MonoBehaviour
{
    [Header("Hair Resolvers")]
    public SpriteResolver frontHairResolver;
    public SpriteResolver backHairResolver;

    public void SetHair(string label)
    {
        Debug.Log("Mengganti rambut ke: " + label);

        if (label == "Hair1")
        {
            frontHairResolver.SetCategoryAndLabel("Hair", "Hair1");
            backHairResolver.SetCategoryAndLabel("Hair", "Hair3");
        }
        else if (label == "Hair2")
        {
            frontHairResolver.SetCategoryAndLabel("Hair", "Hair2");
            backHairResolver.SetCategoryAndLabel("Hair", "Hair4");
        }
        else
        {
            Debug.LogWarning("Label tidak dikenali.");
        }
    }
}