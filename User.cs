using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas
{
    public class User
    {
        private string _name;
        private  uint _age;
        public static List<User> listaDeUser;

        public User(string name, uint age) { 
        this._name = name;
        this._age = age;
         listaDeUser = new List<User>();
        }
        public string Name { get => _name; set => _name = value; }
        public uint Age { get => _age; set => _age = value; }

        public static User Adicionar()
        {

            Console.Clear();
            Console.WriteLine("digite o nome do usuario: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("digite a idade do usuario: ");
            uint age = Convert.ToUInt16(Console.ReadLine());
            Console.Clear();
            return new User(name, age);

        
        }

        public static void Salvar(User usuario)
        {
            listaDeUser.Add(usuario);
        }
       
    }
 }
