using System.Xml;
using System.Xml.Linq;
using GPXReaderLib.Interfaces;
using GPXReaderLib.Models;
using rando;

Console.WriteLine("GpxReaderLib console demonstrative app");

List<TrackPoint> parcours = new List<TrackPoint>();

try
{
    XDocument myGPX = XDocument.Load("C:\\Users\\pf25xeu\\Documents\\GitHub\\323-Programmation_fonctionnelle\\exos\\rando\\gpx\\loechegemmi.gpx");

    XmlNamespaceManager r = new XmlNamespaceManager(new NameTable());
    r.AddNamespace("p", "http://www.topografix.com/GPX/1/1");

    GPXReaderLib.GpxReader gpxReader = new GPXReaderLib.GpxReader(myGPX, r);

    Console.WriteLine("Name: " + gpxReader.GetGpxName());
    Console.WriteLine("Avg Elevation: " + gpxReader.GetElevation(ElevationType.Avg));
    Console.WriteLine("Min Elevation: " + gpxReader.GetElevation(ElevationType.Min));
    Console.WriteLine("Max Elevation: " + gpxReader.GetElevation(ElevationType.Max));
    //Console.WriteLine("Start Date: " + gpxReader.GetStartDt());
    //Console.WriteLine("End Date: " + gpxReader.GetEndDt());
    //Console.WriteLine("Duration: " + gpxReader.GetDuration());
    Console.WriteLine("Distance: " + gpxReader.GetDistance());
    Console.WriteLine("Elevation Gain: " + gpxReader.GetElevationGain());

    Console.WriteLine("Printing complete list of latitude - longitude");

    IEnumerable<TrackPoint> trackPoints = gpxReader.GetGpxCoordinates();
    foreach (var trackPoint in trackPoints)
    {
        parcours.Add(trackPoint);
        Console.WriteLine($"lat: {trackPoint.Latitude} - lon: {trackPoint.Longitude}");
    }

    GpxAltimetry altimetry = gpxReader.GetGpxAltimetry();
    foreach (Altimetry altimetryItem in altimetry.Altimetries)
    {
        Console.WriteLine($"Altimetry value: Meters:{altimetryItem.Elevation} - KM:{altimetryItem.Kilometers}");
    }

    // Nom du fichier GPX à créer
    string fileName = "C:\\Users\\pf25xeu\\Desktop\\output.gpx";

    // Création d'un XmlWriter pour écrire le fichier GPX
    using (XmlWriter writer = XmlWriter.Create(fileName))
    {
        // Écriture de l'en-tête GPX
        writer.WriteStartDocument();
        writer.WriteStartElement("gpx");
        writer.WriteAttributeString("version", "1.1");
        writer.WriteAttributeString("creator", "YourAppName");

        parcours.ForEach(item => { WriteWaypoint(writer, item); });

        // Fermeture de l'élément gpx
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }

    static void WriteWaypoint(XmlWriter writer, TrackPoint trackpoint)
    {
        writer.WriteStartElement("wpt");
        writer.WriteAttributeString("lat", trackpoint.Latitude.ToString());
        writer.WriteAttributeString("lon", trackpoint.Longitude.ToString());
        writer.WriteElementString("ele", trackpoint.Elevation.ToString());

        writer.WriteEndElement(); // Fin de l'élément wpt
    }

    Console.WriteLine($"Fichier GPX créé : {fileName}");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
