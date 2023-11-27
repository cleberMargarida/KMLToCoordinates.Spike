using ConsoleApp1;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

Assembly assembly = Assembly.GetExecutingAssembly();

using var stream = assembly.GetManifestResourceStream("ConsoleApp1.kml.xml")!;
var serializer = new XmlSerializer(typeof(Kml));
var obj = serializer.Deserialize(stream) as Kml;
var coordinates = obj.Document.Placemarks[0].Polygon.OuterBoundaryIs.LinearRing.Coordinates;
Console.Read();