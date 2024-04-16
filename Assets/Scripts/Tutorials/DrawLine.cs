using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform starttarget; // Hedef nokta
    public Transform lasttarget; // Hedef nokta
    private LineRenderer lineRenderer;
    public WaveControl waveControl;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Başlangıç ve bitiş noktası için iki pozisyon belirliyoruz

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.9f;
    }

    void Update()
    {
        if (waveControl.waveNumber == WaveNumber.Wave1)
        {
            if (waveControl.saveTutorialCount == 1)
            {
                if (lasttarget != null && starttarget != null)
                {
                    // Player'ın x ve z pozisyonları, y pozisyonunu sabit alarak çizgi oluşturuluyor.
                    lineRenderer.SetPosition(0,
                        new Vector3(starttarget.transform.position.x, 1f, starttarget.transform.position.z));
                    lineRenderer.SetPosition(1, new Vector3(lasttarget.position.x, 1f, lasttarget.position.z));
                }
            }
        }
       
    }
}