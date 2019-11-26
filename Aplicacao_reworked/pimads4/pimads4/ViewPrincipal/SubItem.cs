using System.Windows.Controls;

namespace pimads4
{
    public class SubItem
    {
        public SubItem(string name, string menuTela = "")
        {
            Name = name;
            MenuTela = menuTela;
        }

        public string Name { get; private set; }
        public string MenuTela { get; private set; }
    }
}