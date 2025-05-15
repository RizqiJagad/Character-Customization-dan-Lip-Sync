using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhonemeData {
    public float time;
    public string phoneme; 
}

public class LipSyncPhoneme : MonoBehaviour {
    public AudioSource audioSource;
    public SpriteRenderer mouthRenderer;
    
    public Sprite mouthA, mouthI, mouthU, mouthE, mouthO, mouthRest;
    public List<PhonemeData> phonemes;

    private int currentIndex = 0;

    void Update() {
        if (audioSource == null || !audioSource.isPlaying || phonemes == null || currentIndex >= phonemes.Count)
            return;

        float currentTime = audioSource.time;

        if (currentTime >= phonemes[currentIndex].time) {
            SetMouthSprite(phonemes[currentIndex].phoneme);
            currentIndex++;
        }
    }

    void SetMouthSprite(string phoneme) {
        switch (phoneme.ToUpper()) {
            case "A": mouthRenderer.sprite = mouthA; break;
            case "I": mouthRenderer.sprite = mouthI; break;
            case "U": mouthRenderer.sprite = mouthU; break;
            case "E": mouthRenderer.sprite = mouthE; break;
            case "O": mouthRenderer.sprite = mouthO; break;
            default: mouthRenderer.sprite = mouthRest; break;
        }
    }
}
