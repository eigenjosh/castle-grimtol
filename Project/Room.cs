using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Item> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}