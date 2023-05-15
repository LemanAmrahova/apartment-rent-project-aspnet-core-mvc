using ApartmentSaleProject.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ApartmentSaleProject.Repositories
{
    public class BlockRepository
    {
        public void AddBlock(Block block)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            db.Blocks.Add(block);
            db.SaveChanges();
        }

        public void Update(Block block)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            Block data = db.Blocks.Where(x => x.Id == block.Id).FirstOrDefault();
            data.Name = block.Name;
            db.SaveChanges();
        }

        public void Deactive(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            Block block = db.Blocks.Where(x => x.Id == id).FirstOrDefault();
            block.Status = false;
            db.SaveChanges();
        }

        public List<Block> GetActiveBlocks()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            return db.Blocks.Where(x => x.Status == true).ToList();
        }
        public IQueryable<Block> GetAllBlocks()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<Block> block = db.Blocks;
            return block;
        }

        public IQueryable<Block> GetBlock(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<Block> block = db.Blocks;
            return block.Where(x => x.Id == id);
        }
    }
}
