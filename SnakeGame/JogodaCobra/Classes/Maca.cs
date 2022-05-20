using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JogodaCobra.Classes
{
    class Maca : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D pixel;
        //int size;
        public int posX { get; set; }
        public bool gerar { get; set; } = false;
        public int posY { get; set; }
        int size;
        public Maca(Game game, SpriteBatch spriteBatch, GraphicsDevice graphics, int size) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.size = size;
            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (gerar)
            {
                spriteBatch.Draw(pixel, new Rectangle(posX, posY, size, size), Color.Red);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
