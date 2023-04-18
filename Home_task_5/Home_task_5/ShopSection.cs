using System.Text;

namespace Home_task_5
{
    internal class ShopSection
    {
        private int _indentLevel;

        public string Name { get; private set; }
        public (double X, double Y, double Z) Size { get; private set; }

        public ShopSection Root { get; private set; }
        public List<ShopSection> Subsections { get; set; }

        public ShopSection(string name, (double x, double y, double z) size, ShopSection root, List<ShopSection> subsections)
        {
            Name = name;
            Size = size;
            Root = root;
            Subsections = subsections;

            _indentLevel = 0;
            var tempRoot = Root;
            while (tempRoot != null)
            {
                _indentLevel++;
                tempRoot = tempRoot.Root;
            }
        }

        public ShopSection(string name, ShopSection root, List<ShopSection> subsections)
        {
            Name = name;
            Size = (0, 0, 0);
            Root = root;
            Subsections = subsections;

            _indentLevel = 0;
            var tempRoot = Root;
            while (tempRoot != null)
            {
                _indentLevel++;
                tempRoot = tempRoot.Root;
            }
        }

        public void CalculateSize()
        {
            if (Subsections == null || Subsections.Count == 0)
            {
                var tempRoot = Root;
                while (tempRoot != null)
                {
                    double x = Math.Max(tempRoot.Size.X, this.Size.X);
                    double y = tempRoot.Size.Y + this.Size.Y;
                    double z = Math.Max(tempRoot.Size.Z, this.Size.Z);
                    tempRoot.Size = (x, y, z);
                    tempRoot = tempRoot.Root;
                }
            }
            else
            {
                foreach (var section in Subsections)
                {
                    section.CalculateSize();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (Subsections == null || Subsections.Count == 0)
            {
                result.Append($"{new string(' ', _indentLevel * 4)} {Name} {Size}");
            }
            else
            {
                result.AppendLine($"{new string(' ', _indentLevel * 4)} {Name} {Size}");
                foreach (var section in Subsections)
                {
                    result.AppendLine(section.ToString());
                }
            }
            return result.ToString();
        }
    }
}
