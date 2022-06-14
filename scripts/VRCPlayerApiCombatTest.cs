using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class VRCPlayerApiCombatTest : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    public int playerId;

    public override void Interact()
    {
        if(!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        playerId = Networking.LocalPlayer.playerId;
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(die));
    }

    public void die()
    {
        var player = (VRCPlayerApi) VRCPlayerApi.GetPlayerById(playerId);
        player.CombatSetup();
        player.CombatSetMaxHitpoints(100);
        player.CombatSetCurrentHitpoints(100);
        player.CombatSetDamageGraphic(null);
        player.CombatSetCurrentHitpoints(0);
    }
}
