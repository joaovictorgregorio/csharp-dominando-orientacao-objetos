using ScreenSound.Data;
using ScreenSound.Models;
using ScreenSound.UI;

var registeredBands = AppDataSeeder.CreateRegisterBands();

#region RETURN TO MENU
void ReturnToMenu()
{
    Console.WriteLine();
    ConsoleUi.PrintColored("  Pressione qualquer tecla para voltar ao menu...", ConsoleColor.DarkGray);
    Console.ReadKey(intercept: true);

    ShowTitleApplication();
    DisplayMenuOptions();
}
#endregion RETURN TO MENU

#region SHOW TITLE APPLICATION
void ShowTitleApplication()
{
    Console.Clear();

    string titleApplication = @"
▒█▀▀▀█ █▀▀ █▀▀█ █▀▀ █▀▀ █▀▀▄ 　 ▒█▀▀▀█ █▀▀█ █░░█ █▀▀▄ █▀▀▄                             
░▀▀▀▄▄ █░░ █▄▄▀ █▀▀ █▀▀ █░░█ 　 ░▀▀▀▄▄ █░░█ █░░█ █░░█ █░░█ 
▒█▄▄▄█ ▀▀▀ ▀░▀▀ ▀▀▀ ▀▀▀ ▀░░▀ 　 ▒█▄▄▄█ ▀▀▀▀ ░▀▀▀ ▀░░▀ ▀▀▀░";

    ConsoleUi.PrintColored(titleApplication, ConsoleColor.Cyan);
}
#endregion SHOW TITLE APPLICATION

#region DISPLAY MENU OPTIONS
void DisplayMenuOptions()
{
    ConsoleUi.ShowSectionHeader("                     MENU PRINCIPAL");

    ConsoleUi.TypeLine("                  [1] Registrar banda", ConsoleColor.White);
    ConsoleUi.TypeLine("                  [2] Registrar álbum da banda", ConsoleColor.White);
    ConsoleUi.TypeLine("                  [3] Listar todas as bandas", ConsoleColor.White);
    ConsoleUi.TypeLine("                  [4] Avaliar uma banda", ConsoleColor.White);
    ConsoleUi.TypeLine("                  [5] Exibir detalhes da banda", ConsoleColor.White);
    ConsoleUi.TypeLine("                  [0] Sair", ConsoleColor.Red);

    Console.WriteLine();

    int optionChosen;
    do
    {
        Console.Write("Escolha uma opção: ");

        if (!int.TryParse(Console.ReadLine(), out optionChosen) || optionChosen < 0 || optionChosen > 5)
        {
            ConsoleUi.TypeLine("  ⚠  Opção inválida. Digite um número entre 0 e 5.", ConsoleColor.Red, 10);
            optionChosen = -1;
        }
    } while (optionChosen < 0 || optionChosen > 5);

    HandleMenuOption(optionChosen);
}
#endregion DISPLAY MENU OPTIONS

#region HANDLE MENU OPTION
void HandleMenuOption(int option)
{
    switch (option)
    {
        case 1:
            RegisterBand();
            break;

        case 2:
            RegisterAlbumBand();
            break;

        case 3:
            ListAllBands();
            break;

        case 4:
            EvaluateBand();
            break;

        case 5:
            DisplayBandDetails();
            break;

        case 0:
            ExitApplication();
            break;

        default:
            ConsoleUi.TypeLine("OPÇÃO INVÁLIDA. TENTE NOVAMENTE", ConsoleColor.Red, 30);
            ShowTitleApplication();
            DisplayMenuOptions();
            break;
    }
}
#endregion HANDLE MENU OPTION

#region REGISTER BAND
void RegisterBand()
{
    ShowTitleApplication();
    ConsoleUi.ShowSectionHeader("                     REGISTRO DE BANDAS");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName)) 
            ConsoleUi.TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    var band = new Band(bandName);
    registeredBands.Add(bandName, band);

    Console.WriteLine();
    ConsoleUi.TypeLine($"  ✔  \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);

    ReturnToMenu();
}
#endregion REGISTER BAND

#region REGISTER ALBUM BAND
void RegisterAlbumBand()
{
    ShowTitleApplication();
    ConsoleUi.ShowSectionHeader("                     REGISTRO ÁLBUM DA BANDA");

    string bandName;
    string albumTitle;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            ConsoleUi.TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

        if (!registeredBands.ContainsKey(bandName))
        {
            Console.WriteLine();
            ConsoleUi.TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
            ReturnToMenu();
            return;
        }
        else
        {
            Console.Write("  Nome do álbum da banda: ");
            albumTitle = Console.ReadLine()!.Trim();

            if (string.IsNullOrWhiteSpace(albumTitle))
                ConsoleUi.TypeLine("  ⚠  O álbum não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

            var band = registeredBands[bandName];
            band.AddAlbum(new Album(albumTitle));

            Console.WriteLine();
            ConsoleUi.TypeLine($"  ✔  O álbum \"{albumTitle}\" da banda \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);
        }

    } while (string.IsNullOrWhiteSpace(bandName));

    ReturnToMenu();
}

#endregion REGISTER ALBUM BAND

#region LIST ALL BANDS
void ListAllBands()
{
    ShowTitleApplication();
    ConsoleUi.ShowSectionHeader("                     LISTA DE BANDAS");

    if (registeredBands.Count == 0)
    {
        ConsoleUi.TypeLine("  ⚠  Nenhuma banda registrada ainda.", ConsoleColor.DarkGray, 20);
    }
    else
    {
        ConsoleUi.PrintColored($"  {registeredBands.Count} banda(s) registrada(s):\n", ConsoleColor.DarkGray);

        int index = 1;
        foreach(string band in registeredBands.Keys)
            ConsoleUi.TypeLine($"  [{index++}] {band}", ConsoleColor.Cyan, 15);
    }

    ReturnToMenu();
}
#endregion LIST ALL BANDS

#region EVALUATE BAND
void EvaluateBand()
{
    ShowTitleApplication();
    ConsoleUi.ShowSectionHeader("                     AVALIAÇÃO DE BANDAS");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            ConsoleUi.TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    if (!registeredBands.ContainsKey(bandName))
    {
        Console.WriteLine();
        ConsoleUi.TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
        ReturnToMenu();
        return;
    }

    Evaluation? note = null;
    do
    {
        Console.Write("  Nota (0 a 10): ");

        if (!int.TryParse(Console.ReadLine(), out int noteValue) || noteValue < 0 || noteValue > 10)
        {
            ConsoleUi.TypeLine("  ⚠  Nota inválida. Digite um número entre 0 e 10.", ConsoleColor.Red, 10);
            continue;
        }

        note = new Evaluation(noteValue);

    } while (note is null);

    var band = registeredBands[bandName];
    band.AddNote(note);

    Console.WriteLine();
    ConsoleUi.TypeLine($"  ✔  Nota {note.Note} para \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);

    ReturnToMenu();
}
#endregion EVALUATE BAND

#region DISPLAY BAND DETAILS
void DisplayBandDetails()
{
    ShowTitleApplication();
    ConsoleUi.ShowSectionHeader("                     DETALHES DA BANDA");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            ConsoleUi.TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    if (!registeredBands.ContainsKey(bandName))
    {
        Console.WriteLine();
        ConsoleUi.TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
        ReturnToMenu();
        return;
    }

    var band = registeredBands[bandName];
    Console.WriteLine();
    ConsoleUi.TypeLine($"  📝  A média da banda \"{bandName}\" é {band.Average}", ConsoleColor.Blue, 10);

    ReturnToMenu();

}
#endregion DISPLAY BAND DETAILS

#region EXIT APPLICATION 
void ExitApplication()
{
    ShowTitleApplication();
    Console.WriteLine();

    ConsoleUi.TypeLine("  Obrigado por usar o Screen Sound! 🎵", ConsoleColor.Cyan, 20);
    ConsoleUi.TypeLine("  Até a próxima!", ConsoleColor.Yellow, 20);
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("  Encerrando");
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(300);
        Console.Write(".");
    }
    Console.ResetColor();

    Thread.Sleep(800);
    Console.Clear();
}
#endregion EXIT APPLICATION


ShowTitleApplication();
DisplayMenuOptions();