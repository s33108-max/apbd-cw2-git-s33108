namespace APBDzadanie2.Serwisy;

public class KalkulatorKar : IKalkulatorKar
{
    public decimal ObliczKare(DateTime planowanaDataZwrotu, DateTime faktycznaDataZwrotu)
    {
        
        if (faktycznaDataZwrotu <= planowanaDataZwrotu)
        {
            return 0m; 
        }
        
        TimeSpan spoznienie = faktycznaDataZwrotu - planowanaDataZwrotu;
        int dniKary = spoznienie.Days + 1;
        decimal stawkaDzienna = 10m;
        
        return dniKary * stawkaDzienna;
    }
}
