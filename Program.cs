using System;

namespace PasswordGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Password generator = new Password();
            
            if (args.Length > 0)
            {
                foreach (string argument in args)
                {
                    bool argIsValid = false;

                    if ((argument.Length == 2) && ((argument == "-h") || (argument == "--help")))
                    {
                        Usage();
                        Environment.Exit(0);
                    }
                    try
                    {
                        if ((argument.Length > 2) && (argument.StartsWith("-l")))
                        {
                            generator.Lenght = Convert.ToInt32(argument.Substring(2));
                            argIsValid = true;
                        }
                        if ((argument.Length > 2) && (argument.StartsWith("-u")))
                        {
                            charset = Password.CharsetEnum.UpperCase;
                            generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
                            argIsValid = true;
                        }
                        if ((argument.Length > 2) && (argument.StartsWith("-d")))
                        {
                            charset = Password.CharsetEnum.Digits;
                            generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
                            argIsValid = true;
                        }
                        if ((argument.Length > 2) && (argument.StartsWith("-s")))
                        {
                            charset = Password.CharsetEnum.Symbols;
                            generator.Tricky(Convert.ToInt32(argument.Substring(2)), charset);
                            argIsValid = true;
                        }

                        if (!argIsValid)
                        {
                            Console.WriteLine("Errore nel parametro " + argument);
                            Console.WriteLine();
                            Usage();
                            Environment.Exit(1);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Valore nel parametro {0} errato", argument);
                        Environment.Exit(2);
                    }
                }
            }

            Password.CharsetEnum charset;
            Console.WriteLine(generator.Generate());
        }

        static private void Usage()
        {
            Console.WriteLine("Uso: passwd-gen [args]");
            Console.WriteLine("-l   Lunghezza della password");
            Console.WriteLine("-u   Numero di caratteri maiuscoli");
            Console.WriteLine("-d   Numero di cifre");
            Console.WriteLine("-s   Numero di simboli");
        }
    }
}