using System;

namespace TemplateFor_ImprovingTheConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string promt = "Условный вопрос, на который вы должны ответить.";
            string[] options = { "Типа", "Варианты", "Ответов" };
            Menu menu = new Menu(promt, options);

            int selectedIndex = menu.Vote();

            Console.ReadKey();

            //И типа в зависимости от выбранного selectedIndex -> вы идёте дальше.
        }
    }

    public class Menu
    {
        public int SelectedIndex { get; set; }
        private string[] Options { get; set; }
        private string Promt { get; set; }

        public Menu(string promt, string[] options)
        {
            this.Promt = promt;
            this.Options = options;
            this.SelectedIndex = 1;

        }




        public int Vote()
        {

            ConsoleKey consoleKey;

            do
            {
                Console.Clear();
                Display();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                consoleKey = consoleKeyInfo.Key;

                if (consoleKey == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0 || SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
                else if (consoleKey == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex < 0 || SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (consoleKey != ConsoleKey.Enter);


            return SelectedIndex;
        }

        private void Display()
        {
            Console.WriteLine(Promt);


            for (int i = 0; i < Options.Length; i++)
            {
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = string.Empty;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix} {Options[i]}");
            }
            Console.ResetColor();
        }

    }
}
