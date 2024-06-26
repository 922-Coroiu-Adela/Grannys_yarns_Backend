﻿using Grannys_yarns_API.Model;
using System.Drawing;
using System.Xml.Linq;

namespace Grannys_yarns_API.Repository
{
    public class MemoryRepository : iRepository
    {
        static private List<Yarn> yarns = [
            #region mockedYarns
            new Yarn {
                yid = 0,
                did = 0,
                name = "Alize Velluto Yarn",
                color = "red",
                price = 15,
                quantity = 20,
                size = 2
            },
            new Yarn
            {
                yid = 1,
                did = 1,
                name = "Alize Bella Yarn",
                color = "blue",
                price = 16,
                quantity = 15,
                size = 3
            },
            new Yarn
            {
                yid = 2,
                did = 2,
                name = "Alize Klasik Yarn",
                color = "green",
                price = 17,
                quantity = 10,
                size = 4
            },
            new Yarn {
                yid = 3,
                did = 0,
                name = "Alize Diva Yarn",
                color = "yellow",
                price = 18,
                quantity = 5,
                size = 2
            },
            new Yarn
            {
                yid = 4,
                did = 0,
                name = "Alize Midi Yarn",
                color = "orange",
                price = 14,
                quantity = 25,
                size = 3
            },
            new Yarn
            {
                yid = 5,
                did = 1,
                name = "Alize Cotton Gold Yarn",
                color = "purple",
                price = 13,
                quantity = 30,
                size = 2
            },
            new Yarn
            {
                yid = 6,
                did = 2,
                name = "Alize Forever Yarn",
                color = "black",
                price = 12,
                quantity = 35,
                size = 3
            }
            #endregion
            ];

        static private List<Distributor> distributors = [
            new Distributor
            {
                did = 0,
                name = "Distributor1",
                address = "Address1",
                phone = "0712-121121"
            },
            new Distributor
            {
                did = 1,
                name = "Distributor2",
                address = "Address2",
                phone = "0712-121000"
            },
            new Distributor
            {
                did = 2,
                name = "Distributor3",
                address = "Address3",
                phone = "0712-121909"
            }
            ];

        public MemoryRepository()
        {
        }
        public void AddYarn(Yarn yarn)
        {
            yarn.yid = GetAllYarns().Max(x => x.yid) + 1;
            yarns.Add(yarn);
        }

        public void DeleteYarn(int id)
        {
            Yarn yarnToDelete = yarns.FirstOrDefault(y => y.yid == id);

            if (yarnToDelete == null)
            {
                throw new Exception("Yarn not found");
            }
            yarns.Remove(yarnToDelete);
        }

        public List<Yarn> GetAllYarns()
        {
            return yarns;
        }

        public void UpdateYarn(Yarn updatedYarn)
        {
            
            Yarn existingYarn = yarns.FirstOrDefault(x => x.yid == updatedYarn.yid);
            if (existingYarn == null) 
            {
                throw new Exception("Yarn not found");
            }
            existingYarn.name = updatedYarn.name;
            existingYarn.color = updatedYarn.color;
            existingYarn.quantity = updatedYarn.quantity;
            existingYarn.price = updatedYarn.price;
            existingYarn.size = updatedYarn.size;
        }

        public Yarn GetYarn(int id)
        {
            Yarn yarn =  yarns.FirstOrDefault(x => x.yid == id);
            if (yarn == null)
            {
                throw new Exception("Yarn not found");
            }
            return yarn;    
        }

        public void AddDistributor(Distributor distributor)
        {
            distributor.did = GetAllDistributors().Max(x => x.did) + 1;
            distributors.Add(distributor);
        }

        public void DeleteDistributor(int id)
        {
            Distributor distributorToDelete = distributors.FirstOrDefault(d => d.did == id);

            if (distributorToDelete == null)
            {
                throw new Exception("Distributor not found");
            }
            distributors.Remove(distributorToDelete);
        }

        public List<Distributor> GetAllDistributors()
        {
            return distributors;
        }

        public Distributor GetDistributor(int id)
        {
            Distributor distributor = distributors.FirstOrDefault(x => x.did == id);
            if (distributor == null)
            {
                throw new Exception("Distributor not found");
            }
            return distributor;
        }

        public void UpdateDistributor(Distributor updatedDistributor)
        {
            Distributor existingDistributor = distributors.FirstOrDefault(x => x.did == updatedDistributor.did);
            if (existingDistributor == null)
            {
                throw new Exception("Distributor not found");
            }
            existingDistributor.name = updatedDistributor.name;
            existingDistributor.address = updatedDistributor.address;
            existingDistributor.phone = updatedDistributor.phone;
        }

        public Distributor GetDistributorByUsername(string username)
        {
            Distributor distributor = distributors.FirstOrDefault(x => x.name == username);
            if (distributor == null)
            {
                throw new Exception("Distributor not found");
            }
            return distributor;
        }

        public bool ValidToken(string token)
        {
            return true;
        }

        public void AddSession(Session session)
        {
            throw new NotImplementedException();
        }

        public void RemoveSession(int distributorId)
        {
            throw new NotImplementedException();
        }

    }
}
