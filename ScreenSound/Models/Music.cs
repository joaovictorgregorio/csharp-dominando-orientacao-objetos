namespace ScreenSound.Models;

internal class Music
{
    #region CONSTRUCTOR
        public Music(string? musicName, Band? artistic)
        {
            MusicName = musicName;
            Artistic = artistic;
        }
        #endregion CONSTRUCTOR

    public string? MusicName { get; }
    public Band? Artistic { get; }
    public int Duration { get; set; }
    public bool Available { get; set; }
    public string? BriefDescription => $"A música {MusicName} pertence à banda {Artistic?.BandName}";

    #region VIEW TECHNICAL SPECIFICATIONS
    public void ViewTechnicalSpecifications()
    {
        Console.WriteLine($"Ficha técnica: {MusicName}", ConsoleColor.Cyan);

        Console.WriteLine($"Nome: {MusicName}");
        Console.WriteLine($"Artista: {Artistic?.BandName}");
        Console.WriteLine($"Duração: {Duration} segundos");
        Console.WriteLine(Available ? "Disponível no plano!" : "Assine o plano Plus");
        Console.WriteLine($"{BriefDescription}");
    }
    #endregion VIEW TECHNICAL SPECIFICATIONS
}

