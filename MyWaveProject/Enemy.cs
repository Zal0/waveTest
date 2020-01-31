using System;
using System.Collections.Generic;
using System.Linq;
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
        private Enemy[] enemies;

        protected override void OnActivated()
        {
            enemies = this.Managers.EntityManager.FindComponentsOfType<Enemy>().ToArray();
        }

        private void Translate(Vector3 offset)
        {
            transform.LocalPosition += transform.LocalOrientation * offset;
        }

        protected override void Start()
        {
            speed = Random.Range(2.5f, 6.0f);
        }

        void CheckCollision(Transform3D enemy)
        {
            float dist = (enemy.Position - transform.Position).Length();
            float max_dist = 1.5f;
            if (enemy.Owner.IsEnabled && dist < max_dist)
            {
                Vector3 offset = (enemy.Position - transform.Position);
                offset.Normalize();
                float t = ((max_dist - dist) / max_dist);
                offset *= t * 0.3f;
                offset.Y = 0.0f;

                if(enemy != player.transform)
                    enemy.LocalPosition += offset;
                transform.LocalPosition -= offset;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;

            Quaternion rot = transform.Orientation;
            transform.LookAt(player.transform.Position);
            transform.Orientation = Quaternion.Lerp(rot, transform.Orientation, 0.1f);
            Translate(Vector3.Forward * speed * deltaTime);

            foreach (Enemy enemy in enemies)
            {
                if (enemy == this)
                    continue;
                CheckCollision(enemy.transform);
            }
            CheckCollision(player.transform);
        }
    }
}
