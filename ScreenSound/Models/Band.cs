using System.Globalization;

namespace ScreenSound.Models;

internal class Band
{
    private readonly List<Album> _albums = [];
    private readonly List<Evaluation> _notes = [];

    #region CONSTRUCTOR
    public Band(string bandName) => BandName = NormalizeBandName(bandName);

    #endregion CONSTRUCTOR

    #region PROPERTIES
    public string? BandName { get; }
    public double Average => _notes.Count == 0 ? 0 : _notes.Average(a => a.Note);
  
    #endregion PROPERTIES

    #region METHODS
    public void AddAlbum(Album album) => _albums.Add(album);

    public void AddNote(Evaluation note) => _notes.Add(note);

    public void ViewDiscography()
    {
        Console.WriteLine($"Discografia da banda {BandName}", ConsoleColor.Green);

        foreach (Album album in _albums)
        {
            Console.WriteLine($" Álbum: {album.AlbumName} com duração total de ({album.TotalDuration}) segundos");
        }
    }

    private static string NormalizeBandName(string value)
    {
        value = value.Trim().ToLowerInvariant();
        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
    }
    #endregion METHODS
}
