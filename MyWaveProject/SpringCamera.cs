using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Mathematics;

namespace MyWaveProject
{
    public class SpringCamera : Behavior
    {
        [BindComponent]
        public Transform3D transform;

        private Transform3D target = null;

        protected override void Start()
        {
            target = this.Managers.EntityManager.FindFirstComponentOfType<ComponentTest>().Owner.FindComponent< Transform3D >();
        }

        private void Translate(Vector3 offset)
        {
            Transform3D firstChild = Owner.FindChild("camera").FindComponent<Transform3D>();
            transform.LocalPosition += transform.LocalOrientation * firstChild.LocalOrientation *  offset;
        }

        private float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (target != null)
            {
                float deltaTime = (float)gameTime.TotalSeconds;

                float dist = (target.Position - transform.Position).Length();
                transform.Position = target.Position;

                transform.Orientation = Quaternion.Lerp(transform.Orientation, target.Orientation, Math.Min(1.0f, Vector3.Angle(transform.WorldTransform.Forward, target.WorldTransform.Forward) * 10.0f * deltaTime));

                Translate(Vector3.Backward * Lerp(dist, 5.0f, (dist - 0.5f) * 0.1f * deltaTime));
            }
        }
    }
}
