using System;

namespace PasswordGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Password generator = new Password();

            if (args.Length > 1)
            {
                foreach (string argument in args)
                {
                    if ((argument.Length == 2) && (argument == "-h"))
                    {
                        Usage();
                        Environment.Exit(0);
                    }
                    if ((argument.Length > 2) && (argument.StartsWith("-l")))
                    {
                        generator.Lenght=System.Convert.ToInt32(argument.Substring(2));
                    }
                }
            }

            Console.WriteLine(generator.Generate());
        }

        static private void Usage()
        {
            Console.WriteLine("Uso: passwd-gen");
            Console.WriteLine("-l   Lunghezza della password");
            Console.WriteLine("-u   Numero di caratteri maiuscoli");
            Console.WriteLine("-d   Numero di cifre");
            Console.WriteLine("-s   Numero di simboli");
        }
    }
}