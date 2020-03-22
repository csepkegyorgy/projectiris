using Microsoft.Xna.Framework.Input;
using ProjectIris.GameConcepts.GameObjects;
using ProjectIris.Utils;

namespace ProjectIris.GameConcepts.Movement
{
    public class KeyboardMouseController : Controller
    {
        public KeyboardMouseController(GameObject gameObject)
            : base(gameObject)
        {
        }

        public override void Update(double currentMillisecs)
        {
            var elapsedMillisecs = currentMillisecs - LastUpdateMillisecs;
            if (elapsedMillisecs > GameConfig.Delta)
            {
                var keyboardState = Keyboard.GetState();
                var mouseState = Mouse.GetState();

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    GameObject.Body.Y -= (GameObject.MovementSpeedPerSec * (elapsedMillisecs / 1000));
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    GameObject.Body.X += (GameObject.MovementSpeedPerSec * (elapsedMillisecs / 1000));
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    GameObject.Body.Y += (GameObject.MovementSpeedPerSec * (elapsedMillisecs / 1000));
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    GameObject.Body.X -= (GameObject.MovementSpeedPerSec * (elapsedMillisecs / 1000));
                }

                LastUpdateMillisecs = currentMillisecs;
            }
        }
    }
}
