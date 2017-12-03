using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }

        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get取得所有尚未刪除的商品資料()
        {
            return this.All();
        }
        public IQueryable<Product> Get取得所有尚未刪除的商品資料Top10()
        {
            return this.All().Take(10);
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}