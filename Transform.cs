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
        public static GraphicsPath BorderRadius(Rectangle pRect, int pCanto, bool pTopo, bool pBase)
        {
            GraphicsPath gp = new GraphicsPath();

            if (pTopo)
            {
                gp.AddArc(pRect.X - 1, pRect.Y - 1, pCanto, pCanto, 180, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y - 1, pCanto, pCanto, 270, 90);
            }
            else
            {
                // Se não arredondar o topo, adiciona as linhas para poder fechar o retangulo junto com
                // a base arredondada
                gp.AddLine(pRect.X - 1, pRect.Y - 1, pRect.X + pRect.Width, pRect.Y - 1);
            }

            if (pBase)
            {
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 0, 90);
                gp.AddArc(pRect.X - 1, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 90, 90);
            }
            else
            {
                // Se não arredondar a base, adiciona as linhas para poder fechar o retangulo junto com
                // o topo arredondado. Adiciona da direita para esquerda pois é na ordem contrária que 
                // foi adicionado os arcos do topo. E pra fechar o retangulo tem que desenhar na ordem :
                //  1 - Canto Superior Esquerdo
                //  2 - Canto Superior Direito
                //  3 - Canto Inferior Direito 
                //  4 - Canto Inferior Esquerdo.
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
            }

            return gp;
        }
    }
}
