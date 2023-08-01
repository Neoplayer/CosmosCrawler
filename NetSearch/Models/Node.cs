namespace NetSearch.Models;

public class Node
{
    public string Moniker { get; set; }
    public string Address { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj is Node otherNode)
        {
            return this.Moniker == otherNode.Moniker && this.Address == otherNode.Address;
        }
        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Moniker != null ? Moniker.GetHashCode() : 0);
            hash = hash * 23 + (Address != null ? Address.GetHashCode() : 0);
            return hash;
        }
    }
}