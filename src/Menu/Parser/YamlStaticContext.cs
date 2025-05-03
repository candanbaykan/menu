using YamlDotNet.Serialization;

namespace Menu.Parser;

[YamlStaticContext]
[YamlSerializable(typeof(Root))]
[YamlSerializable(typeof(MenuItem))]
public partial class YamlStaticContext : StaticContext
{
}