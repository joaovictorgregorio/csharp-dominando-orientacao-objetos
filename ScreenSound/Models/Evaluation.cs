namespace ScreenSound.Models;

internal class Evaluation
{
    #region CONSTRUCTOR
    public Evaluation(int note)
    {
        Note = Math.Clamp(note, 0, 10);
    }
    #endregion CONSTRUCTOR

    #region PROPERTIES
    public int Note { get; }

    #endregion PROPERTIES

    #region METHODS
    public static Evaluation Parse(string text)
    {
        int note = int.Parse(text);
        return new Evaluation(note);
    }

    #endregion METHODS
}
