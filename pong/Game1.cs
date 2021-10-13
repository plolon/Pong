using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Platform> players;
        private Ball ball;
        private Texture2D WhiteTex;
        private Texture2D ballT;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            players = CreatePaddles();
            ballT = Content.Load<Texture2D>("ball");
            ball = new Ball(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            WhiteTex = new Texture2D(GraphicsDevice, 1, 1);
            WhiteTex.SetData(new Color[] { Color.White });
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            KeyboardHandler.GetState();
            if (KeyboardHandler.IsPressed(Keys.Up))
            {
                
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach (var player in players)
            {
                _spriteBatch.Draw(WhiteTex, new Rectangle((int)player.Pos.X, (int)player.Pos.Y, 20, 100), Color.White);
            }
            _spriteBatch.Draw(ballT, new Rectangle((int)ball.Pos.X - 15, (int)ball.Pos.Y - 15, 30, 30), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private List<Platform> CreatePaddles()
        {
            return new List<Platform>()
            {
                new Platform(new Vector2(5, (_graphics.PreferredBackBufferHeight/2) - 50), "Player 1"),
                new Platform(new Vector2(_graphics.PreferredBackBufferWidth-25, (_graphics.PreferredBackBufferHeight/2) - 50), "Player 2"),
            };
        }
    }
}
