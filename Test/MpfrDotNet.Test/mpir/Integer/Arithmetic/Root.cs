namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Root
{
    [Test]
    public void RootExact()
    {
        string AsString;
        bool IsRootExact;

        using mpz_t a = new mpz_t("9785412309485720938412983404349");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9785412309485720938412983404349"));

        IsRootExact = a.IsRootExact(3);

        Assert.IsFalse(IsRootExact);

        mpz_t b = a * a * a;

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549"));

        IsRootExact = b.IsRootExact(3);

        Assert.IsTrue(IsRootExact);
    }

    [Test]
    public void BasicRoot()
    {
        string AsString;

        using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549"));

        mpz_t b = a.NthRoot(3);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("9785412309485720938412983404349"));
    }

    [Test]
    public void RootRemainder()
    {
        string AsString;

        using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320559");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320559"));

        mpz_t.NthRoot(a, 3, out mpz_t root, out mpz_t remainder);

        AsString = root.ToString();
        Assert.That(AsString, Is.EqualTo("9785412309485720938412983404349"));

        AsString = remainder.ToString();
        Assert.That(AsString, Is.EqualTo("10"));
    }

    [Test]
    public void Sqrt()
    {
        string AsString;

        using mpz_t a = new mpz_t("95754294066634670780206802290671646680930214410991689632113801");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("95754294066634670780206802290671646680930214410991689632113801"));

        mpz_t b = a.Sqrt();

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("9785412309485720938412983404349"));
    }

    [Test]
    public void SqrtRemainder()
    {
        string AsString;

        using mpz_t a = new mpz_t("95754294066634670780206802290671646681077131756368025120369720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("95754294066634670780206802290671646681077131756368025120369720"));

        mpz_t.SqrtRemainder(a, out mpz_t root, out mpz_t remainder);

        AsString = root.ToString();
        Assert.That(AsString, Is.EqualTo("9785412309485720938412983404349"));

        AsString = remainder.ToString();
        Assert.That(AsString, Is.EqualTo("146917345376335488255919"));
    }

    [Test]
    public void PerfectPower()
    {
        string AsString;

        using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549"));

        bool IsPerfectPower = a.IsPerfectPower();

        Assert.IsTrue(IsPerfectPower);
    }

    [Test]
    public void PerfectSquare()
    {
        string AsString;

        using mpz_t a = new mpz_t("95754294066634670780206802290671646680930214410991689632113801");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("95754294066634670780206802290671646680930214410991689632113801"));

        bool IsPerfectSquare = a.IsPerfectSquare();

        Assert.IsTrue(IsPerfectSquare);
    }
}
