#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace BrakeNeck.Entities
{
	public partial class SandStorm
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{


		}

		private void CustomActivity()
		{
            MovementActivity();

		}

        private void MovementActivity()
        {
            // The sandstorm moves forward at a certain rate, 
            // but if it falls too far behind, its position is 
            // directly set to keep the user from accumulating a
            // huge lead. If we don't do this, the sandstorm would
            // fall way behind, then all of a sudden surprise the user
            // (if its velocity every got big enough to catch up) or would
            // never catch up. 
            this.Y += MovingSpeed * TimeManager.SecondDifference;

            float minY = Camera.Main.AbsoluteBottomYEdgeAt(0) - MaxDistanceBehindScreen;

            this.Y = Math.Max(this.Y, minY);
        }

        private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
