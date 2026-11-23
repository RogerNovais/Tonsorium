using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class CabelosData
    {
        public static List<TipoCabelo> Tipos() => new()
    {
        new TipoCabelo
        {
            Numero = "01",
            Nome = "Cabelo Liso",
            Descricao = "Fios com pouca ou nenhuma curvatura, proporcionando uma aparência uniforme.",
            Caracteristicas = "A oleosidade do couro cabeludo percorre o fio com facilidade, por isso a lavagem costuma ser mais frequente. Cortes de linhas retas ficam bem definidos.",
            Subtipos = new()
            {
                new Subtipo { Codigo = "1A", Nome = "Liso fino", Descricao = "Fios finos, brilhosos e sedosos. Tendem a oleosidade rápida e pouco volume." },
                new Subtipo { Codigo = "1B", Nome = "Liso médio", Descricao = "Espessura média, com mais corpo e volume que o 1A." },
                new Subtipo { Codigo = "1C", Nome = "Liso grosso", Descricao = "Fios grossos e resistentes, com mais volume e maior dificuldade para modelar." },
            }
        },
        new TipoCabelo
        {
            Numero = "02",
            Nome = "Cabelo Ondulado",
            Descricao = "Fios que apresentam ondas naturais, geralmente formando desenhos em S.",
            Caracteristicas = "Equilibra volume e definição, mas tende ao frizz quando está seco ou sem hidratação. Responde bem a produtos leves.",
            Subtipos = new()
            {
                new Subtipo { Codigo = "2A", Nome = "Ondas suaves", Descricao = "Ondas leves, presentes principalmente na parte de baixo do fio. Fios finos e fáceis de alisar." },
                new Subtipo { Codigo = "2B", Nome = "Ondas definidas", Descricao = "Formato de S mais visível do meio ao comprimento, com volume moderado." },
                new Subtipo { Codigo = "2C", Nome = "Ondas fortes", Descricao = "Ondas bem marcadas e volumosas, com tendência a frizz. Aproxima-se do cacheado." },
            }
        },
        new TipoCabelo
        {
            Numero = "03",
            Nome = "Cabelo Cacheado",
            Descricao = "Curvaturas mais definidas que formam cachos naturais ao longo dos fios.",
            Caracteristicas = "Volume natural e personalidade marcante. A hidratação é essencial, porque as curvas dificultam a distribuição da oleosidade pelo fio.",
            Subtipos = new()
            {
                new Subtipo { Codigo = "3A", Nome = "Cachos soltos", Descricao = "Cachos amplos, em S ou espiral grande, com brilho e pouco volume." },
                new Subtipo { Codigo = "3B", Nome = "Cachos médios", Descricao = "Espirais de tamanho médio, com boa definição e volume considerável." },
                new Subtipo { Codigo = "3C", Nome = "Cachos apertados", Descricao = "Cachos fechados em formato de saca-rolha, com muito volume e tendência a ressecamento." },
            }
        },
        new TipoCabelo
        {
            Numero = "04",
            Nome = "Cabelo Crespo",
            Descricao = "Fios com curvaturas mais fechadas, formando diferentes padrões naturais.",
            Caracteristicas = "É o tipo com mais volume e maior encolhimento. Exige hidratação constante e manejo cuidadoso, porque as curvas fechadas são mais frágeis.",
            Subtipos = new()
            {
                new Subtipo { Codigo = "4A", Nome = "Crespo em S", Descricao = "Curvatura fechada com padrão em S pequeno e bem definido. Encolhimento significativo." },
                new Subtipo { Codigo = "4B", Nome = "Crespo em Z", Descricao = "Curvas angulosas em zigue-zague, com padrão menos definido e maior fragilidade." },
                new Subtipo { Codigo = "4C", Nome = "Crespo fechado", Descricao = "Padrão em Z muito fechado, com maior encolhimento e necessidade de hidratação intensa." },
            }
        },
    };

        public static List<CurvaturaCabelo> Curvaturas() => new()
    {
        new CurvaturaCabelo
        {
            Numero = "1",
            Nome = "Liso",
            Descricao = "Fios sem curvatura significativa.",
            Vantagens = new()
            {
                "Manutenção simples e secagem rápida.",
                "Os produtos rendem mais, pois distribuem-se com facilidade.",
                "Cortes retos se mantêm alinhados por mais tempo.",
            },
            Desvantagens = new()
            {
                "Pouco volume natural, o que exige finalização.",
                "A oleosidade aparece mais cedo na raiz.",
                "Pode achatar com facilidade e perder movimento.",
            }
        },
        new CurvaturaCabelo
        {
            Numero = "2",
            Nome = "Ondulado",
            Descricao = "Ondas naturais ao longo dos fios.",
            Vantagens = new()
            {
                "Equilíbrio entre volume e definição.",
                "Versátil: funciona liso ou com ondas.",
                "Menos frizz que os cabelos cacheados e crespos.",
            },
            Desvantagens = new()
            {
                "Frizz quando seco ou sem hidratação.",
                "Perde definição se for lavado com excesso de secagem.",
                "Exige técnica de finalização para manter as ondas.",
            }
        },
        new CurvaturaCabelo
        {
            Numero = "3",
            Nome = "Cacheado",
            Descricao = "Cachos definidos e variados.",
            Vantagens = new()
            {
                "Volume e definição naturais.",
                "Dispensa alisamento e chapinha para ficar bonito.",
                "Técnicas de lavagem suave preservam a forma dos cachos.",
            },
            Desvantagens = new()
            {
                "Ressecamento e quebra sem hidratação frequente.",
                "Exige mais tempo de cuidado e de secagem.",
                "Frizz e encolhimento em clima úmido.",
            }
        },
        new CurvaturaCabelo
        {
            Numero = "4",
            Nome = "Crespo",
            Descricao = "Curvaturas fechadas e variadas.",
            Vantagens = new()
            {
                "Volume e resistência natural.",
                "Grande variedade de estilos sem química.",
                "Identidade e personalidade marcantes.",
            },
            Desvantagens = new()
            {
                "Curvas mais frágeis: exige hidratação e cuidado para evitar quebra.",
                "Encolhimento grande, que dificulta perceber o comprimento real.",
                "Produtos e profissionais especializados nem sempre são fáceis de encontrar.",
            }
        },
    };
    }
}
