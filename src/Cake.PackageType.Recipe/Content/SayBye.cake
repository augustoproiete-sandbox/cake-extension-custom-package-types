public void SayBye(string name)
{
    try
    {
        Information("Bye {0} from {1}", name, "Cake.PackageType.Recipe");
    }
    catch(Exception ex)
    {
        Error("{0}", ex);
    }
}
