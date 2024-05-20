using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;

namespace Grannys_yarns_API.Services
{
    public class Service: iService
    {
        private iRepository repository;

        public Service(iRepository repository)
        {
            this.repository = repository;
        }

        public void AddYarn(Yarn yarn)
        {
            repository.AddYarn(yarn);
        }

        public void UpdateYarn(Yarn updatedYarn)
        {
            repository.UpdateYarn(updatedYarn);
        }

        public void DeleteYarn(int id)
        {
            repository.DeleteYarn(id);
        }

        public Yarn GetYarn(int id)
        {
            return repository.GetYarn(id);
        }

        public List<Yarn> GetAllYarns()
        {
            return repository.GetAllYarns();
        }

        public void AddDistributor(Distributor distributor)
        {
            repository.AddDistributor(distributor);
        }

        public void UpdateDistributor(Distributor updatedDistributor)
        {
            repository.UpdateDistributor(updatedDistributor);
        }

        public void DeleteDistributor(int id)
        {
            repository.DeleteDistributor(id);
        }

        public Distributor GetDistributor(int id)
        {
            return repository.GetDistributor(id);
        }

        public List<Distributor> GetAllDistributors()
        {
            return repository.GetAllDistributors();
        }

    }
}
