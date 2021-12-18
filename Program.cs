using System;

namespace PasswordGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Password generator = new Password();
            Password.CharsetEnum charset;

            if (args.Length > 0)
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
                        generator.Lenght = Convert.ToInt32(argument.Substring(2));
                    }

                    if ((argument.Length > 2) && (argument.StartsWith("-u")))
                    {
                        charset = Password.CharsetEnum.UpperCase;
                        generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
                    }
                    if ((argument.Length > 2) && (argument.StartsWith("-d")))
                    {
                        charset = Password.CharsetEnum.Digits;
                        generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
                    }
                    if ((argument.Length > 2) && (argument.StartsWith("-s")))
                    {
                        charset = Password.CharsetEnum.Symbols;
                        generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
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