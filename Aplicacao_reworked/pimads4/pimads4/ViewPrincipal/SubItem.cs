using System.Windows.Controls;

namespace pimads4
{
    public class SubItem
    {
        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
            if (Screen!=null)
            {
                Screen.InvalidateVisual();
            }
            
        }

        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
    }
}