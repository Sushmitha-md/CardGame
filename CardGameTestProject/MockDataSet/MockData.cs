using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameTestProject.MockDataSet
{
    public static class MockData
    {
        public static List<string> MockInputData()
        {
            String[] cards = new string[11] { "3C", "JS", "2D", "PT", "10H", "KH", "4T", "AC", "4H", "RT","8S" };
            return cards.ToList();
        }

        public static List<string> ExpectedOutput()
        {
            String[] cards = new string[11] { "4T", "PT", "RT", "2D", "8S", "JS", "3C", "AC", "4H", "10H", "KH" };
            return cards.ToList();
        }
    }
}
