using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Data
{
    public static class DesempenhoData
    {
        public static readonly string[] Meses =
            { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };

        // ESTIMATIVA a partir da imagem. Substituir pelos dados reais de clientes atendidos por mês.
        public static readonly double[] ClientesPorMes =
            { 40, 52, 61, 68, 74, 80, 86, 90, 84, 79, 82, 86 };
    }
}
