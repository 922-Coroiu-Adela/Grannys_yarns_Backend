using Bogus;
using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;
using System.Security.Cryptography;

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

        public Session GenerateSessions(int distributorId)
        {
            Random random = new Random();
            string token = random.Next(10000000, 99999999).ToString();
            Session session = new Session();
            session.token = token;
            session.did = distributorId;
            repository.AddSession(session);
            return session;
        }

        public bool ValidateToken(string token)
        {
            return repository.ValidToken(token);
        }

        public void RemoveSession(int distributorId)
        {
            repository.RemoveSession(distributorId);
        }

        public Distributor GetDistributorByUsername(string username)
        {
            return repository.GetDistributorByUsername(username);
        }

    }
}
