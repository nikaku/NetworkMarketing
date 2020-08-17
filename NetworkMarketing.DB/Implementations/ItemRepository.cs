using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.DB.Implementations
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        {

        }

        private DataContext ItemContext => Context as DataContext;
    }
}
