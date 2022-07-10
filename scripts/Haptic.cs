using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HapticTest : UdonSharpBehaviour
{
 
    void start()
    {
        // requires VRC_PickUp component
        PickUp = (VRC.SDK3.Components.VRCPickup) gameObject.GetComponent(typeof(VRC.SDK3.Components.VRCPickup));
    }

    public override void OnPickupUseDown()
    {
        Networking.LocalPlayer.PlayHapticEventInHand(PickUp.currentHand,1f,0.1f,0.7f);
    }
}

