using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_2021
{
    static class FindSubClass
    {
        private static RichTextBoxEx target = null;
        public static RichTextBoxEx Target { get => target; set => target = value; }

        public struct Parameters
        {
            public static string textToFind;
            public static bool isUp = false;
            public static bool isCaseSensitive = false;
            public static bool isTextAround = false;
        }

        public static int Find()
        {
            RichTextBoxFinds options = 0;
            if (Parameters.isUp) options &= RichTextBoxFinds.Reverse;
            if (Parameters.isCaseSensitive) options &= RichTextBoxFinds.MatchCase;
            Target.Focus();
            return Target.Find(Parameters.textToFind, options);
        }
    }
}
