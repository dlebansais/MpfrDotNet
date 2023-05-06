﻿namespace Test;

using Interop.Mpfr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpfrDotNet;
using MpirDotNet;

[TestClass]
public class Pow
{
    [TestMethod]
    public void Sqrt()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = a.Sqrt();
        AsString = b.ToString();
        Assert.AreEqual("4.7170947892050068359375E+12", AsString);

        using mpfr_t c = b * b;

        AsString = c.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);
    }

    [TestMethod]
    public void Cbrt()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = a.Cbrt();
        AsString = b.ToString();
        Assert.AreEqual("2.8126545943151724338531494140625E+8", AsString);

        using mpfr_t c = b * b;
        using mpfr_t d = c * b;

        AsString = d.ToString();
        Assert.AreEqual("2.2250983250345032287256576E+25", AsString);
    }

    [TestMethod]
    public void NthRoot()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+25", AsString);

        ulong root = 5040625102UL;
        root >>= 1;

        using mpfr_t b = a.NthRoot(root);
        AsString = b.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.000000023157615543...E+0", AsString);

        using mpfr_t c = b.Sqrt();
        AsString = c.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.000000011578807704...E+0", AsString);

        using mpfr_t d = a.NthRoot(root << 1);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.000000011578807704...E+0", AsString);

        using mpfr_t e = b.Pow(root);
        AsString = e.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+25", AsString);

        using mpfr_t f = c.Pow(root << 1);
        AsString = f.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+25", AsString);

        using mpfr_t g = d.Pow(root << 1);
        AsString = g.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+25", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void SqrtULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        ulong a = 5040625102UL;

        using mpfr_t b = new();

        mpfr.sqrt_ui(b, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = b.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("7.099735982415120765...E+4", AsString);

        using mpfr_t c = new mpfr_t(a);
        AsString = c.ToString();
        Assert.AreEqual("5.040625102E+9", AsString);

        using mpfr_t d = c.Sqrt();
        AsString = d.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("7.099735982415120765...E+4", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void BasicPow()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.229830594288574138772673904895782470703125E+4", AsString);

        using mpfr_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.AreEqual("8.8604270763516055878742474068479142491907987806803106E+565202", AsString);
    }

    [TestMethod]
    public void PowULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250.3450298345029835740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+10", AsString);

        using mpfr_t a2 = 1 / a;
        using mpfr_t a3 = 1 + a2;

        ulong b = 5040625102L;

        using mpfr_t c = a3.Pow(b >> 1);
        AsString = c.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.1199314396039264372253958740...E+0", AsString);

        using mpfr_t d = a3.Pow(b);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.2542464294133231291486886786...E+0", AsString);

        using mpfr_t e = c * c;
        AsString = e.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.2542464294133231291486886786...E+0", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void PowLong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250.3450298345029835740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.AreEqual("2.225098325034502983...E+10", AsString);

        using mpfr_t a2 = 1 / a;
        using mpfr_t a3 = 1 + a2;

        long b = 5040625102L;

        using mpfr_t c = a3.Pow(b >> 1);
        AsString = c.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.1199314396039264372253958740...E+0", AsString);

        using mpfr_t d = a3.Pow(b);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.2542464294133231291486886786...E+0", AsString);

        using mpfr_t e = c * c;
        AsString = e.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("1.2542464294133231291486886786...E+0", AsString);

        using mpfr_t f = a3.Pow(-b);
        AsString = f.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("7.9729148638497816923324220753...E-1", AsString);

        using mpfr_t g = a3.Pow(-(b >> 1));
        AsString = g.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("8.9291180213108291585559055960...E-1", AsString);

        using mpfr_t h = g * g;
        AsString = h.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.AreEqual("7.9729148638497816923324220753...E-1", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void PowZ()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpz_t b = new mpz_t("22298");
        AsString = b.ToString();
        Assert.AreEqual("22298", AsString);

        using mpfr_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.AreEqual("1.5581651739453832511769734040031532442192330006796866E+565195", AsString);
    }

    [TestMethod]
    public void ULongPowULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        ulong a = 986301247803256UL;
        ulong b = 22298UL;

        using mpfr_t c = mpfr_t.Pow(a, b);

        AsString = c.ToString();
        Assert.AreEqual("2.6648454528258509368192958750583861568875146374566282787273685128980843412803682511185309035148027846524877104517073131365307995E+334336", AsString);

        using mpfr_t d = a;
        using mpfr_t e = d.Log();
        using mpfr_t f = c.Log();
        using mpfr_t g = f / e;
        using mpfr_t h = g.Round();

        AsString = h.ToString();
        Assert.AreEqual("2.2298E+4", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void ULongPow()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        ulong a = 986301247803256UL;

        using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.2298305942885740298798745389999999999985533886437633821023176397460230564219474391762787490733899176120758056640625E+4", AsString);

        using mpfr_t c = mpfr_t.Pow(a, b);

        AsString = c.ToString();
        Assert.AreEqual("1.0303448098763502035415852902432875445786186382464386304618764812535941726961877312676131312750681374508882906544257535910622418E+334341", AsString);

        using mpfr_t d = a;
        using mpfr_t e = d.Log();
        using mpfr_t f = c.Log();
        using mpfr_t g = f / e;
        using mpfr_t h = g.Round();

        AsString = h.ToString();
        Assert.AreEqual("2.2298E+4", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void ZetaULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 0x1000;

        ulong a = 9614UL;

        using mpfr_t b = new();

        mpfr.zeta_ui(b, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = b.ToString();
        Assert.AreEqual("1E+0", AsString);

        using mpfr_t c = new mpfr_t(a);
        AsString = c.ToString();
        Assert.AreEqual("9.614E+3", AsString);

        using mpfr_t d = new mpfr_t();
        mpfr.zeta(d, c, mpfr_rnd_t.MPFR_RNDN);

        AsString = d.ToString();
        Assert.AreEqual("1E+0", AsString);

        a >>= 2;

        using mpfr_t e = new();

        mpfr.zeta_ui(e, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = e.ToString();
        Assert.AreEqual("1.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000421619238426975249938818390590971282355264247282423907550479270395856256402329086444130168349909985372689412194692696370514096653365495100192229501451720208297621718531642605854548192567707111691695819566516073451139996505493711413681212905264376674177442557490887822437293308412425126593715001163057802437412292353265208136475919010178905351356121174092425678839901283937627932967644226718867697482677952724944982188979107610997780765090388920248995209975692165240112404067700707648732077550355555746156901329859705101022065567745319341457525670384901701783003711050154869593068257070058611416522983195350186548340652450669529932543312028167577072922117875639688318642436158843107809344660590701852891037617679577485594650490276331703150551147568916784822264151263150817319645637870968855370080503373132331912318532606028735608913696660654302202352299919246756585231433103655932648844245959145504723200555321317099691316384480755458867808189968018753342602207286208591323779880182864448450112545672069928873033147661874784468003022908886316423805617045884774363363426538651573928017883573254446695064336890276231591077030743352643950003899630097306978417435545201651140704669698156891567649177070371304097186744117503970790963769361971405894060634644549870421987089957754316051999723546816074382494785963433349021486979409031141093343279901772171300437737249026441508867892971358403255941651157327052086558111653333451573894296877930049615849323550132718949221695037333621892063684607664323592458871433831685369244761810290330348402285514957295728604891638480618034847094012300262365737836088575872063273925465114560613946798032961730539572413264493105408350585922840095837056266345539135263993029456527662211713433298790024852367213445308183180328320347119571976054673596526202990272184306681543252569515874743391459994330033448149811151448337272164645973223533473887975071097633781288631258410609604141113927572098660524380667618504818525892048788730052314575021576676247175308645037841980764334478693593899710633687377112243150385738630885133696989489635618944594863165322866245555428210878250553825929388132490110293752286140373787099836478633919384302235853693021316128160292632160719696433664291176226652871594751250426413413483103496150749565593330453186686444701962226236723897035414066820884062227297464649161565698076632528029930906581463349886663023575096053705182132442060007682838013792900423306158907093003425846109851174710181037770538678232255195077739021471457007977726227333973398812014448674521015983280010152892997835715900479360556599198086123582826422697286782690138738433419992691822807148436807143867631064428739345497933480474006931441413842813757928592187511465747528715479416135205868629067684677866886822698049862209054257017656063982724876870727320120034035529284320844972916930335083805394498596894795525167551137916890241223452521090794407418632882019201527858499107370521530232010559799673501453354446852989186325345869653296531481933579191099222442339291306241855254612501357939843301455205813404885612674699901888832556490839419550027897726641924345611067133320331800558262881571242264309908798239952587818047483719990480002965983214279211463483319355459741012466027668855734337432370261454392475979083110817369521995479492149482333413705700453652174113386576663609430957326472748273190193710603483612242570188755053095519542694091796875E+0", AsString);

        using mpfr_t f = new mpfr_t(a);
        AsString = f.ToString();
        Assert.AreEqual("2.403E+3", AsString);

        using mpfr_t g = new mpfr_t();
        mpfr.zeta(g, f, mpfr_rnd_t.MPFR_RNDN);

        AsString = g.ToString();
        Assert.AreEqual("1.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000421619238426975249938818390590971282355264247282423907550479270395856256402329086444130168349909985372689412194692696370514096653365495100192229501451720208297621718531642605854548192567707111691695819566516073451139996505493711413681212905264376674177442557490887822437293308412425126593715001163057802437412292353265208136475919010178905351356121174092425678839901283937627932967644226718867697482677952724944982188979107610997780765090388920248995209975692165240112404067700707648732077550355555746156901329859705101022065567745319341457525670384901701783003711050154869593068257070058611416522983195350186548340652450669529932543312028167577072922117875639688318642436158843107809344660590701852891037617679577485594650490276331703150551147568916784822264151263150817319645637870968855370080503373132331912318532606028735608913696660654302202352299919246756585231433103655932648844245959145504723200555321317099691316384480755458867808189968018753342602207286208591323779880182864448450112545672069928873033147661874784468003022908886316423805617045884774363363426538651573928017883573254446695064336890276231591077030743352643950003899630097306978417435545201651140704669698156891567649177070371304097186744117503970790963769361971405894060634644549870421987089957754316051999723546816074382494785963433349021486979409031141093343279901772171300437737249026441508867892971358403255941651157327052086558111653333451573894296877930049615849323550132718949221695037333621892063684607664323592458871433831685369244761810290330348402285514957295728604891638480618034847094012300262365737836088575872063273925465114560613946798032961730539572413264493105408350585922840095837056266345539135263993029456527662211713433298790024852367213445308183180328320347119571976054673596526202990272184306681543252569515874743391459994330033448149811151448337272164645973223533473887975071097633781288631258410609604141113927572098660524380667618504818525892048788730052314575021576676247175308645037841980764334478693593899710633687377112243150385738630885133696989489635618944594863165322866245555428210878250553825929388132490110293752286140373787099836478633919384302235853693021316128160292632160719696433664291176226652871594751250426413413483103496150749565593330453186686444701962226236723897035414066820884062227297464649161565698076632528029930906581463349886663023575096053705182132442060007682838013792900423306158907093003425846109851174710181037770538678232255195077739021471457007977726227333973398812014448674521015983280010152892997835715900479360556599198086123582826422697286782690138738433419992691822807148436807143867631064428739345497933480474006931441413842813757928592187511465747528715479416135205868629067684677866886822698049862209054257017656063982724876870727320120034035529284320844972916930335083805394498596894795525167551137916890241223452521090794407418632882019201527858499107370521530232010559799673501453354446852989186325345869653296531481933579191099222442339291306241855254612501357939843301455205813404885612674699901888832556490839419550027897726641924345611067133320331800558262881571242264309908798239952587818047483719990480002965983214279211463483319355459741012466027668855734337432370261454392475979083110817369521995479492149482333413705700453652174113386576663609430957326472748273190193710603483612242570188755053095519542694091796875E+0", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}