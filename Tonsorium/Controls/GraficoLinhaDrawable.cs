using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Graphics;


namespace Tonsorium.Controls
{
    public class GraficoLinhaDrawable : IDrawable
    {
        private readonly string[] rotulos;
        private readonly double[] valores;
        private readonly double maximoEixo;

        public GraficoLinhaDrawable(string[] rotulos, double[] valores, double maximoEixo = 100)
        {
            this.rotulos = rotulos;
            this.valores = valores;
            this.maximoEixo = maximoEixo;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            const float margemEsq = 36, margemDir = 12, margemTopo = 12, margemBase = 28;

            float x0 = dirtyRect.Left + margemEsq;
            float x1 = dirtyRect.Right - margemDir;
            float y0 = dirtyRect.Top + margemTopo;
            float y1 = dirtyRect.Bottom - margemBase;

            // Grade horizontal e rótulos do eixo Y (0, 25, 50, 75, 100)
            canvas.FontColor = Colors.White;
            canvas.FontSize = 10;
            canvas.StrokeColor = Color.FromArgb("#333333");
            canvas.StrokeSize = 1;

            for (int g = 0; g <= 4; g++)
            {
                float y = y1 - (y1 - y0) * g / 4f;
                canvas.DrawLine(x0, y, x1, y);
                canvas.DrawString(
                    ((int)(maximoEixo * g / 4)).ToString(),
                    dirtyRect.Left, y - 6, margemEsq - 6, 12,
                    HorizontalAlignment.Right, VerticalAlignment.Center);
            }

            if (valores.Length == 0)
                return;

            // Calcula a posição de cada ponto
            var pontos = new PointF[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                float x = valores.Length == 1
                    ? x0
                    : x0 + (x1 - x0) * i / (valores.Length - 1);
                float y = y1 - (float)(valores[i] / maximoEixo) * (y1 - y0);
                pontos[i] = new PointF(x, y);
            }

            // Linha
            var caminho = new PathF();
            caminho.MoveTo(pontos[0]);
            for (int i = 1; i < pontos.Length; i++)
                caminho.LineTo(pontos[i]);

            canvas.StrokeColor = Color.FromArgb("#f5a623");
            canvas.StrokeSize = 2;
            canvas.DrawPath(caminho);

            // Pontos e rótulos do eixo X
            for (int i = 0; i < pontos.Length; i++)
            {
                canvas.FillColor = Colors.White;
                canvas.FillCircle(pontos[i].X, pontos[i].Y, 3);

                canvas.DrawString(
                    rotulos[i],
                    pontos[i].X - 15, y1 + 6, 30, 16,
                    HorizontalAlignment.Center, VerticalAlignment.Top);
            }
        }
    }
}
