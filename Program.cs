using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
           User usuario = User.Adicionar();
           User.Salvar(usuario);
            GerenciadorMenu gerenciador = new GerenciadorMenu(usuario);
            gerenciador.Show();
            Console.ReadKey();
        }
    }
}
