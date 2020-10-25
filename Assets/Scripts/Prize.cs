
public class Prize
{
    //in the real world, there would be a prize manager
    //but since there is only one card, this class will surface
    public int mask;
    public int value;
    public bool paid = false;

    public Prize()
    {
        
    }
    
    public Prize(int mask, int value)
    {
        this.mask = mask;
        this.value = value;
    }
}
