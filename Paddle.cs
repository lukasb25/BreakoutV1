using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakoutV1
{
    internal class Paddle
    {
        private Texture2D _texture;
        public Rectangle _rectangle;

        public Paddle(Texture2D texture)
        {
            _texture = texture;
            _rectangle = new Rectangle(700 / 2 + 100 / 2, 650, 100, 25);
        }

        public void Move(int x)
        {
            _rectangle.X = x;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
