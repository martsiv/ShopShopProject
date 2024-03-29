﻿using Microsoft.EntityFrameworkCore;
using data_access.Entities;

namespace data_access.data
{
    public class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryCompany>().HasData(new DeliveryCompany[]
            {
                new DeliveryCompany() { Id = 1, Name = "UkrPoshta" },
                new DeliveryCompany() { Id = 2, Name = "NovaPoshta" },
                new DeliveryCompany() { Id = 3, Name = "MeestExpress" },
                new DeliveryCompany() { Id = 4, Name = "Delivery" },
            });
			modelBuilder.Entity<AdvertisementStatus>().HasData(new AdvertisementStatus[]
			{
				new AdvertisementStatus() { Id = 1, Name = "New" },
				new AdvertisementStatus() { Id = 2, Name = "Active" },
				new AdvertisementStatus() { Id = 3, Name = "Unactive" },
				new AdvertisementStatus() { Id = 4, Name = "Deleted" },
				new AdvertisementStatus() { Id = 5, Name = "Archive" },
			});
			modelBuilder.Entity<Category>().HasData(new Category[]
			{
				new Category() { Id = 1, Name = "Child wares" },
				new Category() { Id = 2, Name = "Cars" },
				new Category() { Id = 3, Name = "Transports parts" },
				new Category() { Id = 4, Name = "Jobs" },
				new Category() { Id = 5, Name = "Animals" },
				new Category() { Id = 6, Name = "Home and garden" },
				new Category() { Id = 7, Name = "Electronics" },
				new Category() { Id = 8, Name = "Business and commerce" },
				new Category() { Id = 9, Name = "Rents and hires" },
				new Category() { Id = 10, Name = "Fashion & Style" },
				new Category() { Id = 11, Name = "Hobbies, leisure and sports" },

				new Category() { Id = 12, Name = "Phones and accessories", ParentCategoryId = 7},
				new Category() { Id = 13, Name = "Audio", ParentCategoryId = 7},
				new Category() { Id = 14, Name = "Home appliances", ParentCategoryId = 7},
				new Category() { Id = 15, Name = "Accessories and components", ParentCategoryId = 7},
				new Category() { Id = 16, Name = "Computers and components", ParentCategoryId = 7},
				new Category() { Id = 17, Name = "Games and consoles", ParentCategoryId = 7},
				new Category() { Id = 18, Name = "Appliance for kitchen", ParentCategoryId = 7},
				new Category() { Id = 19, Name = "Other appliance", ParentCategoryId = 7},
				new Category() { Id = 20, Name = "Photo and video", ParentCategoryId = 7},
				new Category() { Id = 21, Name = "Tablets / Ebooks", ParentCategoryId = 7},
				new Category() { Id = 22, Name = "HVAC equipment", ParentCategoryId = 7},
				new Category() { Id = 23, Name = "Repair of equipment", ParentCategoryId = 7},
				new Category() { Id = 24, Name = "TV / Video", ParentCategoryId = 7},
				new Category() { Id = 25, Name = "Laptops and accessories", ParentCategoryId = 7},
			});
            modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[]
            {
                new OrderStatus() { Id = 1, Name = "New" },
                new OrderStatus() { Id = 2, Name = "Processing" },
                new OrderStatus() { Id = 3, Name = "Shipped" },
                new OrderStatus() { Id = 4, Name = "Delivered" },
                new OrderStatus() { Id = 5, Name = "Pending Payment" },
                new OrderStatus() { Id = 6, Name = "Canceled" },
                new OrderStatus() { Id = 7, Name = "Refused" },
            });
        }
    }
}
