namespace WeaponThread
{
    partial class Weapons
    {
        internal Weapons()
        {
            // Filename convention: 
            // Name.cs - See Gatling.cs file for weapon property details.
            //
            // Enable your config files using the following syntax, don't include the ".cs" extension:
            // ConfigFiles(Your1stConfigFile, Your2ndConfigFile, Your3rdConfigFile);

            ConfigFiles(Gatling);

            // To register block subtypes as armor you can use these functions below
            // LightArmorSubtypes("LightArmorSubtypeIdB", "LightArmorSubtypeIdB");
            // HeavyArmorSubtypes("HeavyArmorSubtypeIdA", "HeavyArmorSubtypeIdB");
        }
    }
}
