// Models/ParameterDetailsDto.cs
namespace CadLibBackend.Models;

public class ParameterDetailsDto
{
    public int ObjectId { get; set; }
    public int ParamDefId { get; set; }
    public string ParamCaption { get; set; }      // Из ParamDefs
    public string ParamValue { get; set; }
    public string ParamType { get; set; } // "string", "int", "double"


}