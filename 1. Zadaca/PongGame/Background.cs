﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Background: Sprite
    {
        public Background(Texture2D spriteTexture, int width, int height) 
            : base(spriteTexture, width, height) 
        { } 
    }
}
