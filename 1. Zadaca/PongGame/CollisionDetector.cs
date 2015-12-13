﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class CollisionDetector
    {
        /// <summary> 
        /// Calculates if rectangles describing two sprites are overlapping on screen. 
        /// </summary> 
        /// <param name="s1">First sprite</param> 
        /// <param name="s2">Second sprite</param> 
        /// <returns>Returns true if overlapping</returns>

        public static bool Overlaps(Sprite s1, Sprite s2) 
        {
            if (s1.Size.Width < s2.Size.Width) //neka s1 bude širi od 2 objekta
            {
                Sprite temp = s1;
                s1 = s2;
                s2 = temp;
            }
            if (s1.Position.X + s1.Size.Width >= s2.Position.X + s2.Size.Width
                && s1.Position.X <= s2.Position.X 
                && s1.Position.Y == s2.Position.Y)
                return true;
            return false;
        }
    }
}
