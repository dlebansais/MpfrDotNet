namespace TestRational;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Shift
{
    [Test]
    public void ShiftLeft()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = a << 257;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("51529756762839593294198211100314734677817449692818126743552213301752723958667489051678620805933418286778280669347840/115756986668303657898962467957"));

        using mpq_t c = b >> 257;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }

    [Test]
    public void ShiftRight()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = a >> 257;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("27813729062931287293128729467536730715/3350935832534759576070266789807748551319412728141912585771923360591451658754903229238641121083138336882688"));

        using mpq_t c = b << 257;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }
}
