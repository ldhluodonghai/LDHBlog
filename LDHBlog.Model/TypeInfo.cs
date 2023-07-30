
using LDHBlog.Model;
using SqlSugar;
namespace LDHBlog.Model
{
  public class TypeInfo:BaseId
  {
    [SugarColumn(ColumnDataType ="nvarchar(12)")]
    public string Name { get; set; }
  }
}
