using Grannys_yarns_API.Model;

namespace Grannys_yarns_API.Repository
{
    public interface iRepository
    {
        public void AddYarn(Yarn yarn);
        public void UpdateYarn(Yarn updatedYarn);
        public void DeleteYarn(int id);
        public Yarn GetYarn(int id);
        public List<Yarn> GetAllYarns();
        public void AddDistributor(Distributor distributor);
        public void UpdateDistributor(Distributor updatedDistributor);
        public void DeleteDistributor(int id);
        public Distributor GetDistributor(int id);
        public List<Distributor> GetAllDistributors();

    }
}
