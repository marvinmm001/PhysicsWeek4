using System;
using GXPEngine;

class Barrel : Sprite 
{
	public Barrel() : base("assets/barrels/t34.png") 
	{
		SetOrigin(width/2 - 25, height/2);
	}

	void Control()
	{
		//----------------Assignment_2_2_2---------------//
		/*
		Vec2 mouseInput = new Vec2(Input.mouseX - parent.x, Input.mouseY - parent.y);
		//Without the -parent.x or -parent.y the mouse only rotate at between (0 to 90)deg
		//because mouseInput follow the (0,0) coordinate  of the tank
		//The idea is to make the (0,0) canvas position to become the (0,0) of tank position
		//but we can't tell the program to change the (x,y) coordinate of the canvas
		//what we do is (mouseX - tank.x, mouse.y - tank.y)
		float angle = mouseInput.GetAngleDegrees(); //getting the rotation angle from Atan2(mouse.y/mouse.x)
		rotation = angle - parent.rotation;
		//must subtract with tank.rotation, because it add the tank's rotation and the barrel's rotation
		//If tank rotate in 90deg, barrel will be 180deg, mouse will be -90deg;
		*/

		Vec2 mouseInput = new Vec2(Input.mouseX - parent.x, Input.mouseY - parent.y);
		float angle = mouseInput.GetAngleDegrees();
		float targetAngle = angle - parent.rotation;
		if (rotation < targetAngle) rotation++;
		else if (rotation > targetAngle) rotation--;
		
	}

	public void Update() 
	{
		Control();
	}
}
