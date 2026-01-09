using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100f;

	private AnimatedSprite2D animatedSprite; 

	public bool HasKey = false;

	public void PickUpKey(){
		HasKey = true;
		GD.Print("Player most már birtokolja a kulcsot!");
	}

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	private void HandleAnimation(Vector2 direction){

		if(direction == Vector2.Zero){
			animatedSprite.Stop();
			return;
		}

		string anim="";

		if(direction.X != 0){
			anim = direction.X > 0 ? "walkright" : "walkleft"; 
		}
		else if(direction.Y != 0){
			anim = direction.Y > 0 ? "walkdown" : "walkup"; 
		}

		if(animatedSprite.Animation != anim){
			animatedSprite.Play(anim);
		}
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 inputDirection = Vector2.Zero;

		//jobbra
		if(Input.IsActionPressed("ui_right"))
		inputDirection.X+=1;
	
		//balra
		if(Input.IsActionPressed("ui_left"))
		inputDirection.X-=1;
		//fel
		if(Input.IsActionPressed("ui_up"))
		inputDirection.Y-=1;

		//le
		if(Input.IsActionPressed("ui_down"))
		inputDirection.Y+=1;

		inputDirection = inputDirection.Normalized();
		Velocity = inputDirection*Speed;
	
		MoveAndSlide();

		HandleAnimation(inputDirection);

	}
}
