namespace ScreenSound.Models;

internal class Album
{
    private List<Music> _songs = [];

    #region CONSTRUCTOR
    public Album(string? albumName) => AlbumName = albumName;

    #endregion CONSTRUCTOR

    public string? AlbumName { get; }
    public int TotalDuration => _songs.Sum(m => m.Duration);

    #region ADD MUSIC
    public void AddMusic(Music music) => _songs.Add(music);

    #endregion ADD MUSIC

    #region SHOW ALBUM SONGS
    public void ShowAlbumSongs()
    {
        Console.WriteLine($"Lista de músicas do álbum {AlbumName}", ConsoleColor.Yellow);

        foreach (var music in _songs)
        {
            Console.WriteLine($"  Música: {music.MusicName}");
        }

        Console.WriteLine($"\n Para ouvir este álbum completo é necessário: {TotalDuration} segundos");
    }
    #endregion SHOW ALBUM SONGS
}
