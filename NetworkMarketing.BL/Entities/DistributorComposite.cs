using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetworkMarketing.BL.Entities
{
    public class DistributorComposite : IDistributorComponent
    {
        private List<IDistributorComponent> _children = new List<IDistributorComponent>();
        public void AddChild(IDistributorComponent child)
        {
            _children.Add(child);
        }
        public void RemoveChild(IDistributorComponent child)
        {
            _children.Remove(child);
        }
        public IDistributorComponent GetChild(int index)
        {
            return _children[index];
        }
        public decimal CalculateBonus()
        {
            decimal bonus = 0;
            foreach (var child in _children)
            {
                bonus += child.CalculateBonus();
            }
            return bonus;
        }
    }
}
