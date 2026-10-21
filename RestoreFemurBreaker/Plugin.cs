using Exiled.API.Enums;
using Exiled.API.Features;
using events = Exiled.Events.Handlers;
using labEvents = LabApi.Events.Handlers;

namespace RestoreFemurBreaker;

public class Plugin : Plugin<Config>
{
	private EventHandlers EventHandlers;
	public override Version Version { get; } = new Version( 1, 0, 0 );
	public override Version RequiredExiledVersion { get; } = new Version( 9, 15, 0 );
	public override string Author { get; } = "OPGman";
	public override PluginPriority Priority { get; } = PluginPriority.Medium;

	public override void OnEnabled()
	{
		base.OnEnabled();
		EventHandlers = new EventHandlers( this );
		events.Server.RoundStarted += EventHandlers.OnRoundStart;
		events.Player.InteractingDoor += EventHandlers.OnDoorInteract;
		labEvents.PlayerEvents.Death += EventHandlers.OnPlayerDeath;
		labEvents.ObjectiveEvents.ActivatedGeneratorCompleted += EventHandlers.OnGeneratorFinish;
		AudioClipStorage.LoadClip( Config.SoundPath, "femur_breaker" );
	}

	public override void OnDisabled()
	{
		base.OnDisabled();
		EventHandlers = null;
		events.Server.RoundStarted -= EventHandlers.OnRoundStart;
		events.Player.InteractingDoor -= EventHandlers.OnDoorInteract;
		labEvents.PlayerEvents.Death -= EventHandlers.OnPlayerDeath;
		labEvents.ObjectiveEvents.ActivatedGeneratorCompleted -= EventHandlers.OnGeneratorFinish;
	}
}
