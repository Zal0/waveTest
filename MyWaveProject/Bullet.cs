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

        private float speed = 30.0f;

        private float lifeTime;

        protected override void OnActivated()
        {
            lifeTime = 0.5f;
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            transform.Position += transform.LocalOrientation * Vector3.Backward * speed * deltaTime;

            lifeTime -= (float)gameTime.TotalSeconds;
            if (lifeTime <= 0.0f)
                Owner.IsEnabled = false;
        }
    }
}
