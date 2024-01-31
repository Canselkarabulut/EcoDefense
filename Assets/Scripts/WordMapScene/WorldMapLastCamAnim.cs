using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class WorldMapLastCamAnim : MonoBehaviour
{
   public Button playButton;

   private void Start()
   {
      playButton.interactable = false;
   }

   public void ActivePlayButton()
   {
      playButton.interactable = true;
   }
}
