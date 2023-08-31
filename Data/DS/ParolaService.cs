using Data.DTO;

namespace Data.DS
{
    public class ParolaService
    {
        public List<Gruppo> GetFullGroupsIndex()
        {
            using (var c = new DiarioContext())
            {
                var lst = c.Gruppi.ToList();
                foreach (Gruppo g in lst)
                {
                    g.libri.AddRange(c.Libri.Where(x=>x.gruppo==g.Id).ToList());
                }
                return lst;
            }
        }
    }
}