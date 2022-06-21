using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

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
	class Pointer : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private float maxDistance;
		private float MaxSpeed = 200f;


		// constructor + call base constructor
		public Pointer() : base("resources/spaceship.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.YELLOW;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			PointToMouse(deltaTime);
			Velocity = Limit(Velocity);
		}

		// your own private methods
		private void PointToMouse(float deltaTime)
		{

			Vector2 mouse = Raylib.GetMousePosition();
			
			Vector2 direction = mouse - Position;

			float distance = Vector2.Distance(mouse, Position);

			if(Position != mouse)
			{
				Vector2.Normalize(direction);

				Acceleration = direction;

				Velocity += Acceleration * deltaTime;

				Position += Velocity * deltaTime;
				Console.WriteLine(Position);
				Acceleration *= 0;
			}

			Rotation = (float)Math.Atan2(Velocity.Y, Velocity.X);
		}
	}
}
