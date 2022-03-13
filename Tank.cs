using System;
using GXPEngine;

// TODO: Fix this mess! - see Assignment 2.2
class Tank : Sprite 
{

	// public fields & properties:
	public Vec2 position 
	{
		get 
		{
			return _position;
		}
	}
	public Vec2 velocity;
	Vec2 newVelocity = new Vec2(1, 0);
	float speed;
	

	// private fields:
	Vec2 _position;
	Barrel _barrel;

	public Tank(float px, float py) : base("assets/bodies/t34.png") 
	{
		SetOrigin(width / 2, height / 2);
		_position.x = px;
		_position.y = py;
		_barrel = new Barrel ();
		AddChild (_barrel);

	}

	void Controls() 
	{
			if (Input.GetKey(Key.LEFT))
			{
				rotation -= speed * 0.5f; //take 50% of current speed and use it as the rotation value
			}
			if (Input.GetKey(Key.RIGHT))
			{
				rotation += speed * 0.5f;
			}

		if (!(speed >= Mathf.Abs(5)))
		{
			if (Input.GetKey(Key.UP))
			{
				speed += 0.2f;
			}
			if (Input.GetKey(Key.DOWN))
			{
				speed -= 0.2f;
			}
		}
		
		speed *= 0.90f;
		newVelocity.SetAngleDegrees(rotation);
		velocity = newVelocity * speed;
		//Console.WriteLine("Speed: {0}", speed);
	}

	void Shoot() {
		if (Input.GetMouseButtonDown(0)) 
		{
			Vec2 spawnPos = new Vec2(80, 0);
			spawnPos.SetAngleDegrees(_barrel.rotation + rotation); //must add tank.rotation, because bullet is not a child of tank
																   //bullet is a child of MyGame, so if _barrel.rotation == 90deg
																   //bullet will be spawned at 90deg of MyGame
			parent.AddChild (new Bullet (_position + spawnPos, Vec2.GetUnitVectorDeg(_barrel.rotation + rotation)) ); 
		}
	}

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	public void Update() 
	{
        Console.WriteLine("barrel rotation: {0}", _barrel.rotation);
		Controls ();
		// Basic Euler integration:
		_position += velocity;
		Shoot ();
		UpdateScreenPosition ();
	}
}
