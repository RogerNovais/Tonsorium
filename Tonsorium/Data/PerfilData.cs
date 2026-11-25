using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class PerfilData
    {
        public static PerfilEstabelecimento StudioBlack => EstabelecimentosData.Obter("Studio Black");
    }

}