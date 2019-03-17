using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomba
{
    class Program
    {
        static void Main(string[] args)
        {
            string lastCut = "";
            bool failed = false;
            string line = "";
            bool isfrist = true;


            Console.WriteLine("Insira a sucessão de cores:");
            line = Console.ReadLine();


            int i = 0;
            string[] lineArray = line.Split(new[] { "," }, StringSplitOptions.None);
            

            Dictionary<string, Predicate<string>> rules = new Dictionary<string, Predicate<string>>
            {
                { "Branco", c => c != "Branco" && c != "Preto" },
                { "Preto", c => c != "Branco" && c != "Verde" && c != "Laranja" },
                { "Vermelho", c => c == "Verde" },
                { "Laranja", c => c == "Vermelho" || c == "Preto" },
                { "Verde", c => c == "Laranja" || c == "Branco" },
                { "Roxo", c => c != "Roxo" && c != "Verde" && c != "Laranja" && c != "Branco" }
            };
           
            
            while (!string.IsNullOrEmpty(line)&& lineArray.Length > i)
            {
                if (!isfrist)
                {
                    if (!rules[lineArray[i-1]](lineArray[i]))
                    {
                        failed = true;
                        break;
                    }
                    i++;
                    lastCut = line;
                }
                else
                {
                    i++;
                    isfrist = false;
                }
               
            }

            Console.WriteLine(failed ? "Bomba explodiu" : "Bomba desarmada");
            Console.ReadLine();
        }
    }
}
