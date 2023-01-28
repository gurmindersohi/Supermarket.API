﻿namespace Supermarket.Domain.Entities
{
	public class Category
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}

