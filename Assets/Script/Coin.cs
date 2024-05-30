using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public event EventHandler<int> OnCoinCollected;

    int coinAmount =0;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        { 
            other.gameObject.SetActive(false);
            coinAmount++;
            OnCoinCollected?.Invoke(this, coinAmount);
            
        }
    }
    
}

/*
 public event EventHandler<OnActiveTypeBuildingChangeEventArgs> OnActiveTypeBuildingChange;

    public class OnActiveTypeBuildingChangeEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuildingType;

    }

    OnActiveTypeBuildingChange?.Invoke(this, new OnActiveTypeBuildingChangeEventArgs { activeBuildingType = activeBuildingType });

Calling Event with Argument 

    private void BuildingManager_OnActiveTypeBuildingChange(object sender, BuildingManager.OnActiveTypeBuildingChangeEventArgs e)
{
      if(  e.activeBuildingType == null)
      {
        Hide();
        resourceNearbyOverlay.Hide();
      }
      else{
        Show(e.activeBuildingType.sprite);
        if(e.activeBuildingType.hasResourceGenerateData)
        {
        resourceNearbyOverlay.Show(e.activeBuildingType.resourceGenerateData);
      }else
      {
        resourceNearbyOverlay.Hide();
      }
      }
}
    */