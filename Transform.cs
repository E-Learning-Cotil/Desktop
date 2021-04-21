using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    class Transform
    {
        
        public static GraphicsPath BorderRadius(Rectangle objectShape, int intensity, bool topLeft, bool topRight, bool bottomRight, bool bottomLeft)
        {
            GraphicsPath desiredShape = new GraphicsPath();

            if (topLeft && topRight)
            {
                desiredShape.AddArc(objectShape.X - 1, objectShape.Y - 1, intensity, intensity, 180, 90); // canto superior esquerdo
                desiredShape.AddArc(objectShape.X + objectShape.Width - intensity, objectShape.Y - 1, intensity, intensity, 270, 90); // canto superior direito
            }
            else if (topLeft)
            {
                desiredShape.AddArc(objectShape.X - 1, objectShape.Y - 1, intensity, intensity, 180, 90); // canto superior esquerdo
                desiredShape.AddLine(objectShape.X - 1 - intensity, objectShape.Y - 1, objectShape.X + objectShape.Width, objectShape.Y - 1);
            }
            else
            {
                desiredShape.AddLine(objectShape.X - 1, objectShape.Y - 1, objectShape.X + objectShape.Width - intensity, objectShape.Y - 1);
                desiredShape.AddArc(objectShape.X + objectShape.Width - intensity, objectShape.Y - 1, intensity, intensity, 270, 90); // canto superior direito
            }

            if(bottomLeft && bottomRight)
            {
                desiredShape.AddArc(objectShape.X + objectShape.Width - intensity, objectShape.Y + objectShape.Height - intensity, intensity, intensity, 0, 90); //canto inferior direito
                desiredShape.AddArc(objectShape.X - 1, objectShape.Y + objectShape.Height - intensity, intensity, intensity, 90, 90);// canto inferior esquerdo
            }
            else if (bottomLeft)
            {
                desiredShape.AddLine(objectShape.Width, objectShape.Y + objectShape.Height, objectShape.X - 1 - intensity, objectShape.Y + objectShape.Height);
                desiredShape.AddArc(objectShape.X - 1, objectShape.Y + objectShape.Height - intensity, intensity, intensity, 90, 90);// canto inferior esquerdo
            }
            else
            {
                desiredShape.AddArc(objectShape.X + objectShape.Width - intensity, objectShape.Y + objectShape.Height - intensity, intensity, intensity, 0, 90); //canto inferior direito
                desiredShape.AddLine(objectShape.X + objectShape.Width, objectShape.Y + objectShape.Height, objectShape.X - 1, objectShape.Y + objectShape.Height);
            }

            return desiredShape;
        }
    }
}
