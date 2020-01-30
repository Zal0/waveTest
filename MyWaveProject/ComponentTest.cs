using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Common.Input;
using WaveEngine.Common.Input.Keyboard;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Mathematics;

namespace MyWaveProject
{
    public class ComponentTest : Behavior
    {
        [BindComponent]
        public Transform3D transform;

        [BindComponent(false,false, BindComponentSource.Scene)]
        public Camera camera = null;

        public KeyboardDispatcher keyboardDispatcher;

        protected override void OnActivated()
        {
            if (camera != null && camera.Display != null)
            {
                keyboardDispatcher = camera.Display.KeyboardDispatcher;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            float deltaTime = (float)gameTime.TotalSeconds;
            if (keyboardDispatcher.IsKeyDown(Keys.H))
            {
                transform.RotateAround(transform.Position, Vector3.Up, 2.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.K))
            {
                transform.RotateAround(transform.Position, Vector3.Up, -2.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.U))
            {
                transform.LocalPosition += transform.LocalOrientation * (Vector3.Backward * 5.0f * deltaTime);
            }
            if (keyboardDispatcher.IsKeyDown(Keys.J))
            {
                transform.LocalPosition += transform.LocalOrientation * (Vector3.Backward * -5.0f * deltaTime);
            }
            /*if (keyboardDispatcher.IsKeyDown(Keys.Space))
            {
                this.Managers.EntityManager.Add(this.Owner.);
            }*/
        }
    }
}
