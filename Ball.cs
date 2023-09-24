using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakoutV1
{
    internal class Ball
    {
        private Texture2D _texture;
        public Rectangle _rectangle;
        public Vector2 _delta;

        public Ball(Texture2D texture)
        {
            _texture = texture;
            _rectangle = new Rectangle(100, 100, 10, 10);
            _delta = new Vector2(4, 4);
        }

        public void Move()
        {
            _rectangle.X += Convert.ToInt32(_delta.X);
            _rectangle.Y += Convert.ToInt32(_delta.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
