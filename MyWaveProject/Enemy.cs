﻿using System;
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

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;

            Quaternion rot = transform.Orientation;
            transform.LookAt(player.transform.Position);
            transform.Orientation = Quaternion.Lerp(rot, transform.Orientation, 0.5f);

            transform.Position += transform.LocalOrientation * Vector3.Forward * speed * deltaTime;

            foreach (Enemy enemy in enemies)
            {
                float dist = (enemy.transform.Position - transform.Position).Length();
                float max_dist = 1.0f;
                if (enemy.Owner.IsEnabled && dist < max_dist)
                {
                    Vector3 offset = (enemy.transform.Position - transform.Position);
                    offset.Normalize();
                    offset *= (max_dist - dist) / max_dist * 0.01f;

                    Translate(offset);
                    enemy.Translate(-offset);
                }
            }
        }
    }
}
