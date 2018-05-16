using System.Diagnostics;
using Antlr4.Runtime;
using Microsoft.Pc.TypeChecker.Types;

namespace Microsoft.Pc.TypeChecker.AST.Declarations
{
    public class PEvent : IPDecl
    {
        public PEvent(string name, ParserRuleContext sourceNode)
        {
            Debug.Assert("halt".Equals(name) && sourceNode == null ||
                         "null".Equals(name) && sourceNode == null ||
                         sourceNode is PParser.EventDeclContext);
            Name = name;
            SourceLocation = sourceNode;
            PayloadType = PrimitiveType.Null;
            Assert = -1;
            Assume = -1;
        }

        public int Assume { get; set; }
        public int Assert { get; set; }
        public PLanguageType PayloadType { get; set; }


        public string Name { get; }
        public ParserRuleContext SourceLocation { get; }

        public bool IsHaltEvent => string.Equals(Name, "halt");
        public bool IsNullEvent => string.Equals(Name, "null");
        public bool IsBuiltIn => IsHaltEvent || IsNullEvent;
    }
}