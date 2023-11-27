using System.Xml.Serialization;

namespace ConsoleApp1;

[XmlRoot(ElementName = "kml", Namespace = "http://www.opengis.net/kml/2.2")]
public class Kml
{
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}

public class Document
{
    [XmlElement(ElementName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "StyleMap")]
    public List<StyleMap> StyleMaps { get; set; }

    [XmlElement(ElementName = "Style")]
    public List<Style> Styles { get; set; }

    [XmlElement(ElementName = "Placemark")]
    public List<Placemark> Placemarks { get; set; }
}

public class StyleMap
{
    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }

    [XmlElement(ElementName = "Pair")]
    public List<Pair> Pairs { get; set; }
}

public class Pair
{
    [XmlElement(ElementName = "key")]
    public string Key { get; set; }

    [XmlElement(ElementName = "styleUrl")]
    public string StyleUrl { get; set; }
}

public class Style
{
    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }

    [XmlElement(ElementName = "LineStyle")]
    public LineStyle LineStyle { get; set; }

    [XmlElement(ElementName = "PolyStyle")]
    public PolyStyle PolyStyle { get; set; }
}

public class LineStyle
{
    [XmlElement(ElementName = "color")]
    public string Color { get; set; }

    [XmlElement(ElementName = "width")]
    public int Width { get; set; }
}

public class PolyStyle
{
    [XmlElement(ElementName = "fill")]
    public int Fill { get; set; }
}

public class Placemark
{
    [XmlElement(ElementName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "open")]
    public int Open { get; set; }

    [XmlElement(ElementName = "styleUrl")]
    public string StyleUrl { get; set; }

    [XmlElement(ElementName = "Polygon")]
    public Polygon Polygon { get; set; }
}

public class Polygon
{
    [XmlElement(ElementName = "tessellate")]
    public int Tessellate { get; set; }

    [XmlElement(ElementName = "outerBoundaryIs")]
    public OuterBoundaryIs OuterBoundaryIs { get; set; }
}

public class OuterBoundaryIs
{
    [XmlElement(ElementName = "LinearRing")]
    public LinearRing LinearRing { get; set; }
}

public class LinearRing
{
    [XmlElement(ElementName = "coordinates")]
    public string CoordinatesAsString { get; set; }
    public Vertice[] Coordinates
    {
        get
        {
            var coordinatesAsString = CoordinatesAsString
                .Replace("0 ", string.Empty)
                .Trim()
                .Split(',')
                .AsSpan();

            var result = new Vertice[coordinatesAsString.Length / 2];

            for (int i = 0, j = 0; i < result.Length; i++, j += 2)
            {
                var lat = double.Parse(coordinatesAsString[j]);
                var @long = double.Parse(coordinatesAsString[j + 1]);
                result[i] = new Vertice { Lat = lat, Lng = @long };
            }

            return result;
        }
    }
}

public class Vertice
{
    public double Lng { get; set; }
    public double Lat { get; set; }
}