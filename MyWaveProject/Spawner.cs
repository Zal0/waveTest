using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

namespace MyWaveProject
{
    public class Spawner : Behavior
    {
        private Enemy[] enemies;

        float spawnMax = 2.0f;
        float spawnMin = 0.5f;
        float timeToNextRespawn;
        Random r = new Random();

        protected override void OnActivated()
        {
            enemies = this.Managers.EntityManager.FindComponentsOfType<Enemy>().ToArray();
        }

        private float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            timeToNextRespawn -= deltaTime;
            if(timeToNextRespawn < 0.0f)
            {
                //Search available enemy
                foreach (Enemy enemy in enemies)
                {
                    if (!enemy.Owner.IsEnabled)
                    {
                        enemy.Owner.IsEnabled = true;
                        Entity[] childEntities = Owner.ChildEntities.ToArray();
                        enemy.transform.Position = childEntities[Random.Range(0, childEntities.Length - 1)].FindComponent< Transform3D >().Position;
                        break;
                    }
                }

                timeToNextRespawn = Random.Range(spawnMin, spawnMax);
            }
        }
    }
}
