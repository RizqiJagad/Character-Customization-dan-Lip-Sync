using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisemeData {
    public float time;
    public Sprite mouthSprite;
}

public class LipSync2D : MonoBehaviour {
    public AudioSource audioSource;
    public SpriteRenderer mouthRenderer;

    [Header("Lip Sync Settings")]
    public Sprite[] mouthSprites;        
    public float interval = 0.3f;         

    private List<VisemeData> visemes;
    private int currentIndex = 0;

    void Start() {
        visemes = new List<VisemeData>();
        float time = 0f;

        while (time < audioSource.clip.length) {
            VisemeData v = new VisemeData();
            v.time = time;
            v.mouthSprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
            visemes.Add(v);
            time += interval;
        }

        currentIndex = 0;
        audioSource.Play();
    }

    void Update() {
        if (audioSource == null || mouthRenderer == null || visemes == null || visemes.Count == 0) return;

        if (currentIndex < visemes.Count && audioSource.isPlaying) {
            float currentTime = audioSource.time;
            if (currentTime >= visemes[currentIndex].time) {
                mouthRenderer.sprite = visemes[currentIndex].mouthSprite;
                Debug.Log("Mengganti ke sprite: " + visemes[currentIndex].mouthSprite.name + " di waktu: " + currentTime);
                currentIndex++;
            }
        }
    }
}
