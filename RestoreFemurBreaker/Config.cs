using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RestoreFemurBreaker;

public sealed class Config : IConfig
{
	[Description( "Indicates whether the plugin is enabled or not" )]
	public bool IsEnabled { get; set; } = true;

	[Description( "Whether or not debug messages should be shown in the console." )]
	public bool Debug { get; set; } = false;

	[Description( "Amount of generators that need to be fully activated in order to contain SCP-106." )]
	public int NumGenerators { get; set; } = 2;

	[Description( "Path to the femur_breaker.ogg file. Be sure to include the file name." )]
	public string SoundPath { get; set; } = "";
}
