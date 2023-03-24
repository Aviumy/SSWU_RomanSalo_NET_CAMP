namespace Home_task_1
{
    internal class LineInfo
    {
        public int Color { get; set; }
        public (int, int) Start { get; set; }
        public (int, int) End { get; set; }
        public int Length { get; set; }

        public LineInfo(int color, (int, int) start, (int, int) end, int length)
        {
            Color = color;
            Start = start;
            End = end;
            Length = length;
        }

        public override string ToString()
        {
            return $"Color: {Color}\nStart: {Start}\nEnd: {End}\nLength: {Length}";
        }
    }
}
