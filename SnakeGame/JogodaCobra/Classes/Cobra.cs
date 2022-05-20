using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JogodaCobra.Classes
{
    class Cobra : DrawableGameComponent
    {
        int size = 0;
        const int speed = 40;
        int LastUpdate = 0;
        int oldPosX = 0;
        int oldPosY = 0;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        List<Rectangle> snakesize;
        GraphicsDevice graphics;

        public int score { get; set; } = 0;
        public bool run { get; set; } = true;
        public int posX { get; set; } = 0;
        public int posY { get; set; } = 0;
        public int dirX { get; set; } = 1;
        public int dirY { get; set; } = 0;

        public Cobra(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int size) : base(game)
        {
            this.size = size;
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.Green });

            posX = graphics.Viewport.Width / 2;
            posY = graphics.Viewport.Height / 2;

            snakesize = new List<Rectangle>();
            snakesize.Add(new Rectangle(posX, posY, size, size));
        }

        public override void Update(GameTime gameTime)
        {
            LastUpdate += gameTime.ElapsedGameTime.Milliseconds;

            if (LastUpdate >= speed && run)
            {
                LastUpdate = 0;

                oldPosX = posX;
                oldPosY = posY;

                posX = posX + dirX * size;
                posY = posY + dirY * size;

                if (posY == -size || posY == graphics.Viewport.Height || posX == -size || posX == graphics.Viewport.Width)
                {
                    run = false;
                    posX = oldPosX;
                    posY = oldPosY;
                    return;
                }

                if (snakesize.Count > 1)
                {
                    for (int i = snakesize.Count - 1; i > 0; i--)
                    {
                        if (posX == snakesize[i].X && posY == snakesize[i].Y)
                        {
                            run = false;
                            posX = oldPosX;
                            posY = oldPosY;
                            return;
                        }
                        snakesize[i] = new Rectangle(snakesize[i - 1].X, snakesize[i - 1].Y, size, size);
                    }
                }
            }
            snakesize[0] = new Rectangle(posX, posY, size, size);
            base.Update(gameTime);
        }

        public void Reset()
        {
            snakesize.Clear();
            score = 0;
            posX = graphics.Viewport.Width / 2;
            posY = graphics.Viewport.Height / 2;

            snakesize.Add(new Rectangle(posX, posY, size, size));
            run = true;


        }

        public void Addssize()
        {
            snakesize.Add(new Rectangle(posX, posY, 15, 15));
        }

        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            if (run)
            {

                foreach (var item in snakesize)
                {
                    spriteBatch.Draw(pixel, new Rectangle(item.X - 1, item.Y - 1, size = 10, size = 10), Color.Green);
                    spriteBatch.Draw(pixel, item, Color.White);
                }
            }
            else
            {
                foreach (var item in snakesize)
                {
                    spriteBatch.Draw(pixel, new Rectangle(item.X - 1, item.Y - 1, size = 10, size = 10), Color.Green);
                    spriteBatch.Draw(pixel, item, Color.Red);
                }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
