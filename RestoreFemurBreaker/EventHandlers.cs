using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using LabApi.Events.Arguments.ObjectiveEvents;
using LabApi.Events.Arguments.PlayerEvents;
using MapGeneration;
using MEC;
using PlayerRoles;
using UnityEngine;

namespace RestoreFemurBreaker;

public class EventHandlers
{
	private Plugin plugin;
	public EventHandlers( Plugin plugin ) => this.plugin = plugin;
	private bool sacrificed = false;
	private int total = 0;

	private IEnumerator<float> Contain106()
	{
		AudioPlayer audio = AudioPlayer.CreateOrGet( "FemurBreakerAudio",
			onIntialCreation: (p) => p.AddSpeaker( "Main", isSpatial: false, maxDistance: 5000f ),
			condition: ( hub ) => hub.roleManager.CurrentRole.RoleTypeId == RoleTypeId.Scp106 || !hub.IsAlive() || hub.GetCurrentZone() == FacilityZone.HeavyContainment );
		audio.AddClip( "femur_breaker" );
		yield return Timing.WaitForSeconds( 20f );
		foreach ( var ply in Player.List )
		{
			if ( ply.Role.Type == RoleTypeId.Scp106 )
				ply.Kill( DamageType.Recontainment, "SCP 1 0 6 CONTAINED SUCCESSFULLY" );
		}
	}

	public void OnRoundStart()
	{
		sacrificed = false;
		total = 0;
	}

	public void OnPlayerDeath( PlayerDeathEventArgs ev )
	{
		if ( ev.Attacker == null && !ev.OldRole.IsScp() && !sacrificed )
		{
			Room rm = Room.Get( RoomType.Hcz106 );
			float distance = Vector3.Distance( ev.OldPosition, rm.Position );
			if ( distance <= 25 )
			{
				sacrificed = true;
				if ( total >= plugin.Config.NumGenerators )
					rm.Color = Color.green;
				else
					rm.Color = Color.red;
			}
		}
	}

	public void OnGeneratorFinish( GeneratorActivatedObjectiveEventArgs ev )
	{
		total++;
		if ( total >= plugin.Config.NumGenerators )
		{
			Room rm = Room.Get( RoomType.Hcz106 );
			if ( sacrificed )
				rm.Color = Color.green;
			else
				rm.Color = Color.red;
		}
	}

	public void OnDoorInteract( InteractingDoorEventArgs ev )
	{
		if ( total >= plugin.Config.NumGenerators && sacrificed && ( ev.Door.Type == DoorType.Scp106Primary || ev.Door.Type == DoorType.Scp106Secondary ) && ev.Player.CurrentItem.Type == ItemType.KeycardO5 )
		{
			Timing.RunCoroutine( Contain106() );
			Room rm = Room.Get( RoomType.Hcz106 );
			rm.ResetColor();
			ev.Door.Lock( DoorLockType.NoPower );
			total = 0;
		}
	}
}
