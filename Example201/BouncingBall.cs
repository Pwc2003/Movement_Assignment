using System.Numerics; // Vector2
using Raylib_cs; // Color
using System; // Console
using System.Timers; // Timer

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
	class BouncingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, addForce method)
		private Random random = new Random();
		private Vector2 wind;
		private bool ifTrue = true;

		// constructor + call base constructor
		public BouncingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
			float force = (float)random.Next(0, 100);
			wind = new Vector2(force, 0);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Fall(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Fall(float deltaTime)
		{
			Vector2 gravity = new Vector2(0.0f, 980f);
			//Console.WriteLine(wind);

			AddForce(wind);
			AddForce(gravity);

			Velocity += Acceleration * deltaTime;
			Acceleration *= 0.0f;
			Position += Velocity * deltaTime;
		}
	}
}
