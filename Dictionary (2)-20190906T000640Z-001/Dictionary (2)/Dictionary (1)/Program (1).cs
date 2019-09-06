using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentence:");
            Acronym newAcronym = new Acronym(Console.ReadLine());
            Acronym.displayAcronym();
            Console.ReadLine();
           
        }



    }
    class Acronym
    {
        private string fullSentence { get; set; }
        private static string[] Words { get; set; }
        static Dictionary<char, string> acronymDictionary = new Dictionary<char, string>();

        public Acronym (string sentence)
        {
            fullSentence = sentence;
            Words= sentence.Split();
            BuildAcronym();
        }
        public static void displayAcronym()
        {
            foreach (KeyValuePair<char, string> Elma in acronymDictionary)
            { Console.WriteLine($"\n Key: {Elma.Key} \t {Elma.Value} "); }
            
            
        }
        public static void BuildAcronym()
        {

            for (int Thoru = 0; Thoru <= Words.Length - 1; Thoru++)
            {
                
                char Koboyashi = char.ToUpper((Words[Thoru])[0]);             
                if (!acronymDictionary.ContainsKey(Koboyashi))
                {
                    acronymDictionary.Add(Koboyashi, Words[Thoru]);
                    
                }

                else //if (!acronymDictionary.ContainsKey(char.ToLower(Koboyashi)))
                {
                    acronymDictionary.Add(char.ToLower(Koboyashi), Words[Thoru]);
                }
                //else{ Console.WriteLine($"{Words[Thoru]} was ignored as {Koboyashi} already appears twice in the acronym"); }
                
            
                //This block of code will break if you have a third word that begins with the same letter. 
                // I have two solutions:
                // 1: if you allow the code that has been commented out between 55 and 59 to run, it will skip over the word that breaks the code and continue the loop.
                // 2: you could comment out lines 48 through to 58, and allow line 67 to run instead, it will continue searching through letters of the word until it finds a key that works
               
                // bool lucoa = false; for (int Kanna = 0; Kanna < Thoru; Kanna++) { if (!acronymDictionary.ContainsKey(char.ToUpper(Words[Thoru][Kanna]))) { acronymDictionary.Add(char.ToUpper(Words[Thoru][Kanna]), Words[Thoru]);lucoa = true; break; } else if (!acronymDictionary.ContainsKey(char.ToLower(Words[Thoru][Kanna]))) { acronymDictionary.Add(char.ToLower(Words[Thoru][Kanna]), Words[Thoru]);lucoa = true; break; } } if (lucoa == false){Console.Writeline($"{Words[Thoru]} was ignored as no key could be found");}
                // this code still as some issues. If it can not find a letter, the word will be ignored (this includes one letter words whose letter has been used twice), and longer strings result in a key that seems rather arbitrary to the contents. But it fixes the three letter issue, for instance "Did Alan Make Moles Mix Turnips?" will result in a key of "D A M M I T"
            }


        }
    }
}
