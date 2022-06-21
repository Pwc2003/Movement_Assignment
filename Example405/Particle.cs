using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
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
	class Particle : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		public Vector2 startVelocity;
		Random rand = new Random();
		public bool isDead = false;
		private int lifeSpan = 10000;
		private int timeAlive = 0;


		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			float randX = (float)rand.Next(-150, 150); 
			float randY = (float)rand.Next(-300, 0); 
			Position = new Vector2(x, y);
			Velocity = new Vector2(randX, randY);
			Console.WriteLine(Velocity);
			startVelocity = Velocity;
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			Rotation = (float)Math.Atan2(Velocity.Y, Velocity.X);
			AddForce(new Vector2(0, 980f));
			
			timeAlive++;
			if(timeAlive >= lifeSpan)
			{
				isDead = true;
				timeAlive = 0;
			}
		}
	}
}