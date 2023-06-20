using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas
{
    internal class GerenciadorCrud : GerenciadorMenu
    {
        internal static  List<StringBuilder> listaTarefas;
         public User User { get; set; }
        public GerenciadorCrud(User user) : base(user)
        {
            if (listaTarefas == null)
            listaTarefas = new List<StringBuilder>();
            this.User = user;
           
        }

        public void Adicionar()
        {
            StringBuilder sb = new StringBuilder();
           
            Console.Clear();
            Console.WriteLine("Digite a tarefa a ser realizada");
            string tarefa = Console.ReadLine();
           
            sb.AppendLine(tarefa);

            listaTarefas.Add(sb);
            Show();
        }


        public void Listar()
        {
            Console.Clear();  
            foreach (var tarefa in listaTarefas)
            {
                Console.WriteLine(tarefa);
            }
            Console.WriteLine("Digite qqr tecla para continuar...");
            Console.ReadKey();
            Show();
           
        }

        public void Atualizar()
        {
            StringBuilder sb = new StringBuilder();
            Console.Clear();
            List<StringBuilder> listaTemp = new List<StringBuilder>();
            Console.WriteLine("Digite a tarefa que quer alterar");
            string opc = Console.ReadLine();

            listaTemp = listaTarefas.Where(x => x.ToString().Trim() == opc).ToList();

            if (listaTemp.Count > 0)
            {
                foreach (var itemA in listaTemp)
                {
                    listaTarefas.Remove(itemA); 
                }
                Console.Clear();
                Console.WriteLine(" COMO GOSTARIA DE TORNAR A ATIVIDADE? ");
                opc = Console.ReadLine();
                sb.AppendLine(opc);
                listaTarefas.Add(sb);
                Show();

            }
            else
                Console.WriteLine("NÃO FOI ENCONTRADA ATIVIDADE SELECIONADA, GOSTARIA DE TENTAR NOVAMENTE? [S/N]");
                opc = Console.ReadLine().ToLower();
            if (opc == "s")
                Atualizar();
            else if (opc == "n")
                Show();

           
        }
        
        public void Excluir()
        {
            Console.Clear();
            List<StringBuilder> listaTemp = new List<StringBuilder>();
            Console.WriteLine("Digite a tarefa que quer APAGAR");
            string opc = Console.ReadLine();

            listaTemp = listaTarefas.Where(x => x.ToString().Trim() == opc).ToList();

            if (listaTemp.Count > 0)
            {
                foreach (var itemA in listaTemp)
                {
                    listaTarefas.Remove(itemA);
                }
                Console.Clear();
                Console.WriteLine(" ATIVIDADE EXCLUIDA SOM SUCESSO! RETORNANDO AO MENU... ");
                Thread.Sleep(1000);
                Show();
            }
            else

                Console.WriteLine("NÃO FOI ENCONTRADA ATIVIDADE SELECIONADA, GOSTARIA DE TENTAR NOVAMENTE? [S/N]");
            opc = Console.ReadLine().ToLower();
            if (opc == "s")
                Atualizar();
            else if (opc == "n")
                Show();
        }

        public void Salvar()
        {
            Console.Clear();
            string opc;
            string caminho;
            StreamWriter sr;
            Console.WriteLine("PREPARANDO PARA SALVAR");
            Console.WriteLine("caminho: \"C:\\Users\\sandr\\OneDrive\\Área de Trabalho\\c#\\NOTAS\\ListaDeTarefas.txt\"");
            Thread.Sleep(1000);

            try
            {
                caminho = "C:\\Users\\sandr\\OneDrive\\Área de Trabalho\\c#\\NOTAS\\ListaDeTarefas.txt";
               sr = new StreamWriter(caminho, true);

                if (listaTarefas.Count > 1)
                {
                    uint c = 1;
                    sr.WriteLine("================================================== \n");
                    sr.WriteLine($"USUARIO: {User.Name} IDADE: {User.Age} ANOS \n");
                    foreach (var item in listaTarefas)
                    {
                        sr.WriteLine($"{c}º TAREFA: {item}");
                        c++;
                    }
                    sr.WriteLine("-------------------------------------------------- \n");
                    sr.Close();
                    Console.WriteLine("SALVO COM SUCESSO. FECHANDO APLICATIVO!");
                    Thread.Sleep(6000);
                    System.Environment.Exit(0);
                }
                else if (listaTarefas.Count == 1)
                {
                    
                    sr.WriteLine("================================================== \n");
                    sr.WriteLine($"USUARIO: {User.Name} IDADE: {User.Age} ANOS \n");
                    foreach (var item in listaTarefas)
                    {
                        
                        sr.WriteLine($"TAREFA: {item}");
                        
                    }
                    sr.WriteLine("-------------------------------------------------- \n");
                    sr.Close();
                    Console.WriteLine("SALVO COM SUCESSO. FECHANDO APLICATIVO!");
                    Thread.Sleep(6000);
                    System.Environment.Exit(0);
                }
                else if (listaTarefas.Count <= 0)
                {
                    Console.WriteLine("NÃO FORAM ENCONTRADAS TAREFAS A SEREM SALVAS, GOSTARIA DE TENTAR NOVAMENTE? [s/n]");
                    opc = Console.ReadLine();
                    if (opc == "s")
                    {
                        Salvar();
                    }
                    else if (opc == "n")
                    {
                        Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} DIGITE QQR TECLA PARA CONTINUAR");
                Console.ReadKey(true);
                Salvar();
            }
          
          

        }
        
    }
}

