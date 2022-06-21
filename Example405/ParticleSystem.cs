using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		List<Particle> particles;
		private List<Color> colors;
		private float PositionX;
		private float PositionY;
		private float pleaseWork = 0f;
		public Vector2 ParticlePosition;
		private Random rand;
		public Particle p;
		public Particle p2;

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Position = new Vector2(x, y);
			PositionX = x;
			PositionY = y;
			ParticlePosition = new Vector2(PositionX, PositionY);

			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);

			particles = new List<Particle>();
			rand = new Random();
			while(pleaseWork < 100)
			{
				pleaseWork++;
				p = new Particle(0, 0, colors[rand.Next()%colors.Count]);
				particles.Add(p);
				p.Rotation = (float)Math.Atan2(p.Velocity.Y, p.Velocity.X);
				AddChild(p);
			}
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			p2 = particles[0];
			if(p2.isDead)
			{
				particles.Remove(p2);
				particles.Add(p2);
				p2.Position = new Vector2(0, 0);
				p2.Velocity = p2.startVelocity;
				p2.isDead = false;
			}
			else
			{
				foreach (Particle p in particles)
				{
					p2.Update(deltaTime); //important otherwise all particles reset at the same time
				}
			}
		}


	}
}
