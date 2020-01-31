using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Common.Input;
using WaveEngine.Common.Input.Keyboard;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Mathematics;
using System.Linq;

namespace MyWaveProject
{
    public class ComponentTest : Behavior
    {
        [BindComponent]
        public Transform3D transform;

        [BindComponent(false,false, BindComponentSource.Scene)]
        public Camera camera = null;

        public KeyboardDispatcher keyboardDispatcher;

        public Bullet[] bullets;

        protected override void Start()
        {
            if (camera != null && camera.Display != null)
            {
                keyboardDispatcher = camera.Display.KeyboardDispatcher;
            }

            
            bullets = this.Managers.EntityManager.FindComponentsOfType<Bullet>().ToArray();
            foreach(Bullet b in bullets)
            {
                b.Owner.IsEnabled = false;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            if (keyboardDispatcher.IsKeyDown(Keys.H))
            {
                transform.RotateAround(transform.Position, Vector3.Up, 4.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.K))
            {
                transform.RotateAround(transform.Position, Vector3.Up, -3.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.U))
            {
                transform.LocalPosition += transform.LocalOrientation * (Vector3.Backward * 5.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.J))
            {
                transform.LocalPosition += transform.LocalOrientation * (Vector3.Backward * -5.0f * deltaTime);
            }
            if (keyboardDispatcher.ReadKeyState(Keys.Space) == ButtonState.Pressing)
            {
                foreach(Bullet b in bullets)
                {
                    if (!b.Owner.IsEnabled)
                    {
                        b.transform.Position = transform.Position;
                        b.transform.Orientation = transform.Orientation;
                        b.Owner.IsEnabled = true;
                        break;
                    }
                }
            }
        }
    }
}
