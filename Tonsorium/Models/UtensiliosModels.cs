using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tonsorium.Models
{
    public class Utensilio : INotifyPropertyChanged
    {
        public string Numero { get; set; } = "";
        public string Icone { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string ParaQueServe { get; set; } = "";
        public string ComoUsar { get; set; } = "";
        public string Dica { get; set; } = "";

        private bool expandido;
        public bool Expandido
        {
            get => expandido;
            set
            {
                if (expandido == value) return;
                expandido = value;
                OnPropertyChanged();            // atualiza o IsVisible dos detalhes
                OnPropertyChanged(nameof(Sinal)); // atualiza o + / −
            }
        }

        public string Sinal => Expandido ? "−" : "+";

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? nome = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }

    public class DicaUtensilio
    {
        public string Numero { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Texto { get; set; } = "";
    }
}
