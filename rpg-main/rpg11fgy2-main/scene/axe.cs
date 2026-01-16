using Godot;
using System;

public partial class axe : Area2D // Átírva 'Area2d'-ről 'axe'-ra
{
	private bool playerNearby = false;
	private Player playerRef;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			playerNearby = true;
			playerRef = player;
			GD.Print("Játékos a baltánál!");
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is Player player)
		{
			playerNearby = false;
			playerRef = null;
		}
	}

	public override void _Process(double delta)
	{
		if (playerNearby && Input.IsActionJustPressed("ui_accept"))
		{
			if (playerRef != null)
			{
				playerRef.PickUpAxe();
				GD.Print("BALTA FELVÉVE!");
				QueueFree();
			}
		}
	}
}
