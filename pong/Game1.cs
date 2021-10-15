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
        private SpriteFont Lives_font;
        private SpriteFont Counter_font;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = CONFIG.WIDTH;
            _graphics.PreferredBackBufferHeight = CONFIG.HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
            Lives_font = Content.Load<SpriteFont>("font");
            Counter_font = Content.Load<SpriteFont>("font2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Counter.StopWatch();
            KeyboardHandler.GetState();
            MovingHelper.Move();

            players[0].Move(MovingHelper.player1);
            MovingHelper.p1 = players[0].GetRect();
            MovingHelper.p2 = players[1].GetRect();
            players[1].Move(MovingHelper.player2);
            ball.Move();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if (Counter.isCountering)
            {
                _spriteBatch.DrawString(Counter_font, $"{Counter.Tick}", new Vector2(CONFIG.WIDTH / 2 - 40, CONFIG.HEIGHT / 2 - 40), Color.White);
            }
            //DrawLine();
            DrawLives();
            foreach (var player in players)
            {
                _spriteBatch.Draw(WhiteTex, new Rectangle((int)player.Pos.X, (int)player.Pos.Y, 20, CONFIG.PLATFORM_SIZE), Color.White);
            }
            _spriteBatch.Draw(ballT, new Rectangle((int)ball.Pos.X - 15, (int)ball.Pos.Y - 15, 30, 30), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private List<Platform> CreatePaddles()
        {
            return new List<Platform>()
            {
                new Platform(new Vector2(5, (CONFIG.HEIGHT/2) - CONFIG.PLATFORM_SIZE/2), "Player 1"),
                new Platform(new Vector2(CONFIG.WIDTH-25, (CONFIG.HEIGHT/2) - CONFIG.PLATFORM_SIZE/2), "Player 2"),
            };
        }
        private void DrawLine()
        {
            _spriteBatch.Draw(WhiteTex, new Rectangle(CONFIG.WIDTH / 2 - 4, 0, 8, CONFIG.HEIGHT), Color.White);
        }
        private void DrawLives()
        {
            _spriteBatch.DrawString(Lives_font, $"Lives: {MovingHelper.Player1L}", new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(Lives_font, $"Lives: {MovingHelper.Player2L}", new Vector2(CONFIG.WIDTH-100, 10), Color.White);
        }
    }
}
