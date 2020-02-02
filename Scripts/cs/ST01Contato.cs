using NUnit.Framework;
using NUnit.Core;

namespace SeleniumTests
{
    public class ST01Contato
    {
        [Suite] public static TestSuite Suite
        {
            get
            {
                TestSuite suite = new TestSuite("ST01Contato");
                suite.Add(new CT01ValidarLayoutTela());
                suite.Add(new CT02ValidarCamposObrigatorios());
                return suite;
            }
        }
    }
}
