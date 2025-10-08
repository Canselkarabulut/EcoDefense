using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VituralCamControl : MonoBehaviour
{
    public GameObject antarticaPlayButton;
    public GameObject africaPlayButton;
    public GameObject asiaPlayButton;
    public GameObject europePlayButton;
    public GameObject americaPlayButton;
    public GameObject oceanPlayButton;
    public GameObject playButton;
    
   
    public void AntarticaAnimEnd()
    {
       // antarticaPlayButton.SetActive(true);
       playButton.SetActive(true);
       playButton.transform.position = antarticaPlayButton.transform.position;
       playButton.transform.localScale = antarticaPlayButton.transform.localScale;

    }
    public void AfricaAnimEnd()
    {
       // africaPlayButton.SetActive(true);
       playButton.SetActive(true);
        playButton.transform.position = africaPlayButton.transform.position;
        playButton.transform.localScale = africaPlayButton.transform.localScale;
    }
    public void AsiaAnimEnd()
    {
       // asiaPlayButton.SetActive(true);
       playButton.SetActive(true);
       playButton.transform.position = asiaPlayButton.transform.position;
       playButton.transform.localScale = asiaPlayButton.transform.localScale;
    }
    public void EuropeAnimEnd()
    {
        //europePlayButton.SetActive(true);
        playButton.SetActive(true);
        playButton.transform.position = europePlayButton.transform.position;
        playButton.transform.localScale = europePlayButton.transform.localScale;
    }
    public void AmericaAnimEnd()
    {
       // americaPlayButton.SetActive(true);
       playButton.SetActive(true);
       playButton.transform.position = americaPlayButton.transform.position;
       playButton.transform.localScale = americaPlayButton.transform.localScale;
    }
    public void OceanAnimEnd()
    {
    //    oceanPlayButton.SetActive(true);
        playButton.SetActive(true);
        playButton.transform.position = oceanPlayButton.transform.position;
        playButton.transform.localScale = oceanPlayButton.transform.localScale;
    }
}
