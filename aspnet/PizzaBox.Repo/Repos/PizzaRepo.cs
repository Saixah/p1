using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class PizzaRepo
  {
    private PizzaBoxContext _context;
    public PizzaRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }

  }
}
