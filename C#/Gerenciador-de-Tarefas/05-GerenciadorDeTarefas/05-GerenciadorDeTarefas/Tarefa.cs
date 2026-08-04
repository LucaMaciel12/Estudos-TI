using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GerenciadorDeTarefas
{
    public class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public override string ToString()
        {
            return $"{Titulo} - {(Concluida ? "Concluída" : "Pendente")}";
        }
    }
}
