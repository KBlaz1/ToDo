namespace DrawBoxes
{
    public static class DrawBoxes
    {
        public static String DrawBox(params String[] lines)
        {
            if (lines == null || lines.Length == 0)
                return "";

            int boxWidth = lines.OrderByDescending(line => line.Length).First().Length + 2;

            String box = ' ' + new string('-', boxWidth);
            box += "\n";

            foreach (String line in lines)
            {
                box += "| " + line + new string(' ', boxWidth - line.Length -1) + "|\n";
            }

            box += ' ' + new string('-', boxWidth);
            return box;
        }
    }
}
