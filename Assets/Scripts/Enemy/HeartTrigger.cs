using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
   public Material healthbarGreen;
   public Material healthbarOrange;
   public Material healthbarRed;
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out PlayerTrigger playerTrigger))
      {
         Debug.Log("kalbe değdi");
         var healthbarWiev = playerTrigger.GetComponentInChildren<HealthbarWiev>().gameObject;
         if (healthbarWiev.transform.localScale.x <= .6f)
         {
            healthbarWiev.transform.localScale += new Vector3(.02f, 0, 0);
            healthbarWiev.GetComponent<Renderer>().material = healthbarGreen;
            if (healthbarWiev.transform.localScale.x < .35)
            {
               healthbarWiev.GetComponent<Renderer>().material = healthbarOrange;
               if (healthbarWiev.transform.localScale.x < .2)
               {
                  healthbarWiev.GetComponent<Renderer>().material = healthbarRed;
               }
            }
         }
         transform.parent.gameObject.SetActive(false);
      }
   }
}
