namespace API;

public interface IVisitDb
{
    public ICollection<Visit> PreviousVisits(int id);
    public void AddVisit(Visit visit);
}