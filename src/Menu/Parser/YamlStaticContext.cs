using YamlDotNet.Serialization;

namespace Menu.Parser;

[YamlStaticContext]
[YamlSerializable(typeof(Root))]
[YamlSerializable(typeof(AppMenu))]
[YamlSerializable(typeof(MenuItem))]
[YamlSerializable(typeof(Instruction))]
public partial class YamlStaticContext : StaticContext
{
}