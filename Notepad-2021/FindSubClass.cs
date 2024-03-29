﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            public static string textToFind = "";
            public static string textToReplace = "";
            public static bool isUp = false;
            public static bool isCaseSensitive = false;
            public static bool isTextAround = false;
        }

        public static int Find()
        {
            RichTextBoxFinds options = RichTextBoxFinds.None;
            int start = 0;
            int end = -1;
            if (Parameters.isUp)
            {
                options |= RichTextBoxFinds.Reverse;
                end = Target.SelectionStart;
                if (end == 0) return -1;
            }
            else
            {
                start = Target.SelectionStart + Target.SelectionLength;
                if (start == Target.TextLength) return -1;
            }
            if (Parameters.isCaseSensitive) options |= RichTextBoxFinds.MatchCase;
            if (Parameters.isTextAround) options |= RichTextBoxFinds.WholeWord;
            Target.Focus();
            return Target.Find(
                Parameters.textToFind, 
                start,
                end,
                options
                );
        }

        internal static int Replace()
        {
            if (Target.SelectedText == Parameters.textToFind)
            {
                Target.SelectedText = Parameters.textToReplace;
            }
            return Find();
        }

        internal static void ReplaceAll()
        {
            RegexOptions options = Parameters.isCaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
            string myTextTofind = Parameters.isTextAround ? String.Format(@"\b{0}\b", Parameters.textToFind) : Parameters.textToFind;
            Target.Text = Regex.Replace(Target.Text, myTextTofind, Parameters.textToReplace, options);
        }

        public static void ShowNotFoundMessage()
        {
            MessageBox.Show(
                "Impossibile trovare \"" + FindSubClass.Parameters.textToFind + "\"",
                "Blocco note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
