namespace Problem06_ConnectedAreasInAMatrix
{
    using System;

    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            if (this.Size.CompareTo(other.Size) == 0)
            {
                if (this.Row.CompareTo(other.Row) == 0)
                {
                    return this.Col.CompareTo(other.Col);
                }

                return this.Row.CompareTo(other.Row);
            }

            return this.Size.CompareTo(other.Size) * (-1);
        }
    }
}
