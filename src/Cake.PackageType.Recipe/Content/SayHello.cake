public void SayHello(string name)
{
    try
    {
        Information("Hello {0} from {1}", name, "Cake.PackageType.Recipe");
    }
    catch(Exception ex)
    {
        Error("{0}", ex);
    }
}
