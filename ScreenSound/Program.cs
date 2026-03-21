using ScreenSound.Models;

#region APPLICATION DATA

Dictionary<string, Band> registeredBands = new(StringComparer.OrdinalIgnoreCase);

// Criar as bandas
var ira = new Band("Ira");
ira.AddNote(10);
ira.AddNote(9);
ira.AddNote(6);
registeredBands.Add(ira.BandName, ira);

var beatles = new Band("The Beatles");
beatles.AddNote(8);
beatles.AddNote(9);
registeredBands.Add(beatles.BandName, beatles);

var theWho = new Band("The Who");
theWho.AddNote(7);
theWho.AddNote(8);
theWho.AddNote(9);
registeredBands.Add(theWho.BandName, theWho);

#endregion APPLICATION DATA

#region PRINT COLORED
void PrintColored(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}
#endregion PRINT COLORED

#region TYPE LINE
void TypeLine(string text, ConsoleColor color = ConsoleColor.White, int delayMs = 0)
{
    Console.ForegroundColor = color;
    foreach (char c in text)
    {
        Console.Write(c);
        Thread.Sleep(delayMs);
    }

    Console.WriteLine();
    Console.ResetColor();
}
#endregion TYPE LINE

#region SHOW SECTION HEADER
void ShowSectionHeader(string title)
{
    Console.WriteLine();
    PrintColored(title, ConsoleColor.Yellow);
    Console.WriteLine();
}
#endregion SHOW SECTION HEADER

#region RETURN TO MENU
void ReturnToMenu()
{
    Console.WriteLine();
    PrintColored("  Pressione qualquer tecla para voltar ao menu...", ConsoleColor.DarkGray);
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

    PrintColored(titleApplication, ConsoleColor.Cyan);
}
#endregion SHOW TITLE APPLICATION

#region DISPLAY MENU OPTIONS
void DisplayMenuOptions()
{
    ShowSectionHeader("                     MENU PRINCIPAL");

    TypeLine("                  [1] Registrar banda", ConsoleColor.White);
    TypeLine("                  [2] Registrar álbum da banda", ConsoleColor.White);
    TypeLine("                  [3] Listar todas as bandas", ConsoleColor.White);
    TypeLine("                  [4] Avaliar uma banda", ConsoleColor.White);
    TypeLine("                  [5] Exibir detalhes da banda", ConsoleColor.White);
    TypeLine("                  [0] Sair", ConsoleColor.Red);

    Console.WriteLine();

    int optionChosen;
    do
    {
        Console.Write("Escolha uma opção: ");

        if (!int.TryParse(Console.ReadLine(), out optionChosen) || optionChosen < 0 || optionChosen > 5)
        {
            TypeLine("  ⚠  Opção inválida. Digite um número entre 0 e 5.", ConsoleColor.Red, 10);
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
            TypeLine("OPÇÃO INVÁLIDA. TENTE NOVAMENTE", ConsoleColor.Red, 30);
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
    ShowSectionHeader("                     REGISTRO DE BANDAS");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName)) 
            TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    var band = new Band(bandName);
    registeredBands.Add(bandName, band);

    Console.WriteLine();
    TypeLine($"  ✔  \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);

    ReturnToMenu();
}
#endregion REGISTER BAND

#region REGISTER ALBUM BAND
void RegisterAlbumBand()
{
    ShowTitleApplication();
    ShowSectionHeader("                     REGISTRO ÁLBUM DA BANDA");

    string bandName;
    string albumTitle;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

        if (!registeredBands.ContainsKey(bandName))
        {
            Console.WriteLine();
            TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
            ReturnToMenu();
            return;
        }
        else
        {
            Console.Write("  Nome do álbum da banda: ");
            albumTitle = Console.ReadLine()!.Trim();

            if (string.IsNullOrWhiteSpace(albumTitle))
                TypeLine("  ⚠  O álbum não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

            var band = registeredBands[bandName];
            band.AddAlbum(new Album(albumTitle));

            Console.WriteLine();
            TypeLine($"  ✔  O álbum \"{albumTitle}\" da banda \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);
        }

    } while (string.IsNullOrWhiteSpace(bandName));

    ReturnToMenu();
}

#endregion REGISTER ALBUM BAND

#region LIST ALL BANDS
void ListAllBands()
{
    ShowTitleApplication();
    ShowSectionHeader("                     LISTA DE BANDAS");

    if (registeredBands.Count == 0)
    {
        TypeLine("  ⚠  Nenhuma banda registrada ainda.", ConsoleColor.DarkGray, 20);
    }
    else
    {
        PrintColored($"  {registeredBands.Count} banda(s) registrada(s):\n", ConsoleColor.DarkGray);

        int index = 1;
        foreach(string band in registeredBands.Keys)
            TypeLine($"  [{index++}] {band}", ConsoleColor.Cyan, 15);
    }

    ReturnToMenu();
}
#endregion LIST ALL BANDS

#region EVALUATE BAND
void EvaluateBand()
{
    ShowTitleApplication();
    ShowSectionHeader("                     AVALIAÇÃO DE BANDAS");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    if (!registeredBands.ContainsKey(bandName))
    {
        Console.WriteLine();
        TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
        ReturnToMenu();
        return;
    }

    int note;
    do
    {
        Console.Write("  Nota (0 a 10): ");

        if (!int.TryParse(Console.ReadLine(), out note) || note < 0 || note > 10)
        {
            TypeLine("  ⚠  Nota inválida. Digite um número entre 0 e 10.", ConsoleColor.Red, 10);
            note = -1;
        }

    } while (note < 0 || note > 10);

    var band = registeredBands[bandName];
    band.AddNote(note);

    Console.WriteLine();
    TypeLine($"  ✔  Nota {note} para \"{bandName}\" registrada com sucesso!", ConsoleColor.Green, 20);

    ReturnToMenu();
}
#endregion EVALUATE BAND

#region DISPLAY BAND DETAILS
void DisplayBandDetails()
{
    ShowTitleApplication();
    ShowSectionHeader("                     DETALHES DA BANDA");

    string bandName;
    do
    {
        Console.Write("  Nome da banda: ");
        bandName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(bandName))
            TypeLine("  ⚠  O nome não pode ser vazio. Tente novamente.", ConsoleColor.Red, 10);

    } while (string.IsNullOrWhiteSpace(bandName));

    if (!registeredBands.ContainsKey(bandName))
    {
        Console.WriteLine();
        TypeLine($"  ⚠  A banda \"{bandName}\" não foi encontrada.", ConsoleColor.Red, 10);
        ReturnToMenu();
        return;
    }

    var band = registeredBands[bandName];
    Console.WriteLine();
    TypeLine($"  📝  A média da banda \"{bandName}\" é {band.Average}", ConsoleColor.Blue, 10);

    ReturnToMenu();

}
#endregion DISPLAY BAND DETAILS

#region EXIT APPLICATION 
void ExitApplication()
{
    ShowTitleApplication();
    Console.WriteLine();

    TypeLine("  Obrigado por usar o Screen Sound! 🎵", ConsoleColor.Cyan, 35);
    TypeLine("  Até a próxima!", ConsoleColor.Yellow, 35);
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("  Encerrando");
    for (int i = 0; i < 3; i++)
    {
        Thread.Sleep(500);
        Console.Write(".");
    }
    Console.ResetColor();

    Thread.Sleep(800);
    Console.Clear();
}
#endregion EXIT APPLICATION


ShowTitleApplication();
DisplayMenuOptions();