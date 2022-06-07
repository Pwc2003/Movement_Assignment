using System.Numerics; // Vector2
using Raylib_cs; // Color
using System;

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class SimpleBall : SpriteNode
	{
		// your private fields here
		private int speed = 200;

		// constructor + call base constructor
		public SimpleBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
			//Console.WriteLine("Ball position: " + Position);
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			Position.X += speed * deltaTime;
		}

		

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_height = TextureSize.Y;

			// TODO implement...
			if (Position.X + spr_width / 2 > scr_width)
				{
					Position.X = scr_width - spr_width / 2;
					speed = -speed;
				} else {
			if (Position.X - spr_width / 2 < 0)
				{
					Position.X = spr_width / 2;
					speed = -speed;
				}
			}
		}
	}
}
