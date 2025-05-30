namespace External.JokeAPI
{
    public interface ICheckbox
    {
        string ToggleKey { get; }
        bool IsOn { get; }
        bool HasChanged { get; set; }
    }
}