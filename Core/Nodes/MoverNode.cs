using System.Numerics;
using System;

namespace Movement
{
	abstract class MoverNode : SpriteNode
	{
		private Vector2 velocity;
		private Vector2 acceleration;
		private float mass;

		public Vector2 Velocity { 
			get { return velocity; }
			set { velocity = value; }
		}
		public Vector2 Acceleration { 
			get { return acceleration; }
			set { acceleration = value; }
		}
		public float Mass { 
			get { return mass; }
			private set { mass = value; }
		}

		// constructor
		protected MoverNode(string title) : base(title)
		{
			Velocity = new Vector2(0, 0);
			Acceleration = new Vector2(0, 0);
			Mass = 1.0f;
		}

		public override void Update(float deltaTime)
		{
			// override in your subclass
		}

		// Protected methods to be called from subclass
		protected void Move(float deltaTime)
		{
			// Motion 101. Apply the rules.
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// Reset acceleration
			Acceleration *= 0.0f;
		}

		protected void AddForce(Vector2 force)
		{
			Acceleration += force / Mass;
		}

		protected void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				Position.X = 0;
			}
			else if (Position.X < 0)
			{
				Position.X = scr_width;
			}
			if(Position.Y > scr_height)
			{
				Position.Y = 0;
			}
			else if(Position.Y < 0)
			{
				Position.Y = scr_height;
			}
		}

		protected void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;
			float half_width = spr_width / 2;
			float half_height = spr_heigth / 2;

			if (Position.X + half_width >= scr_width)
			{
				velocity.X = -Velocity.X;
				acceleration.X = -Acceleration.X;
			}
			else if(Position.X - half_width <= 0)
			{
				velocity.X = -Velocity.X;
				acceleration.X = -Acceleration.X;
			}
			if(Position.Y + half_height >= scr_height)
			{
				velocity.Y = -Velocity.Y;
				acceleration.Y = -Acceleration.Y;
			}
			else if(Position.Y - half_height <= 0)
			{
				velocity.Y = -Velocity.Y;
				acceleration.Y = -Acceleration.Y;
			}
		}

		protected Vector2 Limit(Vector2 vec)
		{
			Vector2 normalized = Vector2.Normalize(vec);
			Vector2 limit;
			
			float MaxSpeed = 800f;
			float magnitude = vec.Length();

			if(magnitude >= MaxSpeed)
			{
				limit = normalized * MaxSpeed;
				vec = limit;
				return vec;
			}
			return vec;
		}
	}
}
