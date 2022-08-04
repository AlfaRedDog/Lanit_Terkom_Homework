namespace HW2
{
    internal interface IFileReader
    {
        void ReadNLines(string path, int n);

        void ReadAllLines(string path);
    }
}
