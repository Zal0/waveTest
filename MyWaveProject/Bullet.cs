using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Mathematics;

namespace MyWaveProject
{
    public class Bullet : Behavior
    {
        [BindComponent]
        public Transform3D transform;

        public float speed = 1.0f;

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            transform.Position += transform.LocalOrientation * Vector3.Backward * speed * deltaTime;
        }
    }
}
