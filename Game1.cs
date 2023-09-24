using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BreakoutV1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ball _ball;
        private Paddle _paddle;
        private List<Brick> _bricks;
        private MouseState _mouseState;
        private Point _mousePosition;
        private int _score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 700;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D ballTexture = Content.Load<Texture2D>("ball");
            _ball = new Ball(ballTexture);

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            _paddle = new Paddle(paddleTexture);

            Texture2D brickTexture = Content.Load<Texture2D>("brick");
            _bricks = new List<Brick>();
            for(int i = 0; i < 14; i++)
            {
                _bricks.Add(new Brick(brickTexture, i  * 50, 0));
            }

            _score = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _mouseState = Mouse.GetState();
            _mousePosition = new Point(_mouseState.X, _mouseState.Y);

            _ball.Move();
            _paddle.Move(_mousePosition.X);

            // Left border and ball collision
            if(_ball._rectangle.X <= 0)
            {
                _ball._delta.X *= -1;
            }
            // Right border and ball collision
            if(_ball._rectangle.X + _ball._rectangle.Width >= Window.ClientBounds.Width)
            {
                _ball._delta.X *= -1;
            }
            // Top border and ball collision
            if(_ball._rectangle.Y <= 0)
            {
                _ball._delta.Y *= -1;
            }
            // Bottom border and ball collision
            if(_ball._rectangle.Y >= 700)
            {
                Exit();
            }
            // Ball and paddle collision
            if(_ball._rectangle.Intersects(_paddle._rectangle))
            {
                _ball._delta.Y *= -1;
            }
            // Ball and bricks collision
            foreach(Brick brick in _bricks)
            {
                if(_ball._rectangle.Intersects(brick._rectangle) && brick._visible)
                {
                    _ball._delta.Y *= -1;
                    brick._visible = false;
                    _score += 1;
                }
            }

            Window.Title = "BreakoutV1 - Score: " + _score;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _ball.Draw(_spriteBatch);
            _paddle.Draw(_spriteBatch);

            foreach(Brick brick in _bricks)
            {
                brick.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}