using Grannys_yarns_API.Model;
using System.Drawing;
using System.Xml.Linq;

namespace Grannys_yarns_API.Repository
{
    public class MemoryRepository : iRepository
    {
        static private List<Yarn> yarns = [
            #region mockedYarns
            new Yarn {
                id = 0,
                name = "Alize Velluto Yarn",
                color = "red",
                price = 15,
                quantity = 20,
                size = 2
            },
            new Yarn
            {
                id = 1,
                name = "Alize Bella Yarn",
                color = "blue",
                price = 16,
                quantity = 15,
                size = 3
            },
            new Yarn
            {
                id = 2,
                name = "Alize Klasik Yarn",
                color = "green",
                price = 17,
                quantity = 10,
                size = 4
            },
            new Yarn {
                id = 3,
                name = "Alize Diva Yarn",
                color = "yellow",
                price = 18,
                quantity = 5,
                size = 2
            },
            new Yarn
            {
                id = 4,
                name = "Alize Midi Yarn",
                color = "orange",
                price = 14,
                quantity = 25,
                size = 3
            },
            new Yarn
            {
                id = 5,
                name = "Alize Cotton Gold Yarn",
                color = "purple",
                price = 13,
                quantity = 30,
                size = 2
            },
            new Yarn
            {
                id = 6,
                name = "Alize Forever Yarn",
                color = "black",
                price = 12,
                quantity = 35,
                size = 3
            }
            #endregion
            ];

        public MemoryRepository()
        {
        }
        public void AddYarn(Yarn yarn)
        {
            yarns.Add(yarn);
        }

        public void DeleteYarn(int id)
        {
            Yarn yarnToDelete = yarns.FirstOrDefault(y => y.id == id);

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
            
            Yarn existingYarn = yarns.FirstOrDefault(x => x.id == updatedYarn.id);
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
            Yarn yarn =  yarns.FirstOrDefault(x => x.id == id);
            if (yarn == null)
            {
                throw new Exception("Yarn not found");
            }
            return yarn;    
        }
    }
}
