
public class CommandAndOtherWords
{
    public Util.Command command;
    public Util.Noun noun;
    public int numWords = 1;

    public override string ToString()
    {
        return numWords + "words:: command = " + command.ToString() + ", noun = " + noun.ToString();
    }
}
