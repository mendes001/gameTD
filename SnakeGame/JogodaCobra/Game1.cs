using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JogodaCobra.Classes;
using System;

namespace JogodaCobra
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Cobra cobra;
        Maca maca;
        Random nr;


        const int ssize = 10;
        const int gameHeight = 30;
        const int gameWidth = 60;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = gameHeight * ssize;
            _graphics.PreferredBackBufferWidth = gameWidth * ssize;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            nr = new Random();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            cobra = new Cobra(this, GraphicsDevice, spriteBatch, ssize);
            maca = new Maca(this, spriteBatch, GraphicsDevice, ssize);

            this.Components.Add(cobra);
            this.Components.Add(maca);

            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void RandomApple()
        {
            maca.posX = nr.Next(0, _graphics.GraphicsDevice.Viewport.Width / ssize) * ssize;
            maca.posY = nr.Next(0, _graphics.GraphicsDevice.Viewport.Height / ssize) * ssize;
            maca.gerar = true;
        }
        public void MacaCobra()
        {
            if (cobra.posX == maca.posX && cobra.posY == maca.posY)
            {
                cobra.score++;
                //RandomApple();
                maca.gerar = false;
                cobra.Addssize();
            }
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                Exit();
            if (!maca.gerar)
            {
                RandomApple();
            }
            
            if ((Keyboard.GetState().IsKeyDown(Keys.Up)))
            {
                cobra.dirX = 0;
                cobra.dirY = -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cobra.dirX = 0;
                cobra.dirY = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                cobra.dirX = 1;
                cobra.dirY = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                cobra.dirX = -1;
                cobra.dirY = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                cobra.Reset();
            }
            
            MacaCobra();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(31, 51, 20));

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Pontos: " + cobra.score.ToString(), new Vector2(ssize), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
