

namespace SpaceInvader.Tests;
public class Class1
{
    public void Covered()
    {
        "Covered".ToString();
    }
    public void NotCovered()
    {
        "NotCovered".ToString();
    }
    public void PartiallyCovered(bool isTrue)
    {
        if (isTrue)
        {
            "Covered".ToString();
        }
        else
        {
            "NotCovered".ToString();
        }
    }
}
