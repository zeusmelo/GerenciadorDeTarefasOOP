using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas
{
    internal class GerenciadorMenu
    {
  
        private User usuario;
        
        public GerenciadorMenu(User user)
        { 
            this.usuario = user;
        }
            



        public  void Show()
        { 
            GerenciadorCrud tarefas = new GerenciadorCrud(this.usuario);
            
            char opc;
            Console.Clear();
            Console.WriteLine($"Bem-vindo ao gerenciador de tarefas {usuario.Name}!");
            Thread.Sleep(800);
            Console.Clear();
          
                Console.WriteLine(" 1 PARA ADICIONAR UMA TAREFA \n 2 LISTAR TAREFAS \n 3 ATUALIZAR TAREFAS \n 4 REMOVER TAREFAS \n 5 PARA SALVAR E SAIR ");
                opc = Console.ReadKey(true).KeyChar;

                switch (opc)
                {
                    case '1': tarefas.Adicionar(); break; //adicionar
                    case '2': tarefas.Listar(); break; //listar
                    case '3': tarefas.Atualizar(); break; //atualizar
                    case '4':tarefas.Excluir(); break; //remover
                    case '5': tarefas.Salvar() ; break; //salvar e sair
                    default: break;
                }   
        }
    }
}
