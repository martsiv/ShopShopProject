using AutoMapper;
using Business_logic.DTOs;
using Business_logic.Interfaces;
using data_access.data;
using data_access.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;
        private readonly IFavoritesService favService;

        public OrdersService(IMapper mapper, ApplicationContext context, IFavoritesService favService)
        {
            this.mapper = mapper;
            this.context = context;
            this.favService = favService;
        }

        public void Create(string userId)
        {
            // TODO CHANGE CODE
            //var ids = cartService.GetProductIds();
            //var products = context.Products.Where(x => ids.Contains(x.Id)).ToList();

            //var order = new Order()
            //{
            //    Date = DateTime.Now,
            //    UserId = userId,
            //    Products = products,
            //    TotalPrice = products.Sum(x => x.Price),
            //};

            //context.Orders.Add(order);
            //context.SaveChanges();
        }

        public IEnumerable<OrderDto> GetAllByUser(string userId)
        {
            //var items = context.Orders.Where(x => x.UserId == userId).ToList();
            //return mapper.Map<IEnumerable<OrderDto>>(items);
            return null;
        }
    }
}
