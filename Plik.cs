public interface IOperacjeBankowe
{
    void Zdeponuj(double kwota);
    void Wyptac(double kwota);
    double PobierzSaldo();
}

public abstract class KontoBankowe : IOperacjeBankowe
{
    protected double saldo;

    public abstract void StanKonta();
    public abstract void Zdeponuj(double kwota);
    public abstract void Wyptac(double kwota);
}

public class KontoOsobiste : KontoBankowe
{
    public override void Zdeponuj(double kwota)
    {
        saldo += kwota;
    }

    public override void Wyptac(double kwota)
    {
        if (saldo >= kwota)
        {
            saldo -= kwota;
        }
        else
        {
            Console.WriteLine("Brak środków na koncie.");
        }
    }

    public override void StanKonta()
    {
        Console.WriteLine("Stan konta osobistego: " + saldo);
    }

    public override double PobierzSaldo()
    {
        return saldo;
    }
}

public class KontoOszczednosciowe : KontoBankowe
{
    public override void Zdeponuj(double kwota)
    {
        saldo += kwota;
    }

    public override void Wyptac(double kwota)
    {
        if (saldo >= kwota)
        {
            saldo -= kwota;
        }
        else
        {
            Console.WriteLine("Brak środków na koncie.");
        }
    }

    public override void StanKonta()
    {
        Console.WriteLine("Stan konta oszczędnościowego: " + saldo);
    }

    public override double PobierzSaldo()
    {
        return saldo;
    }
}

public class KontoFirmowe : KontoBankowe
{
    public override void Zdeponuj(double kwota)
    {
        saldo += kwota;
    }

    public override void Wyptac(double kwota)
    {
        if (saldo >= kwota)
        {
            saldo -= kwota;
        }
        else
        {
            Console.WriteLine("Brak środków na koncie.");
        }
    }

    public override void StanKonta()
    {
        Console.WriteLine("Stan konta firmowego: " + saldo);
    }

    public override double PobierzSaldo()
    {
        return saldo;
    }
}

public class Klient
{
    private string imie;
    private string nazwisko;
    private List<KontoBankowe> konta = new List<KontoBankowe>();

    public Klient(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public void DodajKonto(KontoBankowe konto)
    {
        konta.Add(konto);
    }

    public void WybierzKonto(int index)
    {
        if (index >=  0 && index < konta.Count)
        {
            konta[index].StanKonta();
        }
        else
        {
            Console.WriteLine("Nieprawidłowy indeks konta.");
        }
    }

    public void WybierzWszystkieKonta()
    {
        foreach (var konto in konta)
        {
            konto.StanKonta();
        }
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {imie}, Nazwisko: {nazwisko}");
    }
}

static void Main(string[] args)
{
    Klient klient = new Klient("Jan", "Kowalski");
    KontoOsobiste kontoOsobiste = new KontoOsobiste();
    KontoOszczednosciowe kontoOszczednosciowe = new KontoOszczednosciowe();
    KontoFirmowe kontoFirmowe = new KontoFirmowe();

    klient.DodajKonto(kontoOsobiste);
    klient.DodajKonto(kontoOszczednosciowe);
    klient.DodajKonto(kontoFirmowe);

    klient.WyswietlInformacje();
    klient.WybierzWszystkieKonta();
}

