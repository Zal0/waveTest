using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Mathematics;

namespace MyWaveProject
{
    public class Enemy : Behavior
    {
        [BindComponent(false, false, BindComponentSource.Scene)]
        public ComponentTest player;

        [BindComponent]
        public Transform3D transform;

        private float speed = 2.0f;

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;

            Quaternion rot = transform.Orientation;
            transform.LookAt(player.transform.Position);
            transform.Orientation = Quaternion.Lerp(rot, transform.Orientation, 0.5f);

            transform.Position += transform.LocalOrientation * Vector3.Forward * speed * deltaTime;
        }
    }
}
