using System;
using System.Collections.Generic;
using System.Linq;
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
        private Enemy[] enemies;

        protected override void OnActivated()
        {
            lifeTime = 0.5f;
            enemies = this.Managers.EntityManager.FindComponentsOfType<Enemy>().ToArray();
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            transform.Position += transform.LocalOrientation * Vector3.Backward * speed * deltaTime;

            lifeTime -= (float)gameTime.TotalSeconds;
            if (lifeTime <= 0.0f)
                Owner.IsEnabled = false;

            foreach(Enemy enemy in enemies)
            {
                if(enemy.Owner.IsEnabled && (enemy.transform.Position - transform.Position).Length() < 0.5f)
                {
                    enemy.Owner.IsEnabled = false;
                    Owner.IsEnabled = false;
                    break;
                }
            }
        }
    }
}
