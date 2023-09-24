using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakoutV1
{
    internal class Brick
    {
        private Texture2D _texture;
        public Rectangle _rectangle;
        public bool _visible;

        public Brick(Texture2D texture, int x, int y)
        {
            _texture = texture;
            _rectangle = new Rectangle(x, y, 50, 25);
            _visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_visible)
            {
                spriteBatch.Draw(_texture, _rectangle, Color.White);
            }
        }
    }
}
