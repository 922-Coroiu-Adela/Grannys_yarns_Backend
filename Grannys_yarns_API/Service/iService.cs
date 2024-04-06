using Grannys_yarns_API.Model;

namespace Grannys_yarns_API.Service
{
    public interface iService
    {
        public void AddYarn(Yarn yarn);
        public void UpdateYarn(Yarn updatedYarn);
        public void DeleteYarn(int id);
        public List<Yarn> GetAllYarns();
        public Yarn GetYarn(int id);
    }
}
