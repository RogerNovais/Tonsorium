using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tonsorium.Models
{
    public abstract class ItemExpansivel : INotifyPropertyChanged
    {
        private bool expandido;
        public bool Expandido
        {
            get => expandido;
            set
            {
                if (expandido == value) return;
                expandido = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Sinal));
            }
        }

        public string Sinal => Expandido ? "−" : "+";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? nome = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }

    public class Subtipo
    {
        public string Codigo { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
    }

    public class TipoCabelo : ItemExpansivel
    {
        public string Numero { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Caracteristicas { get; set; } = "";
        public List<Subtipo> Subtipos { get; set; } = new();
    }

    public class CurvaturaCabelo : ItemExpansivel
    {
        public string Numero { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public List<string> Vantagens { get; set; } = new();
        public List<string> Desvantagens { get; set; } = new();
    }
}
