using Translator.Model;
using Translator.ViewModel;

namespace Translator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            MainForm view = new();
            LexemeParser model = new();
            TranslatorViewModel viewModel = new(view, model);

            Application.Run(view);

        }
    }
}